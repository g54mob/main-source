using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aggro.Util;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace Aggro.Core
{
	public static class AssetsUtil
	{
		public const string LABEL_SCENES = "scenes";

		public static string GetScenePath(string guid)
		{
			foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
			{
				if (resourceLocator.Locate(guid, typeof(SceneInstance), out var locations) && locations.Count > 0)
				{
					return locations[0].InternalId;
				}
			}
			return null;
		}

		public static bool IsValidScene(string guid)
		{
			return GetScenePath(guid) != null;
		}

		public static bool IsAssetReferenceValid<T>(AssetReferenceT<T> assetRef) where T : UnityEngine.Object
		{
			return IsAssetReferenceValidInternal<T>(assetRef);
		}

		public static bool IsAssetReferenceValid(AssetReferenceScene assetRef)
		{
			if (!assetRef.RuntimeKeyIsValid())
			{
				return false;
			}
			foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
			{
				if (resourceLocator.Locate(assetRef.RuntimeKey, typeof(SceneInstance), out var _))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsAssetReferenceValidInternal<T>(AssetReference assetRef)
		{
			if (!assetRef.RuntimeKeyIsValid())
			{
				return false;
			}
			foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
			{
				if (resourceLocator.Locate(assetRef.RuntimeKey, typeof(T), out var _))
				{
					return true;
				}
			}
			return false;
		}

		public static Task<List<AsyncOperationHandle<IList<T>>>> LoadAssetsAsync<T>(object key) where T : UnityEngine.Object
		{
			return LoadAssetsAsync<T>(key, null);
		}

		public static async Task<List<AsyncOperationHandle<IList<T>>>> LoadAssetsAsync<T>(object key, List<List<IResourceLocation>> outLocations) where T : UnityEngine.Object
		{
			Type type = typeof(T);
			HashSet<int> hashSet = new HashSet<int>();
			List<IResourceLocation> list = new List<IResourceLocation>();
			foreach (IResourceLocator resourceLocator in Addressables.ResourceLocators)
			{
				if (!resourceLocator.Locate(key, type, out var locations))
				{
					continue;
				}
				foreach (IResourceLocation item3 in locations)
				{
					if (!hashSet.Contains(item3.DependencyHashCode))
					{
						hashSet.Add(item3.DependencyHashCode);
						list.Add(item3);
					}
				}
			}
			TaskCollection collection = new TaskCollection();
			List<AsyncOperationHandle<T>> warmupHandles = new List<AsyncOperationHandle<T>>();
			foreach (IResourceLocation item4 in list)
			{
				AsyncOperationHandle<T> item = Addressables.LoadAssetAsync<T>(item4);
				warmupHandles.Add(item);
				collection.AddTask(item.Task);
			}
			await collection.WaitForTasksAsync();
			List<AsyncOperationHandle<IList<T>>> retHandles = new List<AsyncOperationHandle<IList<T>>>();
			foreach (IResourceLocator resourceLocator2 in Addressables.ResourceLocators)
			{
				if (resourceLocator2.Locate(key, type, out var locations2))
				{
					AsyncOperationHandle<IList<T>> item2 = Addressables.LoadAssetsAsync<T>(locations2, null);
					retHandles.Add(item2);
					collection.AddTask(item2.Task);
					outLocations?.Add(new List<IResourceLocation>(locations2));
				}
			}
			await collection.WaitForTasksAsync();
			for (int i = 0; i < warmupHandles.Count; i++)
			{
				Addressables.Release(warmupHandles[i]);
			}
			return retHandles;
		}
	}
}
