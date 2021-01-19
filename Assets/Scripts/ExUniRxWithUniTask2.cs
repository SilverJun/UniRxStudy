using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExUniRxWithUniTask2 : MonoBehaviour
{
    Subject<Unit> _reloadStream = new Subject<Unit>();
    Subject<Unit> _forceReloadStream = new Subject<Unit>();
    Subject<Unit> _natureReloadStream = new Subject<Unit>();

    void Start()
    {
        // way 1
        // _reloadStream
        //     .Merge(_forceReloadStream.Merge(_natureReloadStream))
        //     .Throttle(TimeSpan.FromMilliseconds(100))
        //     .Select(_ => _LoadSomeData(0, 1000))
        //     .Subscribe(async uniTask =>
        //     {
        //         var res = await uniTask;
        //         Debug.Log($"res: {res}");
        //     });
        
        // way 2
        // _reloadStream
        //     .Merge(_forceReloadStream.Merge(_natureReloadStream))
        //     .Throttle(TimeSpan.FromMilliseconds(100))
        //     .ObserveOn(Scheduler.ThreadPool)
        //     .Select(async _ => await _LoadSomeData(0, 1000))
        //     .ObserveOnMainThread()
        //     .Select(x => x.Result)
        //     .Subscribe(uniTask =>
        //     {
        //         var res = uniTask;
        //         Debug.Log($"res: {res}");
        //     });

        // way 3
        _reloadStream
            .Merge(_forceReloadStream.Merge(_natureReloadStream))
            .Throttle(TimeSpan.FromMilliseconds(100))
            .SelectMany(_ => _LoadSomeData(0, 1000).ToObservable())
            .Subscribe(uniTask =>
            {
                var res = uniTask;
                Debug.Log($"res: {res}");
            });
        
        _TryToReloadNaturally().Forget();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space!");
            _forceReloadStream.OnNext(Unit.Default);
        }
    }

    private async UniTaskVoid _TryToReloadNaturally()
    {
        while (gameObject.activeSelf)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            Debug.Log("ReloadNaturally");
            _natureReloadStream.OnNext(Unit.Default);
        }
    }

    private async UniTask<int> _LoadSomeData(int min, int max)
    {
        var delay = Random.Range(1, 1000);
        await UniTask.DelayFrame(delay);
        return Random.Range(min, max);
    }
}
