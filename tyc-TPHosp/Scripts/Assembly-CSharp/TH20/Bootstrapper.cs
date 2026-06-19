using System.Collections;
using Steamworks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TH20
{
	public class Bootstrapper : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _loadingSpinnerTransform;

		[SerializeField]
		private float _loadingSpinnerRotationSpeedDegreesPerSecond = 360f;

		[SerializeField]
		private AppAudioMixerManagerConfig _appAudioMixerManagerConfig;

		private static void MacBlackScreenWorkAround()
		{
			string[] array = SystemInfo.operatingSystem.Split(' ');
			if (array != null && array.Length >= 1 && !(array[0] != "Mac"))
			{
				string[] array2 = array[3].Split('.');
				if (array2 != null && array2.Length >= 2 && !(array2[0] != "10") && (array2[1] == "10" || array2[1] == "12"))
				{
					Screen.fullScreenMode = FullScreenMode.Windowed;
					UnityEngine.Debug.Log("MacBlackScreenWorkAround");
				}
			}
		}

		private void Awake()
		{
			if (!SteamOSManager.QuitIfNotOnSteam())
			{
				MacBlackScreenWorkAround();
				StartCoroutine(LoadMainScene());
			}
		}

		private IEnumerator PreparePlayer()
		{
			ThreadingUtils.Initialise();
			OSManager.Initialise();
			while (!OSManager.IsInitialised())
			{
				OSManager.Update();
				yield return null;
			}
			PlatformFileManager.Initialise();
			Directories.Initialise();
			Preferences.LoadOrCreateNew(OSManager.GetLanguage(), null);
			new AppAudioMixerManager(LocalPreferences.LoadOrCreateNew(), _appAudioMixerManagerConfig).Destroy();
			bool num = Application.platform == RuntimePlatform.OSXPlayer && Screen.fullScreen;
			bool flag = OnlineManager.IsInitialized() && SteamUtils.IsSteamInBigPictureMode();
			if (flag)
			{
				UnityEngine.Debug.Log("Game is booting into Big Picture mode. Forcing into fullscreen mode");
			}
			if (num)
			{
				UnityEngine.Debug.Log("Game is booting into fullscreen on mac. Ensure we are using a valid resolution");
			}
			if (num || flag)
			{
				UnityEngine.Debug.Log("Forcing game into fullscreen mode at a valid resolution");
				Resolution[] array = ResolutionUtils.SortAndFilterResolutions(Screen.resolutions);
				int num2 = ResolutionUtils.CurrentOrClosestResolutionIndex(array);
				Screen.SetResolution(array[num2].width, array[num2].height, fullscreen: true, array[num2].refreshRate);
			}
		}

		private IEnumerator LoadMainScene()
		{
			UnityEngine.Debug.Log("Bootstrapper: Starting; loading SplashScreen");
			yield return PreparePlayer();
			yield return null;
			yield return null;
			if (Application.platform == RuntimePlatform.LinuxPlayer)
			{
				yield return new WaitForSecondsRealtime(0.5f);
			}
			AsyncOperation loadOperation = SceneManager.LoadSceneAsync("SplashScreen", LoadSceneMode.Single);
			loadOperation.allowSceneActivation = false;
			while (loadOperation.progress < 0.9f)
			{
				_loadingSpinnerTransform.Rotate(0f, 0f, (0f - _loadingSpinnerRotationSpeedDegreesPerSecond) * Time.unscaledDeltaTime);
				yield return null;
			}
			UnityEngine.Debug.Log("Bootstrapper: SplashScreen loaded; finalising load, and unloading Bootstrapper");
			loadOperation.allowSceneActivation = true;
			yield return loadOperation;
		}
	}
}
