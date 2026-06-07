using DV.Common;
using DV.UI.PresetEditors;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DV.UI
{
	[RequireComponent(typeof(AudioSource))]
	public class MainMenuMusicFadeout : NullCheckingMonoBehaviour
	{
		[NullCheck]
		public MainMenuController mainMenuController;

		private AudioSource audioSource;

		private float fadeDuration = 2f;

		private bool fadingOut;

		private string N => "[" + GetType().Name + "]";

		private void Start()
		{
			audioSource = GetComponent<AudioSource>();
			if (audioSource == null || mainMenuController == null)
			{
				Debug.LogError(N + " could not find AudioSource or MainMenuController, destroying self.");
				Object.Destroy(this);
				return;
			}
			audioSource.ignoreListenerVolume = true;
			base.transform.SetParent(null);
			Object.DontDestroyOnLoad(base.gameObject);
			mainMenuController.StartNewGameRequested += OnStartNewGameRequested;
			mainMenuController.ContinueGameRequested += OnContinueGameRequested;
			SceneManager.sceneUnloaded += OnSceneUnloaded;
		}

		private void OnDestroy()
		{
			SceneManager.sceneUnloaded -= OnSceneUnloaded;
			WorldStreamingInit.LoadingStatusChanged -= OnLoadingStatusChanged;
			if ((bool)mainMenuController)
			{
				mainMenuController.StartNewGameRequested -= OnStartNewGameRequested;
				mainMenuController.ContinueGameRequested -= OnContinueGameRequested;
			}
		}

		private void OnContinueGameRequested(ISaveGame _)
		{
			FadeoutDuringLoadingScreen();
		}

		private void OnStartNewGameRequested(UIStartGameData _)
		{
			FadeoutDuringLoadingScreen();
		}

		private void OnSceneUnloaded(Scene _)
		{
			FadeoutImmediately();
		}

		private void FadeoutDuringLoadingScreen()
		{
			Debug.Log(N + " waiting for loading screen progress");
			OnDestroy();
			WorldStreamingInit.LoadingStatusChanged += OnLoadingStatusChanged;
		}

		private void OnLoadingStatusChanged(string _, bool isError, float percentageLoaded)
		{
			if (isError || percentageLoaded >= 85f)
			{
				WorldStreamingInit.LoadingStatusChanged -= OnLoadingStatusChanged;
				fadeDuration = 6f;
				FadeoutImmediately();
			}
		}

		private void FadeoutImmediately()
		{
			Debug.Log(N + " starting fade-out");
			OnDestroy();
			fadingOut = true;
			base.gameObject.AddComponent<Interpolator>().Interpolate(audioSource.volume, 0f, fadeDuration, delegate(float volume)
			{
				audioSource.volume = volume;
			});
		}

		private void Update()
		{
			if (fadingOut && audioSource.volume <= 0.01f)
			{
				Debug.Log(N + " destroying main menu music");
				Object.Destroy(base.gameObject);
			}
		}
	}
}
