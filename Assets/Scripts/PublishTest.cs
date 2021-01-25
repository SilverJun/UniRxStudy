using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PublishTest : MonoBehaviour
{
    private Subject<int> _subject = new Subject<int>();
    private BehaviorSubject<int> _behaviorSubject = new BehaviorSubject<int>(0);
    private ReactiveProperty<int> _testReactiveProperty = new ReactiveProperty<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        // behavior subject로 하면 이벤트를 하나 저장함.
        // 따라서 20과 30이 표시됨
        // var behaviorSubjectObservable = _behaviorSubject.AsObservable()
        //     .Select(x => x * 10);
        //
        // _behaviorSubject.OnNext(1);
        // _behaviorSubject.OnNext(2);
        //
        // behaviorSubjectObservable.Subscribe(value =>
        // {
        //     Debug.Log($"value : {value}");
        // });
        //
        // _behaviorSubject.OnNext(3);

        // 따라서 20과 30이 표시됨
        // IObservable<int> observable = _testReactiveProperty.AsObservable();
        // _testReactiveProperty.Value = 1;
        // _testReactiveProperty.Value = 2;
        //
        // observable.Subscribe(x => Debug.Log($"value : {x}"));
        //
        // _testReactiveProperty.Value = 3;
        
        var subjectObservable = _subject.AsObservable()
            .Scan((a, b) => a*10 + b)
            .Share();
        
        _subject.OnNext(1);
        _subject.OnNext(2);
        
        subjectObservable.Subscribe(value =>
        {
            Debug.Log($"value : {value}");
        });
        
        _subject.OnNext(3);
    }
}
