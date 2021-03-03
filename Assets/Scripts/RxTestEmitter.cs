using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RxTestEmitter : MonoBehaviour
{ 
    public RxTest RxTest;
    public Image image;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RxTest._testStream.OnNext(Unit.Default);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RxTest._testStream.OnError(new Exception("E has been pressed."));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RxTest.gameObject.SetActive(!RxTest.gameObject.activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Scenes/SampleScene");
        }
    }
}
