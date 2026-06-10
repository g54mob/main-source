using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval_Pooling
{
	public static class GameObjectPool
	{
		private const string DefaultPrefabAddress = "default_empty";

		private static readonly object mutex = new object();

		private static readonly Dictionary<string, List<GameObject>> pools = new Dictionary<string, List<GameObject>>();

		private static readonly Dictionary<string, Transform> prefabPoolSceneParents = new Dictionary<string, Transform>();

		private static readonly Dictionary<GameObject, string> leasedObjectToPrefabName = new Dictionary<GameObject, string>();

		private static bool isInitialized = false;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			lock (mutex)
			{
				prefabPoolSceneParents.Clear();
				leasedObjectToPrefabName.Clear();
				isInitialized = false;
				foreach (List<GameObject> value in pools.Values)
				{
					value.Clear();
				}
				pools.Clear();
			}
		}

		public static GameObject Get(string prefabAddress, bool returnActive = true, string name = "")
		{
			GameObject fromPool = GetFromPool(prefabAddress, returnActive, name);
			if (!string.IsNullOrEmpty(name))
			{
				fromPool.name = name;
			}
			fromPool.gameObject.SetActive(returnActive);
			return fromPool;
		}

		public static GameObject GetDefaultEmpty(bool returnActive = true, string name = "")
		{
			return Get("default_empty", returnActive, name);
		}

		public static void Return(GameObject gameObject, bool resetTransform = true)
		{
			lock (mutex)
			{
				if (resetTransform)
				{
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.transform.localEulerAngles = Vector3.zero;
					gameObject.transform.localScale = Vector3.one;
				}
				if (!isInitialized)
				{
					Init();
				}
				if (!leasedObjectToPrefabName.Remove(gameObject, out var value))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\GameObjectPool.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Tried to return GameObject '");
						messageBuilder.AppendFormatted(gameObject.name);
						messageBuilder.AppendLiteral("' to the pool that was never in there");
					}
					Log.Trace(messageBuilder);
				}
				else
				{
					if (!pools.ContainsKey(value))
					{
						pools[value] = new List<GameObject>();
					}
					pools[value].Add(gameObject);
					gameObject.SetActive(value: false);
					gameObject.transform.SetParent(prefabPoolSceneParents[value], worldPositionStays: false);
				}
			}
		}

		private static GameObject GetFromPool(string prefabAddress, bool returnActive = true, string name = "")
		{
			lock (mutex)
			{
				if (!isInitialized)
				{
					Init();
				}
				if (!pools.ContainsKey(prefabAddress))
				{
					pools[prefabAddress] = new List<GameObject>();
				}
				List<GameObject> list = pools[prefabAddress];
				if (list.Count > 0)
				{
					GameObject gameObject = list[0];
					list.RemoveAt(0);
					leasedObjectToPrefabName[gameObject] = prefabAddress;
					return gameObject;
				}
				GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(prefabAddress);
				if (byAddress == null)
				{
					throw new ArgumentException("Can't instantiate pooled gameObject from prefab at address '" + prefabAddress + "' because the prefab was not found. Maybe you didn't add it to addressables correctly?");
				}
				if (!prefabPoolSceneParents.ContainsKey(prefabAddress))
				{
					prefabPoolSceneParents[prefabAddress] = new GameObject("GameObject Pool '" + prefabAddress + "'").transform;
				}
				GameObject gameObject2 = UnityEngine.Object.Instantiate(byAddress, prefabPoolSceneParents[prefabAddress]);
				leasedObjectToPrefabName[gameObject2] = prefabAddress;
				return gameObject2;
			}
		}

		private static void Init()
		{
			isInitialized = true;
			pools.Clear();
			prefabPoolSceneParents.Clear();
			leasedObjectToPrefabName.Clear();
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
		}

		private static void OnMainSceneLeaving()
		{
			if (isInitialized)
			{
				Log.Info("Clearing GameObject Pool (OnMainSceneLeaving)", "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\GameObjectPool.cs");
				if (MonoSingleton<LoadingController>.IsInstantiated())
				{
					MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
				}
				pools.Clear();
				leasedObjectToPrefabName.Clear();
				prefabPoolSceneParents.Clear();
				isInitialized = false;
			}
		}
	}
}
