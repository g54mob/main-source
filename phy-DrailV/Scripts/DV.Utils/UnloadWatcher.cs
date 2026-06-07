using System;
using DV.Utils;
using UnityEngine;
using UnityEngine.CrashReportHandler;
using UnityEngine.SceneManagement;

public class UnloadWatcher : SingletonBehaviour<UnloadWatcher>
{
	public static bool isUnloading { get; private set; }

	public static bool isQuitting { get; private set; }

	public static event Action UnloadRequested;

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void ClearStaticState()
	{
		isUnloading = false;
		isQuitting = false;
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Init()
	{
		UnityEngine.Object.DontDestroyOnLoad(SingletonBehaviour<UnloadWatcher>.Instance.gameObject);
	}

	public new static string AllowAutoCreate()
	{
		return "[UnloadWatcher]";
	}

	protected override void Awake()
	{
		base.Awake();
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene _, LoadSceneMode loadMode)
	{
		isUnloading = false;
	}

	private void OnApplicationQuit()
	{
		isQuitting = true;
		Debug.Log("Application quit requested on scene " + SceneManager.GetActiveScene().name);
		RequestUnload();
		CrashReportHandler.enableCaptureExceptions = false;
	}

	public static void RequestUnload()
	{
		Debug.Log("RequestUnload on scene " + SceneManager.GetActiveScene().name);
		isUnloading = true;
		try
		{
			UnloadWatcher.UnloadRequested?.Invoke();
		}
		catch (Exception exception)
		{
			Debug.LogError("The following exception was caught while firing UnloadWatcher.UnloadRequested event");
			Debug.LogException(exception);
		}
	}

	public static void ClearFlag()
	{
		isUnloading = false;
	}
}
