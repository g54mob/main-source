using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ScriptableObject
{
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public SceneLoader _003C_003E4__this;

		public Scene scene;

		internal void _003CUnloadSceneAsync_003Eb__0(AsyncOperation asyncOperation)
		{
			_003C_003E4__this.SceneUnloadComplete(scene, asyncOperation);
		}
	}

	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public SceneLoader _003C_003E4__this;

		public Scene targetScene;

		internal void _003CUnloadSceneAsync_003Eb__0(AsyncOperation asyncOperation)
		{
			_003C_003E4__this.SceneUnloadComplete(targetScene, asyncOperation);
		}
	}

	private sealed class _003C_003Ec__DisplayClass25_0
	{
		public SceneLoader _003C_003E4__this;

		public Scene targetScene;

		internal void _003CLoadSceneAsync_003Eb__0(AsyncOperation asyncOperation)
		{
			_003C_003E4__this.SceneLoadComplete(targetScene, asyncOperation);
		}
	}

	private sealed class _003C_003Ec__DisplayClass26_0
	{
		public SceneLoader _003C_003E4__this;

		public Scene targetScene;

		internal void _003CLoadSceneAsync_003Eb__0(AsyncOperation asyncOperation)
		{
			_003C_003E4__this.SceneLoadComplete(targetScene, asyncOperation);
		}
	}

	public static bool initialStart = true;

	public event Action OnRestart;

	public event Action<AsyncOperation> OnSceneLoadStarted;

	public event Action<AsyncOperation> OnSceneUnloadStarted;

	public event Action<Scene> OnSceneLoaded;

	public event Action<Scene> OnSceneUnloaded;

	public void LoadScene(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
	{
		if (SceneManager.sceneCountInBuildSettings == 1)
		{
			Debug.LogError("not loading scene - only one scene in buildSettings");
			return;
		}
		SceneManager.LoadScene(sceneName, loadSceneMode);
		this.OnSceneLoaded?.Invoke(SceneManager.GetSceneByName(sceneName));
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void UnloadScene(string sceneName)
	{
		UnloadScene(sceneName);
	}

	public void UnloadCurrentSceneAndLoad(GameMode gameModeToLoad)
	{
		GameMode gameMode = OverwritingSingleton<GameSession>.Instance.GameMode;
		UnloadSceneAsync(gameMode.sceneName);
		LoadSceneAsync(gameModeToLoad.sceneName, LoadSceneMode.Additive);
	}

	private void UnloadCurrentSceneAndLoad(string sceneToUnload, string sceneToLoad)
	{
		UnloadSceneAsync(sceneToUnload);
		LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
	}

	public void UnloadSceneAsync(Scene scene)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.scene = scene;
		AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(CS_0024_003C_003E8__locals5.scene);
		this.OnSceneUnloadStarted?.Invoke(asyncOperation);
		asyncOperation.completed += delegate(AsyncOperation unloadOperation)
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this.SceneUnloadComplete(CS_0024_003C_003E8__locals5.scene, unloadOperation);
		};
	}

	public void UnloadSceneAsync(string sceneName)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.targetScene = SceneManager.GetSceneByName(sceneName);
		AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(CS_0024_003C_003E8__locals5.targetScene);
		this.OnSceneUnloadStarted?.Invoke(asyncOperation);
		asyncOperation.completed += delegate(AsyncOperation unloadOperation)
		{
			CS_0024_003C_003E8__locals5._003C_003E4__this.SceneUnloadComplete(CS_0024_003C_003E8__locals5.targetScene, unloadOperation);
		};
	}

	public void LoadSceneAsyncAdditive(string sceneName)
	{
		LoadSceneAsync(sceneName, LoadSceneMode.Additive);
	}

	public void LoadSceneAdditive(string sceneName)
	{
		LoadScene(sceneName, LoadSceneMode.Additive);
	}

	public void LoadSceneAsync(int sceneIndex, LoadSceneMode loadSceneMode)
	{
		_003C_003Ec__DisplayClass25_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass25_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		CS_0024_003C_003E8__locals4.targetScene = SceneManager.GetSceneByBuildIndex(sceneIndex);
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneIndex, loadSceneMode);
		this.OnSceneLoadStarted?.Invoke(asyncOperation);
		asyncOperation.completed += delegate(AsyncOperation loadOperation)
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.SceneLoadComplete(CS_0024_003C_003E8__locals4.targetScene, loadOperation);
		};
	}

	public void LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode)
	{
		_003C_003Ec__DisplayClass26_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass26_0();
		CS_0024_003C_003E8__locals4._003C_003E4__this = this;
		if (SceneManager.sceneCountInBuildSettings == 1)
		{
			Debug.LogError("not loading scene - only one scene in buildSettings");
			return;
		}
		CS_0024_003C_003E8__locals4.targetScene = SceneManager.GetSceneByName(sceneName);
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
		this.OnSceneLoadStarted?.Invoke(asyncOperation);
		asyncOperation.completed += delegate(AsyncOperation loadOperation)
		{
			CS_0024_003C_003E8__locals4._003C_003E4__this.SceneLoadComplete(CS_0024_003C_003E8__locals4.targetScene, loadOperation);
		};
	}

	private void SceneLoadComplete(Scene loadedScene, AsyncOperation loadOperation)
	{
		this.OnSceneLoaded?.Invoke(loadedScene);
	}

	private void SceneUnloadComplete(Scene unloadedScene, AsyncOperation unloadOperation)
	{
		Resources.UnloadUnusedAssets();
		this.OnSceneUnloaded?.Invoke(unloadedScene);
	}
}
