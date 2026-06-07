using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace MoreMountains.Tools
{
	public class MMSceneLoadingAntiSpill
	{
		protected Scene _antiSpillScene;

		protected Scene _destinationScene;

		protected UnityAction<Scene, Scene> _onActiveSceneChangedCallback;

		protected string _sceneToLoadName;

		protected string _antiSpillSceneName;

		protected List<GameObject> _spillSceneRoots = new List<GameObject>(50);

		protected static List<string> _scenesInBuild;

		public virtual void PrepareAntiFill(string sceneToLoadName, string antiSpillSceneName = "")
		{
			_destinationScene = default(Scene);
			_sceneToLoadName = sceneToLoadName;
			if (antiSpillSceneName == "")
			{
				_antiSpillScene = SceneManager.CreateScene("AntiSpill_" + sceneToLoadName);
				PrepareAntiFillSetSceneActive();
				return;
			}
			_scenesInBuild = MMScene.GetScenesInBuild();
			if (!_scenesInBuild.Contains(antiSpillSceneName))
			{
				Debug.LogError("MMSceneLoadingAntiSpill : impossible to load the '" + antiSpillSceneName + "' scene, there is no such scene in the project's build settings.");
				return;
			}
			SceneManager.LoadScene(antiSpillSceneName, LoadSceneMode.Additive);
			_antiSpillScene = SceneManager.GetSceneByName(antiSpillSceneName);
			_antiSpillSceneName = _antiSpillScene.name;
			SceneManager.sceneLoaded += PrepareAntiFillOnSceneLoaded;
		}

		protected virtual void PrepareAntiFillOnSceneLoaded(Scene newScene, LoadSceneMode mode)
		{
			if (!(newScene.name != _antiSpillSceneName))
			{
				SceneManager.sceneLoaded -= PrepareAntiFillOnSceneLoaded;
				PrepareAntiFillSetSceneActive();
			}
		}

		protected virtual void PrepareAntiFillSetSceneActive()
		{
			if (_onActiveSceneChangedCallback != null)
			{
				SceneManager.activeSceneChanged -= _onActiveSceneChangedCallback;
			}
			_onActiveSceneChangedCallback = OnActiveSceneChanged;
			SceneManager.activeSceneChanged += _onActiveSceneChangedCallback;
			SceneManager.SetActiveScene(_antiSpillScene);
		}

		protected virtual void OnActiveSceneChanged(Scene from, Scene to)
		{
			if (from == _antiSpillScene)
			{
				SceneManager.activeSceneChanged -= _onActiveSceneChangedCallback;
				_onActiveSceneChangedCallback = null;
				EmptyAntiSpillScene();
			}
		}

		protected virtual void EmptyAntiSpillScene()
		{
			if (!_antiSpillScene.IsValid() || !_antiSpillScene.isLoaded)
			{
				return;
			}
			_spillSceneRoots.Clear();
			_antiSpillScene.GetRootGameObjects(_spillSceneRoots);
			_destinationScene = SceneManager.GetSceneByName(_sceneToLoadName);
			if (_spillSceneRoots.Count > 0 && _destinationScene.IsValid() && _destinationScene.isLoaded)
			{
				foreach (GameObject spillSceneRoot in _spillSceneRoots)
				{
					SceneManager.MoveGameObjectToScene(spillSceneRoot, _destinationScene);
				}
			}
			SceneManager.UnloadSceneAsync(_antiSpillScene);
		}
	}
}
