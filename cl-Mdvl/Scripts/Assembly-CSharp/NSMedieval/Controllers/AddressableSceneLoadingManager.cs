using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace NSMedieval.Controllers
{
	public class AddressableSceneLoadingManager : MonoSingleton<AddressableSceneLoadingManager>
	{
		private SceneInstance loadedScene;

		private SceneInstance loadingScene;

		private string sceneToLoad;

		private string sceneToReload;

		public void InitHomeScene()
		{
			sceneToLoad = "HomeScene";
			LoadScene();
		}

		public void LoadHomeScene()
		{
			Time.timeScale = 1f;
			MonoSingleton<LoadingController>.Instance.InvokeMainSceneLeaving();
			sceneToLoad = "HomeScene";
			LoadScene();
		}

		public void LoadMainScene()
		{
			MonoSingleton<LoadingController>.Instance.InvokeHomeSceneLeaving();
			sceneToLoad = "MainScene";
			LoadScene();
		}

		public void ReloadMainScene()
		{
			Time.timeScale = 1f;
			MonoSingleton<LoadingController>.Instance.InvokeMainSceneLeaving();
			sceneToLoad = "HomeScene";
			sceneToReload = "MainScene";
			LoadScene();
		}

		private void LoadScene()
		{
			if (string.IsNullOrEmpty(sceneToLoad))
			{
				Log.Error("Scene key is null or empty!", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				return;
			}
			MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: true);
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.LoadSceneAsync("LoadingScene", LoadSceneMode.Additive);
			asyncOperationHandle.Completed += OnLoadingSceneLoaded;
		}

		private void OnLoadingSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
		{
			if (obj.Status != AsyncOperationStatus.Succeeded)
			{
				Log.Error("Failed to Load LoadingScene", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				return;
			}
			loadingScene = obj.Result;
			loadingScene.ActivateAsync().completed += OnLoadingSceneActivated;
		}

		private void OnLoadingSceneActivated(AsyncOperation obj)
		{
			if (!obj.isDone)
			{
				Log.Error("Failed to complete Activating Loading scene", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				return;
			}
			if (loadedScene.Scene.isLoaded)
			{
				AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.UnloadSceneAsync(loadedScene);
				asyncOperationHandle.Completed += OnSceneUnloaded;
				return;
			}
			SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene()).completed += delegate(AsyncOperation ao)
			{
				if (!ao.isDone)
				{
					Log.Info("Unloading is not done", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				}
				else
				{
					loadedScene = default(SceneInstance);
					AsyncOperationHandle<SceneInstance> asyncOperationHandle2 = Addressables.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
					asyncOperationHandle2.Completed += OnSceneLoaded;
				}
			};
		}

		private void OnSceneUnloaded(AsyncOperationHandle<SceneInstance> obj)
		{
			if (obj.Status != AsyncOperationStatus.Succeeded)
			{
				Log.Error("Failed to unload scene", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				return;
			}
			loadedScene = default(SceneInstance);
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);
			asyncOperationHandle.Completed += OnSceneLoaded;
		}

		private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
		{
			if (obj.Status != AsyncOperationStatus.Succeeded)
			{
				Log.Error("Failed to load scene", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				return;
			}
			loadedScene = obj.Result;
			MonoSingleton<TaskController>.Instance.WaitForNextFrame().ThenWaitUntil((float time) => loadedScene.Scene.IsValid()).Then(delegate
			{
				loadedScene.ActivateAsync().completed += OnLoadedSceneActivated;
			});
		}

		private void OnLoadedSceneActivated(AsyncOperation obj)
		{
			if (!obj.isDone)
			{
				Log.Error("Failed to complete Activating", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
				return;
			}
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.UnloadSceneAsync(loadingScene);
			asyncOperationHandle.Completed += OnLoadingSceneUnloaded;
			if (!string.IsNullOrEmpty(sceneToReload))
			{
				MonoSingleton<TaskController>.Instance.WaitForNextFrame().ThenWaitUntil((float time) => MonoSingleton<GlobalSaveController>.Instance.LoadSavedVillageData()).Then(delegate
				{
					sceneToLoad = sceneToReload;
					sceneToReload = string.Empty;
					LoadScene();
				});
			}
			else
			{
				MonoSingleton<LoadingOverlayController>.Instance.ShowOverlay(show: false);
			}
		}

		private void OnLoadingSceneUnloaded(AsyncOperationHandle<SceneInstance> obj)
		{
			if (obj.Status != AsyncOperationStatus.Succeeded)
			{
				Log.Error("Failed to Unload LoadingScene", "C:\\GIT\\dev\\Assets\\Scripts\\Controller\\AddressableSceneLoadingManager.cs");
			}
			else
			{
				loadingScene = default(SceneInstance);
			}
		}
	}
}
