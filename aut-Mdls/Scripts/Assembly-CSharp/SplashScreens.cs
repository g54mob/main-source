using System;
using System.Collections;
using System.Collections.Generic;
using Presentation.UI.Splash;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreens : MonoBehaviour
{
	[SerializeField]
	private List<BaseSplashScreen> _splashScreens;

	[SerializeField]
	private string _sceneToLoad = "StartScreen";

	[SerializeField]
	private GameObject _loadingScreen;

	private void Awake()
	{
		_loadingScreen.SetActive(value: false);
		PlayerPrefs.SetInt("Disclaimer202502", 0);
		for (int i = 0; i < _splashScreens.Count; i++)
		{
			_splashScreens[i].Initialize(i);
			BaseSplashScreen baseSplashScreen = _splashScreens[i];
			baseSplashScreen.OnSplashCompleted = (Action<int>)Delegate.Combine(baseSplashScreen.OnSplashCompleted, new Action<int>(OnSplashCompleted));
		}
	}

	private void OnDestroy()
	{
		for (int i = 0; i < _splashScreens.Count; i++)
		{
			BaseSplashScreen baseSplashScreen = _splashScreens[i];
			baseSplashScreen.OnSplashCompleted = (Action<int>)Delegate.Remove(baseSplashScreen.OnSplashCompleted, new Action<int>(OnSplashCompleted));
		}
	}

	private void Start()
	{
		ShowSplashScreen(0);
	}

	private void ShowSplashScreen(int index)
	{
		_splashScreens[index].Show();
	}

	private void OnSplashCompleted(int index)
	{
		if (index + 1 < _splashScreens.Count)
		{
			ShowSplashScreen(index + 1);
			return;
		}
		_loadingScreen.SetActive(value: true);
		StartCoroutine(LoadSceneAsync(_sceneToLoad));
	}

	private IEnumerator LoadSceneAsync(string sceneName)
	{
		yield return new WaitForSeconds(1f);
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
