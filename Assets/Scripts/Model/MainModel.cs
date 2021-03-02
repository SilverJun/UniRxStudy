using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Model
{
    public class MainModel
    {
        public ReactiveProperty<string> Title = new ReactiveProperty<string>();
        public ReactiveProperty<string> Content = new ReactiveProperty<string>();

        public async UniTask LoadMainContents()
        {
            Debug.Log("[LoadMainContents] Start");
            Content.Value = "Loading...";
            await UniTask.Delay(Random.Range(100, 1000));

            // ReSharper disable all StringLiteralTypo
            var randomText = new List<string>
            {
                "Hello MainView",
                "Test MainView",
                "ABCDEFG",
                "asdfasd",
                "inoaiwnf",
                "venoain",
                "aoiojweaf",
                "wpioenf",
                "aowihe"
            };
            Content.Value = randomText[Random.Range(0, randomText.Count)];
            Debug.Log("[LoadMainContents] Done");
        }
    }
}