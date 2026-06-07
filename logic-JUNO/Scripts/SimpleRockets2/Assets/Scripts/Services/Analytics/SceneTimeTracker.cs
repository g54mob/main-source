using ModApi.Scenes;
using ModApi.Scenes.Events;
using UnityEngine;

namespace Assets.Scripts.Services.Analytics
{
	public class SceneTimeTracker : MonoBehaviour
	{
		private string _sceneName;

		private double _timeInScene;

		public string SceneName => _sceneName;

		public double TimeInScene => _timeInScene;

		protected virtual void Awake()
		{
			ISceneManager sceneManager = Game.Instance.SceneManager;
			Game.Instance.SceneManager.SceneLoaded += OnSceneLoaded;
			_sceneName = sceneManager.CurrentScene;
			_timeInScene = 0.0;
		}

		protected virtual void Update()
		{
			_timeInScene += Time.unscaledDeltaTime;
		}

		private void OnSceneLoaded(object sender, SceneEventArgs e)
		{
			_sceneName = e.Scene;
			_timeInScene = 0.0;
		}
	}
}
