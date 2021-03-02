using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Model;
using UniRx;
using UnityEngine;

public class MainViewContext : MonoBehaviour
{
    private MainView  _mainView;
    private MainModel _model;
    public GameObject ViewObject;

    public MainModel Model => _model ?? (_model = new MainModel());

    public MainView View => _mainView ? _mainView : (_mainView = GetComponent<MainView>());

    // Start is called before the first frame update
    void Start()
    {
        // Initialize
        Model.Title.Value = "Main";
        Model.Content.Value = "";
        
        // Bindings
        Model.Title
            .DistinctUntilChanged()
            .SubscribeToText(View.Text)
            .AddTo(this);

        Model.Content
            .DistinctUntilChanged()
            .SubscribeToText(View.Content)
            .AddTo(this);

        View.Button
            .OnClickAsObservable()
            .Do(_ => Debug.Log("Button Clicked!"))
            .Take(1)
            .SelectMany(_ => Model.LoadMainContents().ToObservable())
            .Repeat()
            .Subscribe(_ =>
            {
                Debug.Log($"Done");
            })
            .AddTo(this);

        // var isButtonClicked = false;
        //
        // View.Button
        //     .OnClickAsObservable()
        //     .Where(_ => isButtonClicked == false)
        //     .Do(_ =>
        //     {
        //         Debug.Log("Button Clicked!");
        //         isButtonClicked = true;
        //     })
        //     .SelectMany(_ => Model.LoadMainContents().ToObservable())
        //     .Subscribe(_ =>
        //     {
        //         Debug.Log($"Done");
        //         isButtonClicked = false;
        //     })
        //     .AddTo(this);
    }
}
