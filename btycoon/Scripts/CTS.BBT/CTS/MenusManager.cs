using System;
using System.Collections;
using CTS.Core;
using CTS.UI;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace CTS
{
	public class MenusManager : MonoSingleton<MenusManager>
	{
		[SerializeField]
		private float _transitionDuration = 0.5f;

		[SerializeField]
		private MenuScreen _mainMenu;

		[SerializeField]
		private GameObject _bannerDemo;

		[SerializeField]
		private MapInfoSO _demoSandboxLevel;

		[SerializeField]
		private MenuScreen _loadingScreen;

		[SerializeField]
		private CanvasGroupController _menu;

		private CanvasGroupMove _menuMove;

		private MenuScreen _currentScreen;

		[SerializeField]
		private GameObject _splineVlad;

		private LockToggle _loadingScreenToggle;

		private SceneInstance? _currentRuntimeScene;

		public static event Action<bool> OnMainMenuShown;

		public static event Action OnLoadAdditiveScene;

		private void Start()
		{
			_loadingScreenToggle = new LockToggle(_loadingScreen);
			_currentScreen = _mainMenu;
			MenusManager.OnMainMenuShown?.Invoke(obj: true);
			_bannerDemo?.SetActive(value: false);
		}

		public void HideMenu()
		{
			if (_currentScreen == _mainMenu)
			{
				StartCoroutine(DisplayVlad(0.075f));
			}
		}

		private void DisplayMenu()
		{
			if (_currentScreen == _mainMenu)
			{
				_menu.QuickShow();
				StartCoroutine(DisplayVlad(0.075f));
			}
		}

		private IEnumerator DisplayVlad(float time)
		{
			yield return new WaitForSecondsRealtime(time);
			if (!_splineVlad.activeSelf)
			{
				_splineVlad.SetActive(value: true);
			}
			else
			{
				_splineVlad.SetActive(value: false);
			}
		}

		public Coroutine SwitchScene(SceneReference scene)
		{
			return StartCoroutine(SwitchSceneCoroutine(scene));
		}

		private IEnumerator SwitchSceneCoroutine(SceneReference scene)
		{
			_loadingScreenToggle.Lock();
			_mainMenu.Show(show: false);
			yield return _loadingScreen.WaitForTransition();
			if (_currentRuntimeScene.HasValue)
			{
				yield return Addressables.UnloadSceneAsync(_currentRuntimeScene.Value);
				yield return Coroutines.WaitForSecondsUnscaled(1f);
			}
			AsyncOperationHandle<SceneInstance> load = Addressables.LoadSceneAsync(scene.Address, LoadSceneMode.Additive, activateOnLoad: false);
			while (!load.IsDone)
			{
				yield return null;
			}
			_currentRuntimeScene = load.Result;
			yield return load.Result.ActivateAsync();
			SceneManager.SetActiveScene(load.Result.Scene);
			MenusManager.OnLoadAdditiveScene?.Invoke();
			yield return Coroutines.WaitForSecondsUnscaled(1f);
			_loadingScreenToggle.Unlock();
			yield return _loadingScreen.WaitForUnlock();
			yield return _loadingScreen.WaitForTransition();
			_currentScreen = null;
		}

		public void ShowMainMenu()
		{
			DoReturnToMenu();
		}

		public Coroutine DoReturnToMenu()
		{
			return StartCoroutine(ShowMainMenuCoroutine());
		}

		private IEnumerator ShowMainMenuCoroutine()
		{
			Time.timeScale = 1f;
			MenusManager.OnMainMenuShown?.Invoke(obj: true);
			_loadingScreenToggle.Lock();
			yield return _loadingScreen.WaitForTransition();
			MonoSingleton<MusicManager>.Instance.PlayMenuMusic();
			if (_currentRuntimeScene.HasValue)
			{
				yield return Addressables.UnloadSceneAsync(_currentRuntimeScene.Value);
				yield return Coroutines.WaitForSecondsUnscaled(1f);
			}
			_currentRuntimeScene = null;
			SceneManager.SetActiveScene(base.gameObject.scene);
			_loadingScreenToggle.Unlock();
			yield return _loadingScreen.WaitForUnlock();
			_mainMenu.Show(show: true);
			yield return _mainMenu.WaitForTransition();
		}

		public void ExitGame()
		{
			Application.Quit();
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
