#define PUG_RGB_ENABLED
using System;
using System.Collections;
using System.Collections.Generic;
using Pug.UnityExtensions;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadManager : ManagerBase
{
	private static class THREAD_PRIORITY_SETTINGS
	{
		public const ThreadPriority GAME_PRIORITY = ThreadPriority.Low;

		public const ThreadPriority LOAD_PRIORITY = ThreadPriority.High;
	}

	private class LoadingQueueEntry
	{
		public string sceneName;

		public float outTime;

		public float inTime;

		public CameraSceneFader.FadeSettings fadeSettings;

		public int priority;

		public LoadingQueueEntry(string sceneName, float outTime, float inTime, CameraSceneFader.FadeSettings fadeSettings, int priority)
		{
			this.sceneName = sceneName;
			this.outTime = outTime;
			this.inTime = inTime;
			this.fadeSettings = fadeSettings;
			this.priority = priority;
		}
	}

	private const float DISABLE_INPUT_ON_NEW_SCENE_TIME = 0.5f;

	public const string SCENE_NAME_LOADING = "Loading";

	public const string SCENE_NAME_TITLE = "Title";

	public const string SCENE_NAME_MULTIPLAYER_CHARACTER_SELECTION = "mp_CharacterSelection";

	public const string SCENE_NAME_MULTIPLAYER_LEVEL_SELECTION = "mp_LevelSelection";

	public const string SCENE_NAME_LAST_MAN_STANDING = "mp_LastManStanding";

	public const string SCENE_NAME_INTRO = "Intro";

	public const string SCENE_NAME_OUTRO = "Outro";

	public const string SCENE_NAME_GAME_OVER = "GameOver";

	public const string SCENE_NAME_START_SCENE = "Main";

	public const string SCENE_NAME_EDITOR = "ingame_editor";

	public const string SCENE_NAME_BENCHMARK = "Benchmark";

	private const string FOLDER_NAME_ALWAYS_LOADED = "AlwaysLoaded/";

	[NonSerialized]
	[ClearOnReload]
	public static bool instaFade = false;

	private LoadingQueueEntry loadingQueue;

	private readonly bool sceneFaderUseScaledTime = true;

	private float fadeInTime;

	private float fadeOutTime = 1f;

	private bool _quittingApplication;

	private Coroutine _waitForLoadingRoutine;

	private string errorExitReason;

	private Fader sceneFader = new Fader(0f, Fader.FadeFunction.Linear);

	private float sceneActivationTimeStamp;

	private bool sceneHandlerMarkedAsReady;

	private static readonly ProfilerMarker InitMarker = new ProfilerMarker("LoadManager.Init");

	private bool unloadedAlready;

	public float timeSinceSceneActivation => Time.time - sceneActivationTimeStamp;

	public string nameOfPreviousScene { get; private set; }

	public bool currentSceneWasReloaded => nameOfPreviousScene == GetNameOfCurrentScene();

	public event EventHandler Event_OnPreUnload;

	private void ProcessLoadingQueueAndLoadNextScene()
	{
		LoadingQueueEntry loadingQueueEntry = loadingQueue;
		loadingQueue = null;
		if (loadingQueueEntry != null)
		{
			LoadSceneImmediately(loadingQueueEntry, unloadCurrentSceneFirst: false);
			Manager.menu.PreventPausing(prevent: false);
		}
	}

	private float GetFaderTime()
	{
		if (!sceneFaderUseScaledTime)
		{
			return Time.unscaledTime;
		}
		return Time.time;
	}

	public bool IsApplicationQuitting()
	{
		return _quittingApplication;
	}

	public float GetFadeValue()
	{
		return Mathf.Clamp01(sceneFader.GetFadeValue() * 1.01f - 0.01f);
	}

	public Fader.FadeDirection GetFadeDirection()
	{
		return sceneFader.GetFadeDirection();
	}

	public void MakeSceneHandlerReady()
	{
		sceneHandlerMarkedAsReady = true;
	}

	public string GetNameOfCurrentScene()
	{
		return SceneManager.GetActiveScene().name;
	}

	public string GetNameOfNextScene()
	{
		return loadingQueue?.sceneName;
	}

	public override bool Init()
	{
		using (InitMarker.Auto())
		{
			Resources.LoadAll("AlwaysLoaded/");
			sceneFader = new Fader(0f, Fader.FadeFunction.Linear, GetFaderTime());
			SceneManager.sceneLoaded += OnSceneLoaded;
			sceneActivationTimeStamp = Time.time;
			return true;
		}
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
	{
	}

	private void OnDestroy()
	{
		if (_quittingApplication)
		{
			Debug.LogError("LoadManager.OnApplicationQuit() called twice!");
			return;
		}
		_quittingApplication = true;
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		for (int i = 0; i < rootGameObjects.Length; i++)
		{
			UnityEngine.Object.DestroyImmediate(rootGameObjects[i]);
		}
	}

	private void Update()
	{
		sceneFader.UpdateFadeValue(GetFaderTime());
	}

	private void LateUpdate()
	{
		if (!IsApplicationQuitting())
		{
			if (IsLoadingAndScreenBlack() && Manager.ecs.CanUnloadScene())
			{
				SetCpuLoadPriority(prioritizeLoading: true);
				UnloadCurrentScene();
				ProcessLoadingQueueAndLoadNextScene();
			}
			else if (sceneHandlerMarkedAsReady)
			{
				sceneHandlerMarkedAsReady = false;
				SetCpuLoadPriority(prioritizeLoading: false);
				FadeIn();
			}
		}
	}

	public static void SetCpuLoadPriority(bool prioritizeLoading)
	{
		Application.backgroundLoadingPriority = (prioritizeLoading ? ThreadPriority.High : ThreadPriority.Low);
	}

	private void LoadSceneImmediately(LoadingQueueEntry entry, bool unloadCurrentSceneFirst)
	{
		fadeInTime = entry.inTime;
		fadeOutTime = entry.outTime;
		Manager.camera.gameCameraSceneFader.SetFadeSettings(entry.fadeSettings);
		sceneFader.ReInit(0f, sceneFader.fadeFunction, GetFaderTime());
		FadeOut();
		if (unloadCurrentSceneFirst)
		{
			UnloadCurrentScene();
		}
		SetCpuLoadPriority(prioritizeLoading: true);
		SceneManager.LoadScene(entry.sceneName, LoadSceneMode.Single);
		unloadedAlready = false;
		SetCpuLoadPriority(prioritizeLoading: false);
		StartCoroutine(ImmediateSceneLoadCompleted(entry));
	}

	public void LoadMainScene()
	{
		Manager.menu.PopAllMenus();
		Manager.camera.ShowHUD(show: false);
		float num = 2f;
		Manager.music.FadeOutVolume(num);
		Manager.load.QueueScene("Main", num, 1.5f, FadePresets.blackToBlack);
	}

	public void LoadIntroScene()
	{
		Manager.menu.PopAllMenus();
		Manager.camera.ShowHUD(show: false);
		float num = 2f;
		Manager.music.FadeOutVolume(num);
		Manager.load.QueueScene("Intro", num, 1.5f, FadePresets.blackToBlack);
	}

	public void ExitGame()
	{
		ExitGame(FadePresets.blackToBlack);
	}

	public void ExitGame(CameraSceneFader.FadeSettings fadeSettings)
	{
		if (Manager.load.IsLoading())
		{
			Debug.Log("LoadManager.ExitGame: Waiting for loading before exiting game.");
			if (_waitForLoadingRoutine == null)
			{
				_waitForLoadingRoutine = StartCoroutine(WaitLoadingBeforeExit(fadeSettings));
			}
			return;
		}
		Manager.menu.PopAllMenus();
		if (Manager.sceneHandler.isInGame)
		{
			Debug.Log("LoadManager.ExitGame: Exiting from inGame.");
			Manager.music.FadeOutVolume(1.4f);
			if (Manager.sceneHandler != null)
			{
				Manager.sceneHandler.playerWantsToExitToTitle = true;
				return;
			}
			Manager.load.QueueScene("Title", 1f, 0.5f, fadeSettings, setFadeValueTo1: false, 1);
			PlayerController player = Manager.main.player;
			if (player != null)
			{
				player.SetInvincibility(value: true);
				player.inputModule.DisableInputFor();
			}
		}
		else if (Manager.sceneHandler.isIntro)
		{
			Debug.Log("LoadManager.ExitGame: Exiting from intro.");
			Manager.load.QueueScene("Title", 1f, 0.5f, fadeSettings, setFadeValueTo1: false, 1);
		}
		else if (Manager.sceneHandler.isTitle)
		{
			Debug.Log("LoadManager.ExitGame: Exiting from title scene.");
			Manager.ecs.CancelECSWorldConversionOrUnloadWorlds();
		}
	}

	public void ExitGameOnNetworkError(string reason)
	{
		ExitGameOnNetworkError(reason, FadePresets.cut);
	}

	public void ExitGameOnNetworkError(string reason, CameraSceneFader.FadeSettings fadeSettings)
	{
		if (reason == errorExitReason)
		{
			Debug.Log(string.Format("{0}.{1}: Same network error has already been handled for exiting game.", this, "ExitGameOnNetworkError"));
			return;
		}
		errorExitReason = reason;
		Manager.networking.connectionFailedReason = reason;
		Manager.networking.connectionFailed = true;
		ExitGame(fadeSettings);
		if (Manager.sceneHandler != null && Manager.sceneHandler.isTitle)
		{
			DisplayErrorExitReason();
		}
	}

	private IEnumerator WaitLoadingBeforeExit(CameraSceneFader.FadeSettings fadeSettings)
	{
		yield return new WaitWhile(() => Manager.load.IsLoading());
		_waitForLoadingRoutine = null;
		Manager.load.ExitGame(fadeSettings);
	}

	private IEnumerator ImmediateSceneLoadCompleted(LoadingQueueEntry loadedEntry)
	{
		if (loadedEntry.sceneName == "Title" && errorExitReason != null)
		{
			yield return null;
			DisplayErrorExitReason();
		}
	}

	private void DisplayErrorExitReason()
	{
		string[] formatFields = new string[1] { "unsupported" };
		Manager.menu.centerPopUpText.StartNewDisplaySequence(errorExitReason, formatFields, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
		{
		}, new List<string> { "ok" }, 10f, 0f, 0, 20f);
		errorExitReason = null;
	}

	public void LoadBenchmarkScene()
	{
		Manager.menu.PopAllMenus();
		Manager.camera.ShowHUD(show: false);
		float num = 0f;
		Manager.music.FadeOutVolume(num);
		Manager.load.QueueScene("Benchmark", num, 0f, FadePresets.blackToBlack);
	}

	public void QueueScene(string sceneName, float outTime, float inTime, CameraSceneFader.FadeSettings fadeSettings, bool setFadeValueTo1 = false, int priority = 0)
	{
		if (!IsLoadingAndScreenBlack() && !IsScreenFadingOut())
		{
			fadeInTime = inTime;
			fadeOutTime = outTime;
			Manager.camera.gameCameraSceneFader.SetFadeSettings(fadeSettings);
			if (setFadeValueTo1)
			{
				sceneFader.ReInit(1f, sceneFader.fadeFunction, GetFaderTime());
			}
			Manager.menu.PreventPausing(prevent: true);
			Manager.input.DisableInput(fadeInTime + Math.Min(fadeOutTime, 0.5f));
			FadeOut();
		}
		if (loadingQueue == null || priority > loadingQueue.priority)
		{
			loadingQueue = new LoadingQueueEntry(sceneName, outTime, inTime, fadeSettings, priority);
		}
		else if (priority == loadingQueue.priority && sceneName.CompareTo(loadingQueue.sceneName) < 0)
		{
			loadingQueue = new LoadingQueueEntry(sceneName, outTime, inTime, fadeSettings, priority);
		}
		Manager.ecs.OnEarlySceneUnload();
	}

	public void FadeIn(float inTime, CameraSceneFader.FadeSettings fadeSettings)
	{
		if (loadingQueue != null)
		{
			Debug.LogWarning("Not fading in since we are awaiting new scene load");
			return;
		}
		fadeInTime = inTime;
		Manager.camera.gameCameraSceneFader.SetFadeSettings(fadeSettings);
		FadeIn();
	}

	public void FadeOut(float outTime, CameraSceneFader.FadeSettings fadeSettings)
	{
		fadeOutTime = outTime;
		Manager.camera.gameCameraSceneFader.SetFadeSettings(fadeSettings);
		FadeOut();
	}

	private void FadeIn(bool fadeAudio = true)
	{
		float num = fadeInTime;
		if (fadeAudio)
		{
			Manager.audio.FadeInAudioEffects();
		}
		Manager.audio.FadeInAudioAmbient(num);
		sceneFader.FadeIn(num, GetFaderTime());
		Manager.camera.gameCameraSceneFader.OnFadeChange(isFadeIn: true, GetFadeValue());
	}

	private void FadeOut()
	{
		Manager.ui.FadeOutAllGameplayUI();
		Manager.ui.FadeOutMouse();
		float num = fadeOutTime;
		Manager.audio.FadeOutAudioAmbient(num);
		sceneFader.FadeOut(num, GetFaderTime());
		Manager.camera.gameCameraSceneFader.OnFadeChange(isFadeIn: false, GetFadeValue());
	}

	public void UnloadCurrentScene()
	{
		if (unloadedAlready)
		{
			Debug.LogWarning("UnloadCurrentScene called as the scene was already unloaded!");
			return;
		}
		this.Event_OnPreUnload?.Invoke(this, EventArgs.Empty);
		this.Event_OnPreUnload = null;
		nameOfPreviousScene = GetNameOfCurrentScene();
		try
		{
			Manager.ui?.OnSceneUnload();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		try
		{
			Manager.menu?.OnSceneUnload();
		}
		catch (Exception exception2)
		{
			Debug.LogException(exception2);
		}
		try
		{
			Manager.text?.OnSceneUnload();
		}
		catch (Exception exception3)
		{
			Debug.LogException(exception3);
		}
		try
		{
			Manager.effects?.OnSceneUnload();
		}
		catch (Exception exception4)
		{
			Debug.LogException(exception4);
		}
		try
		{
			Manager.camera?.OnSceneUnload();
		}
		catch (Exception exception5)
		{
			Debug.LogException(exception5);
		}
		try
		{
			Manager.ecs.OnSceneUnload();
		}
		catch (Exception exception6)
		{
			Debug.LogException(exception6);
		}
		try
		{
			Manager.memory.OnSceneUnload();
		}
		catch (Exception exception7)
		{
			Debug.LogException(exception7);
		}
		try
		{
			Manager.saves?.OnSceneUnload();
		}
		catch (Exception exception8)
		{
			Debug.LogException(exception8);
		}
		try
		{
			Manager.filesystemManager.OnSceneUnload();
		}
		catch (Exception exception9)
		{
			Debug.LogException(exception9);
		}
		try
		{
			Manager.rgb.OnSceneUnload();
		}
		catch (Exception exception10)
		{
			Debug.LogException(exception10);
		}
		Orphanable.ReparentOrphansInScene(SceneManager.GetActiveScene());
		Manager.audio?.FreeLoopingClips();
		Manager.main.currentSceneHandler = null;
		unloadedAlready = true;
	}

	public bool IsSceneTransitionOrLoading()
	{
		if (!IsScreenFadingIn() && !IsScreenFadingOut() && !IsLoadingAndScreenBlack())
		{
			return IsScreenBlack();
		}
		return true;
	}

	public bool IsLoading()
	{
		return loadingQueue != null;
	}

	public bool IsLoadingAndScreenBlack()
	{
		if (IsScreenBlack())
		{
			return loadingQueue != null;
		}
		return false;
	}

	public bool IsScreenBlack()
	{
		return GetFadeValue() < 0.001f;
	}

	public bool IsScreenFadingOut()
	{
		return GetFadeDirection() == Fader.FadeDirection.Out;
	}

	public bool IsScreenFadingIn()
	{
		return GetFadeDirection() == Fader.FadeDirection.In;
	}

	public bool IsScreenFadingOutOrBlack()
	{
		if (!IsScreenFadingOut())
		{
			return IsScreenBlack();
		}
		return true;
	}

	public bool IsScreenFadingInOrBlack()
	{
		if (!IsScreenFadingIn())
		{
			return IsScreenBlack();
		}
		return true;
	}

	public static void DeltaLoadMapInBuildSettings(int delta)
	{
		int num = SceneManager.GetActiveScene().buildIndex + delta;
		num %= SceneManager.sceneCountInBuildSettings;
		if (Application.isPlaying)
		{
			string sceneName = SceneManager.GetSceneByBuildIndex(num).name;
			Manager.load.QueueScene(sceneName, 0.1f, 0.1f, FadePresets.blackToBlack);
		}
		Debug.LogError("LoadManager.DeltaLoadMapInBuildSettings not tested for non-editor map-changing.");
	}
}
