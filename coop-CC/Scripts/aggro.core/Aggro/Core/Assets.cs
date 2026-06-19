using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Aggro.Core
{
	public static class Assets<T> where T : ScriptableObject
	{
		private static List<T> _objects = new List<T>();

		private static AssetsInitializationState _initializationState;

		public static bool isLoaded => _initializationState == AssetsInitializationState.Initialized;

		public static async Task LoadAsync()
		{
			if (_initializationState == AssetsInitializationState.Initialized)
			{
				await Task.Yield();
				return;
			}
			if (_initializationState == AssetsInitializationState.Initializing)
			{
				while (_initializationState == AssetsInitializationState.Initializing)
				{
					await Task.Yield();
				}
				return;
			}
			_initializationState = AssetsInitializationState.Initializing;
			if (!AssetsManager.isInitialized)
			{
				await AssetsManager.InitializeAsync();
			}
			foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
			{
				if (resourceLocator.Locate("assets", typeof(T), out var locations))
				{
					AsyncOperationHandle<IList<T>> asyncOp = Addressables.LoadAssetsAsync<T>(locations, null);
					await asyncOp.Task;
					IList<T> result = asyncOp.Result;
					for (int i = 0; i < result.Count; i++)
					{
						string primaryKey = locations[i].PrimaryKey;
						T val = result[i];
						_objects.Add(val);
						AssetsManager.AddAsset(val, primaryKey);
					}
				}
				locations = null;
			}
			await Task.Yield();
			_initializationState = AssetsInitializationState.Initialized;
		}

		public static T[] GetObjects()
		{
			return _objects.ToArray();
		}

		public static int GetCount()
		{
			return _objects.Count;
		}

		public static bool TryGetAssetByName(string name, out T asset)
		{
			name = name.ToLowerInvariant();
			T[] objects = GetObjects();
			foreach (T val in objects)
			{
				if (val.name.ToLowerInvariant() == name)
				{
					asset = val;
					return true;
				}
			}
			asset = null;
			return false;
		}
	}
}
