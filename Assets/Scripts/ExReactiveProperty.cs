using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class ExReactiveProperty : MonoBehaviour
{
    ReactiveProperty<int> _property = new ReactiveProperty<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        _property
            .Subscribe()
            .AddTo(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
