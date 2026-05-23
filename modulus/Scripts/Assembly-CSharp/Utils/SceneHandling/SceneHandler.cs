using System.Collections;
using Events;
using Events.Generic;
using Presentation.UI.LoadingScreen;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils.SceneHandling
{
	public class SceneHandler : MonoBehaviour
	{
		[SerializeField]
		private StringEvent _levelFinishedLoadingEvent;

		[SerializeField]
		private BaseEvent _levelAwakeEvent;

		[SerializeField]
		private LoadingScreenProgressVariableSO _loadingScreenProgressVariable;

		private static SceneHandler _instance;

		public static SceneHandler Instance => _instance;

		private void Awake()
		{
			if (_instance != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			_levelAwakeEvent.Fire();
			base.transform.SetParent(null);
			Object.DontDestroyOnLoad(this);
		}

		private IEnumerator Start()
		{
			yield return null;
			_levelFinishedLoadingEvent.Fire(SceneManager.GetActiveScene().name);
			DynamicGI.UpdateEnvironment();
		}

		public void LoadSceneSimple(string scene, LoadingProgressEnum fromPercent = LoadingProgressEnum.StartLoadingScene, LoadingProgressEnum toPercent = LoadingProgressEnum.FinishedLoadingScene)
		{
			StartCoroutine(LoadSceneInternal(scene, fromPercent, toPercent));
		}

		public void LoadScene(string scene, LoadingProgressEnum fromPercent = LoadingProgressEnum.StartLoadingScene, LoadingProgressEnum toPercent = LoadingProgressEnum.FinishedLoadingScene)
		{
			StartCoroutine(LoadSceneCoroutine(scene, fromPercent, toPercent));
		}

		public IEnumerator LoadSceneCoroutine(string scene, LoadingProgressEnum fromPercent = LoadingProgressEnum.StartLoadingScene, LoadingProgressEnum toPercent = LoadingProgressEnum.FinishedLoadingScene)
		{
			yield return LoadSceneInternal(scene, fromPercent, toPercent);
			yield return null;
			_loadingScreenProgressVariable.SetValue(toPercent);
			_levelFinishedLoadingEvent.Fire(scene);
			DynamicGI.UpdateEnvironment();
		}

		public IEnumerator LoadSceneInternal(string scene, LoadingProgressEnum fromPercent = LoadingProgressEnum.StartLoadingScene, LoadingProgressEnum toPercent = LoadingProgressEnum.FinishedLoadingScene)
		{
			_loadingScreenProgressVariable.SetValue(fromPercent);
			AsyncOperation handle = SceneManager.LoadSceneAsync(scene);
			while (!handle.isDone)
			{
				_loadingScreenProgressVariable.SetValueLerp(fromPercent, toPercent, handle.progress);
				yield return null;
			}
			_loadingScreenProgressVariable.SetValue(toPercent);
		}
	}
}
