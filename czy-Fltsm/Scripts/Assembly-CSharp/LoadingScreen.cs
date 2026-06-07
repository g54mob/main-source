using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using M4.Session;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	[Header("Scene References")]
	[SerializeField]
	private GameObject _loadingFailedLabel;

	[SerializeField]
	private RectTransform _bar;

	[SerializeField]
	private GameObject _mainMenuButton;

	[SerializeField]
	private Button _submitBrokenSaveReportButton;

	[SerializeField]
	private BrokenSaveReport _brokenSaveFileReport;

	[SerializeField]
	private Tooltip _reportButtonTooltip;

	private static LoadingScreen _instance;

	private static bool _isRunningTasks;

	private List<ILoadingTask> _rootTasks;

	private List<ILoadingTask> _subtasks;

	public static bool IsLoading { get; private set; }

	private void Awake()
	{
		if (_instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		_instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		GameEventDispatcher.AddListener(GameEventType.LoadingUpdateLabel, OnLoadingEvent);
		_rootTasks = new List<ILoadingTask>();
		_mainMenuButton.SetActive(value: false);
		_submitBrokenSaveReportButton.gameObject.SetActive(value: false);
		_loadingFailedLabel.SetActive(value: false);
		SetProgress(0f);
	}

	private void OnDestroy()
	{
		GameEventDispatcher.RemoveListener(GameEventType.LoadingUpdateLabel, OnLoadingEvent);
	}

	public static void LoadScene(string sceneName)
	{
		ReturnInstance().Load(sceneName);
	}

	public static void LoadTask(UnityAction callback, Color fadeColor, float fadeDuration, string debugId = null)
	{
		ReturnInstance().Load(callback, fadeColor, fadeDuration, debugId);
	}

	public static void UpdateLabel(string label)
	{
		if (!(_instance == null) || IsLoading)
		{
			if (_isRunningTasks)
			{
				_instance._subtasks.Add(new LoadingTaskUpdateLabel(label));
			}
			else
			{
				_instance._rootTasks.Add(new LoadingTaskUpdateLabel(label));
			}
		}
	}

	public static void AddTask(UnityAction callback, string debugId = null)
	{
		if (_instance == null || !IsLoading)
		{
			Settings.InvokeOnInitialized(callback);
		}
		else if (_isRunningTasks)
		{
			_instance._subtasks.Add(new LoadingTask(callback, debugId));
		}
		else
		{
			_instance._rootTasks.Add(new LoadingTask(callback, debugId));
		}
	}

	public static void AddEnumeratorTask(UnityAction<int> callback, int count)
	{
		if (count <= 0)
		{
			return;
		}
		if (_instance == null || !IsLoading)
		{
			for (int i = 0; i < count; i++)
			{
				callback(i);
			}
		}
		else if (_isRunningTasks)
		{
			_instance._subtasks.Add(new LoadingTaskEnumerator(callback, count));
		}
		else
		{
			_instance._rootTasks.Add(new LoadingTaskEnumerator(callback, count));
		}
	}

	public static void AddSubTask(ILoadingTask task)
	{
		if (_isRunningTasks)
		{
			_instance._subtasks.Add(task);
		}
	}

	public static void FallbackGameStart()
	{
		if (_instance == null)
		{
			CoroutineMotor coroutineMotor = new GameObject().AddComponent<CoroutineMotor>();
			coroutineMotor.StartCoroutine(FallbackGameStartCoroutine(coroutineMotor));
		}
	}

	private static IEnumerator FallbackGameStartCoroutine(MonoBehaviour behaviour)
	{
		yield return new WaitForEndOfFrame();
		GameEvent.Dispatch(GameEventType.GameStart);
		UnityEngine.Object.Destroy(behaviour.gameObject);
	}

	public static LoadingScreen ReturnInstance()
	{
		if (_instance == null)
		{
			UnityEngine.Object.Instantiate(Resources.Load<LoadingScreen>("Game Prefabs/GUI/LoadingScreen"));
			if (_instance == null)
			{
				throw new NotSupportedException("_instance should no longer be null");
			}
		}
		return _instance;
	}

	public void MainMenuButtonClick()
	{
		_mainMenuButton.SetActive(value: false);
		_submitBrokenSaveReportButton.gameObject.SetActive(value: false);
		PersistenceManager.ClearSnapShot();
		Session.Profile.EndRun();
	}

	public void SubmitBrokenSaveReportClick()
	{
		_submitBrokenSaveReportButton.interactable = false;
		_brokenSaveFileReport.Submit(OnBrokenSaveReportSucceeded, OnBrokenSaveReportFailed);
	}

	public void Load(string sceneName)
	{
		if (IsLoading)
		{
			UnityEngine.Debug.LogErrorFormat("Unable to load scene '{0}'. The Loading screen is already loading something else!", sceneName);
			return;
		}
		IsLoading = true;
		_loadingFailedLabel.SetActive(value: false);
		SetProgress(0f);
		base.gameObject.SetActive(value: true);
		StartCoroutine(LoadSceneCoroutine(sceneName));
	}

	public void Load(UnityAction callback, Color fadeColor, float fadeDuration, string debugId)
	{
		if (IsLoading)
		{
			throw new NotSupportedException();
		}
		IsLoading = true;
		_loadingFailedLabel.SetActive(value: false);
		SetProgress(0f);
		_rootTasks.Add(new LoadingTask(callback, debugId));
		if (!base.gameObject.activeInHierarchy)
		{
			Fade.InOut(fadeColor, fadeDuration, delegate
			{
				base.gameObject.SetActive(value: true);
			}, delegate
			{
				StartCoroutine(LoadingTaskCoroutine(fadeColor, fadeDuration));
			});
		}
		else
		{
			StartCoroutine(LoadingTaskCoroutine(fadeColor, fadeDuration));
		}
	}

	private IEnumerator LoadSceneCoroutine(string sceneName)
	{
		GameEvent.Dispatch(GameEventType.GameStartedLoading);
		GameEventDispatcher.RemoveAllGameEventListeners();
		while (!Settings.IsInitialized)
		{
			yield return null;
		}
		Session.Profile.BeginRun();
		yield return null;
		yield return AsyncOperationCoroutine(SceneManager.LoadSceneAsync(sceneName), 0.05f, 0.05f);
		yield return null;
		yield return RunRootTasksCoroutine();
		yield return AsyncOperationCoroutine(Resources.UnloadUnusedAssets(), 0.95f, 1f);
		GC.Collect();
		_rootTasks.Clear();
		_subtasks.Clear();
		base.gameObject.SetActive(value: false);
		IsLoading = false;
		GameEventDispatcher.Dispatch(GameEventType.LoadingCompleted);
		GameEvent.Dispatch(GameEventType.GameStart);
	}

	private IEnumerator LoadingTaskCoroutine(Color fadeColor, float fadeDuration)
	{
		yield return RunRootTasksCoroutine();
		Fade.InOut(fadeColor, fadeDuration, delegate
		{
			base.gameObject.SetActive(value: false);
		}, delegate
		{
			IsLoading = false;
			GameEventDispatcher.Dispatch(GameEventType.LoadingCompleted);
		});
	}

	private IEnumerator AsyncOperationCoroutine(AsyncOperation operation, float progress, float progressIncrease, float cutoff = 1f)
	{
		while (operation.progress < cutoff)
		{
			SetProgress(progress + operation.progress * progressIncrease);
			yield return null;
		}
		SetProgress(progress + progressIncrease);
	}

	private IEnumerator RunRootTasksCoroutine()
	{
		if (0 < _rootTasks.Count)
		{
			_isRunningTasks = true;
			yield return RunTasksCoroutine(_rootTasks, 0.05f, 0.95f);
			_isRunningTasks = false;
			yield return null;
		}
	}

	private IEnumerator RunTasksCoroutine(List<ILoadingTask> tasks, float progressMin = 0f, float progressMax = 1f)
	{
		float num = 0f;
		float progress = progressMin;
		Stopwatch stopwatch = new Stopwatch();
		List<ILoadingTask> subtasks = ListPool<ILoadingTask>.Get();
		foreach (ILoadingTask task2 in tasks)
		{
			num += (float)task2.Weight;
		}
		float progressStep = (progressMax - progressMin) / num;
		foreach (ILoadingTask task in tasks)
		{
			if (0 < subtasks.Count)
			{
				throw new NotSupportedException("Subtasks should be empty!");
			}
			_subtasks = subtasks;
			while (true)
			{
				try
				{
					if (!task.Run())
					{
						break;
					}
				}
				catch (Exception exception)
				{
					OnException(exception);
					yield break;
				}
				stopwatch.Restart();
				if (subtasks.Count == 0)
				{
					yield return null;
				}
				else
				{
					yield return RunTasksCoroutine(subtasks, progress, progress + progressStep);
					if (0 < subtasks.Count)
					{
						throw new NotSupportedException("Subtasks should be empty!");
					}
					_subtasks = subtasks;
				}
				stopwatch.Stop();
				LoadingScreen loadingScreen = this;
				float progress2;
				progress = (progress2 = progress + progressStep);
				loadingScreen.SetProgress(progress2);
			}
		}
		tasks.Clear();
	}

	private void OnLoadingEvent(GameEvent gameEvent)
	{
		if (((gameEvent as LoadingEvent) ?? throw new NotSupportedException()).EventType != GameEventType.LoadingUpdateLabel)
		{
			throw new NotSupportedException();
		}
	}

	private void OnException(Exception exception)
	{
		StopAllCoroutines();
		_rootTasks.Clear();
		_subtasks.Clear();
		IsLoading = false;
		IsLoading = false;
		_isRunningTasks = false;
		GameEventDispatcher.RemoveAllListeners(GameEventType.GameStart);
		_loadingFailedLabel.SetActive(value: true);
		_mainMenuButton.SetActive(value: true);
		if (PersistenceManager.SaveMetaInfo != null)
		{
			_submitBrokenSaveReportButton.gameObject.SetActive(value: true);
			if (_brokenSaveFileReport.CanReportSave(PersistenceManager.SaveMetaInfo.Name))
			{
				_submitBrokenSaveReportButton.interactable = true;
				_reportButtonTooltip.IsEnabled = false;
			}
			else
			{
				_submitBrokenSaveReportButton.interactable = false;
				_reportButtonTooltip.IsEnabled = true;
			}
		}
		UnityEngine.Debug.LogException(exception);
	}

	private void SetProgress(float progress)
	{
		_bar.transform.localScale = new Vector3(progress, 1f, 1f);
	}

	private void OnBrokenSaveReportSucceeded()
	{
		_reportButtonTooltip.IsEnabled = true;
	}

	private void OnBrokenSaveReportFailed()
	{
		_submitBrokenSaveReportButton.interactable = true;
	}
}
