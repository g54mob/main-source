using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace Restory.AssetManagement
{
	public class AssetProvider : IAssetProvider, IInitializable, IDisposable
	{
		private readonly Dictionary<string, AsyncOperationHandle> resourceHandles = new Dictionary<string, AsyncOperationHandle>();

		private readonly Dictionary<string, AsyncOperationHandle<SceneInstance>> sceneHandles = new Dictionary<string, AsyncOperationHandle<SceneInstance>>();

		private readonly Dictionary<AssetLabelReference, AsyncOperationHandle> labeledResourcesHandles = new Dictionary<AssetLabelReference, AsyncOperationHandle>();

		private readonly Dictionary<string, AsyncOperationHandle> preservedHandles = new Dictionary<string, AsyncOperationHandle>();

		public void Initialize()
		{
		}

		public void Dispose()
		{
			CleanUp(disposeAll: true);
		}

		public Task<GameObject> Instantiate(string address, Vector3 at)
		{
			return Addressables.InstantiateAsync(address, at, Quaternion.identity).Task;
		}

		public Task<GameObject> Instantiate(string address)
		{
			return Addressables.InstantiateAsync(address).Task;
		}

		public AsyncOperationHandle<SceneInstance> LoadScene(AssetReference assetReference, LoadSceneMode loadSceneMode, bool activateOnLoad, Action onCompleted = null)
		{
			string assetGUID = assetReference.AssetGUID;
			if (sceneHandles.TryGetValue(assetGUID, out var value) && value.IsValid())
			{
				value.Completed += delegate
				{
					onCompleted?.Invoke();
				};
				return value;
			}
			AsyncOperationHandle<SceneInstance> asyncOperationHandle = Addressables.LoadSceneAsync(assetGUID, loadSceneMode, activateOnLoad);
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<SceneInstance> result)
			{
				Debug.Log("A Scene: " + result.Result.Scene.name + " is loaded. Result: Success");
				onCompleted?.Invoke();
			};
			AddSceneHandle(assetGUID, asyncOperationHandle);
			return asyncOperationHandle;
		}

		public AsyncOperationHandle<SceneInstance> UnloadScene(AssetReference assetReference, Action onCompleted = null)
		{
			string assetGuid = assetReference.AssetGUID;
			if (sceneHandles.TryGetValue(assetGuid, out var value) && value.IsValid())
			{
				AsyncOperationHandle<SceneInstance> handle = Addressables.UnloadSceneAsync(value, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
				handle.Completed += delegate
				{
					Debug.Log("A Scene: with GUID " + assetGuid + " is unloaded. Result: Success");
					RemoveSceneHandle(assetGuid, handle);
					onCompleted?.Invoke();
				};
				return handle;
			}
			sceneHandles.Remove(assetGuid);
			onCompleted?.Invoke();
			return default(AsyncOperationHandle<SceneInstance>);
		}

		public async Task<T> Load<T>(AssetReference assetReference, bool preserved)
		{
			Dictionary<string, AsyncOperationHandle> workCollection = (preserved ? preservedHandles : resourceHandles);
			if (workCollection.TryGetValue(assetReference.AssetGUID, out var value) && value.IsValid())
			{
				if (value.IsDone)
				{
					return (T)value.Result;
				}
				await value.Task;
			}
			AsyncOperationHandle<T> asyncOperationHandle = Addressables.LoadAssetAsync<T>(assetReference);
			workCollection.Add(assetReference.AssetGUID, asyncOperationHandle);
			return await asyncOperationHandle.Task;
		}

		public void LoadWithLabel(AssetLabelReference assetLabelReference, Action onCompleted = null)
		{
			if (labeledResourcesHandles.TryGetValue(assetLabelReference, out var value))
			{
				if (value.IsDone)
				{
					onCompleted?.Invoke();
				}
				return;
			}
			AsyncOperationHandle<UnityEngine.Object> asyncOperationHandle = Addressables.LoadAssetAsync<UnityEngine.Object>(assetLabelReference.RuntimeKey);
			labeledResourcesHandles.TryAdd(assetLabelReference, asyncOperationHandle);
			asyncOperationHandle.Completed += delegate(AsyncOperationHandle<UnityEngine.Object> result)
			{
				Debug.Log("An Asset: " + result.Result.name + " is loaded. Result: Success");
				onCompleted?.Invoke();
			};
		}

		public void UnloadWithLabel(AssetLabelReference assetLabelReference)
		{
			if (labeledResourcesHandles.TryGetValue(assetLabelReference, out var value))
			{
				if (value.IsValid())
				{
					Addressables.Release(value);
				}
				labeledResourcesHandles.Remove(assetLabelReference);
			}
		}

		private void AddSceneHandle(string key, AsyncOperationHandle<SceneInstance> handle)
		{
			sceneHandles.TryAdd(key, handle);
		}

		private void RemoveHandle(string assetID, AsyncOperationHandle handle)
		{
			if (handle.IsValid())
			{
				Addressables.Release(handle);
			}
			resourceHandles.Remove(assetID);
		}

		private void RemoveSceneHandle(string assetID, AsyncOperationHandle<SceneInstance> handle)
		{
			if (handle.IsValid())
			{
				Addressables.Release(handle);
			}
			sceneHandles.Remove(assetID);
		}

		public T GetAsset<T>(string guid)
		{
			if (resourceHandles.TryGetValue(guid, out var value))
			{
				return (T)value.Result;
			}
			return default(T);
		}

		public void CleanUp(bool disposeAll = false)
		{
			CleanUpResourceHandlers();
			CleanUpSceneHandlers();
			CleanUpLabeledResourcesHandles();
			if (disposeAll)
			{
				CleanUpProtectedHandlers();
			}
		}

		private void CleanUpProtectedHandlers()
		{
			foreach (AsyncOperationHandle value in preservedHandles.Values)
			{
				if (value.IsValid())
				{
					Addressables.Release(value);
				}
			}
			preservedHandles.Clear();
		}

		private void CleanUpResourceHandlers()
		{
			foreach (AsyncOperationHandle value in resourceHandles.Values)
			{
				if (value.IsValid())
				{
					Addressables.Release(value);
				}
			}
			resourceHandles.Clear();
		}

		private void CleanUpSceneHandlers()
		{
			foreach (AsyncOperationHandle<SceneInstance> value in sceneHandles.Values)
			{
				if (value.IsValid() && value.Result.Scene != SceneManager.GetActiveScene())
				{
					Addressables.Release(value);
				}
			}
			sceneHandles.Clear();
		}

		private void CleanUpLabeledResourcesHandles()
		{
			foreach (AsyncOperationHandle value in labeledResourcesHandles.Values)
			{
				if (value.IsValid())
				{
					Addressables.Release(value);
				}
			}
			labeledResourcesHandles.Clear();
		}
	}
}
