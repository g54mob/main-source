using Doozy.Engine.Progress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Doozy.Engine.SceneManagement
{
	[AddComponentMenu("Doozy/SceneManagement/Scene Director", 13)]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-100)]
	public class SceneDirector : MonoBehaviour
	{
		private static SceneDirector s_instance;

		public bool DebugMode;

		public ActiveSceneChangedEvent OnActiveSceneChanged;

		public SceneLoadedEvent OnSceneLoaded;

		public SceneUnloadedEvent OnSceneUnloaded;

		public static SceneDirector Instance => null;

		private static bool ApplicationIsQuitting { get; set; }

		private bool DebugComponent => false;

		protected SceneDirector()
		{
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void RunOnStart()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnApplicationQuit()
		{
		}

		private void ActiveSceneChanged(Scene current, Scene next)
		{
		}

		private void SceneLoaded(Scene scene, LoadSceneMode mode)
		{
		}

		private void SceneUnloaded(Scene unloadedScene)
		{
		}

		public static SceneLoader LoadSceneAsync(int sceneBuildIndex, LoadSceneMode loadSceneMode, Progressor progressor = null)
		{
			return null;
		}

		public static SceneLoader LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, Progressor progressor = null)
		{
			return null;
		}

		public static AsyncOperation UnloadSceneAsync(Scene scene)
		{
			return null;
		}

		public static AsyncOperation UnloadSceneAsync(int sceneBuildIndex)
		{
			return null;
		}

		public static AsyncOperation UnloadSceneAsync(string sceneName)
		{
			return null;
		}

		public static SceneDirector AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}
	}
}
