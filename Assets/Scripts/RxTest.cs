using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class RxTest : MonoBehaviour
{
    private Subject<Unit> _testStream = new Subject<Unit>();
    
    // Start is called before the first frame update
    void Start()
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
            });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _testStream.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _testStream.OnError(new Exception("E has been pressed."));
        }
    }
}
