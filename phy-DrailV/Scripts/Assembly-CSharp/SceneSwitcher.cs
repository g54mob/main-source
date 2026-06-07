using System;
using System.Collections;
using System.Diagnostics;
using DV;
using DV.Hacks;
using DV.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	private const float SWITCH_SCENE_TIME_WAIT = 0.05f;

	private static int nextSceneToLoad = -1;

	private static bool unpauseAudio = false;

	public static bool IsInGameWorld => IsInGameWorldScene(SceneManager.GetActiveScene().name);

	public static event Action<DVScenes> SceneRequested;

	private void Awake()
	{
		UnloadWatcher.ClearFlag();
		int num;
		if (nextSceneToLoad < 0)
		{
			num = SceneManager.GetActiveScene().buildIndex + 1;
			UnityEngine.Debug.Log(string.Format("[{0}] no queued scene, switching to next scene with index {1} (nextSceneToLoad was {2})", "SceneSwitcher", num, nextSceneToLoad));
		}
		else
		{
			UnityEngine.Debug.Log(string.Format("[{0}] switching to queued scene with index {1}", "SceneSwitcher", nextSceneToLoad));
			num = nextSceneToLoad;
		}
		if (unpauseAudio)
		{
			unpauseAudio = false;
			AudioListener.pause = false;
			AudioListener.volume = AudioManager.GetTargetVolumeForCurrentPreferenceValue();
		}
		nextSceneToLoad = -1;
		LoadScene(num);
	}

	private static bool IsInGameWorldScene(string sceneName)
	{
		if (string.IsNullOrEmpty(sceneName))
		{
			return false;
		}
		sceneName = sceneName.ToLower();
		if (!sceneName.StartsWith("bootstrap"))
		{
			return !sceneName.StartsWith("mainmenu");
		}
		return false;
	}

	public static void SwitchToScene(DVScenes enumVal)
	{
		SceneSwitcher.SceneRequested?.Invoke(enumVal);
		SwitchToScene((int)enumVal);
	}

	private static void SwitchToScene(int index)
	{
		if (UnloadWatcher.isUnloading)
		{
			UnityEngine.Debug.LogError("Cannot switch scenes, it is already unloading!");
			return;
		}
		SingletonBehaviour<CoroutineManager>.Instance.Run(WaitButtonRefresh(delegate
		{
			nextSceneToLoad = index;
			UnloadWatcher.RequestUnload();
			if (IsInGameWorld)
			{
				AssetBundle.UnloadAllAssetBundles(unloadAllObjects: true);
				Globals.G.ClearGameParamsOverride();
				unpauseAudio = true;
			}
			LoadScene(2);
		}));
	}

	private static IEnumerator WaitButtonRefresh(Action endAction)
	{
		yield return WaitFor.SecondsRealtime(0.05f);
		BlackoutScreen.Blackout(endAction);
	}

	public static void ReloadCurrentScene(bool reloadLocalization = false)
	{
		nextSceneToLoad = SceneManager.GetActiveScene().buildIndex;
		UnloadWatcher.RequestUnload();
		UnityEngine.Debug.Log(string.Format("[{0}] queued up to reload current scene with index {1} (reloadLocalization: {2})", "SceneSwitcher", nextSceneToLoad, reloadLocalization));
		LoadScene(reloadLocalization ? 1 : 2);
	}

	public static void QuitGame()
	{
		if (UnloadWatcher.isUnloading)
		{
			UnityEngine.Debug.LogError("Cannot quit game, it is already unloading!");
			return;
		}
		SingletonBehaviour<CoroutineManager>.Instance.Run(WaitButtonRefresh(delegate
		{
			UnityEngine.Debug.Log("[SceneSwitcher] quit");
			Application.Quit();
		}));
	}

	internal static void BootstrapToNextScene()
	{
		int num = SceneManager.GetActiveScene().buildIndex + 1;
		UnityEngine.Debug.Log(string.Format("[{0}] bootstrapping to next scene with index {1}", "SceneSwitcher", num));
		LoadScene(num);
	}

	private static void LoadScene(int index)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(index);
	}

	[Conditional("UNITY_EDITOR")]
	private void WarnIfScenesAreOutOfSync()
	{
	}
}
