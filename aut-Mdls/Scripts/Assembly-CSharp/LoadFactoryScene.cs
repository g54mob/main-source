using System;
using System.Collections;
using Presentation.UI.LoadingScreen;
using UnityEngine;
using Utils.SceneHandling;

public class LoadFactoryScene : MonoBehaviour
{
	[SerializeField]
	private string _factoryScene;

	[SerializeField]
	private LoadingProgressEnum _fromPercent;

	[SerializeField]
	private LoadingProgressEnum _toPercent = LoadingProgressEnum.FinishedLoadingScene;

	private IEnumerator Start()
	{
		yield return Resources.UnloadUnusedAssets();
		GC.Collect();
		SceneHandler.Instance.LoadScene(_factoryScene, _fromPercent, _toPercent);
	}
}
