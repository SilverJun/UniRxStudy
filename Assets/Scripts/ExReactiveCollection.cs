using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExReactiveCollection : MonoBehaviour
{
    private readonly ReactiveCollection<int> _numList = new ReactiveCollection<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        _numList.ObserveAdd()
            .Where(x => x.Value > 10)
            .Subscribe(value =>
            {
                Debug.Log($"{value}가 추가됨");
            })
            .AddTo(this);
        _numList.ObserveRemove()
            .Subscribe(value =>
            {
                Debug.Log($"{value}가 제거됨");
            })
            .AddTo(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _numList.Add(Random.Range(0, 100));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _numList.RemoveAt(Random.Range(0, _numList.Count));
        }
    }
}
