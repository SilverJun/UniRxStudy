using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RxTest : MonoBehaviour
{
    public static Subject<Unit> _testStream = new Subject<Unit>();

    private void Awake()
    {
        _testStream.Subscribe(unit =>
            {
                Debug.Log($"Event");
            },
            exception =>
            {
                Debug.Log($"Error with : {exception.Message}");
            },
            () =>
            {
                Debug.Log($"Complete");
            });  // .AddTo(this);
    }
}
