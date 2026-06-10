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
	public static class MonoBehaviourPool<T> where T : MonoBehaviour, IPoolableMonoBehaviour
	{
		private static readonly object mutex = new object();

		private static readonly Dictionary<string, List<IPoolableMonoBehaviour>> pools = new Dictionary<string, List<IPoolableMonoBehaviour>>();

		private static readonly Dictionary<string, Transform> prefabPoolSceneParents = new Dictionary<string, Transform>();

		private static readonly Dictionary<IPoolableMonoBehaviour, string> leasedObjectToPrefabName = new Dictionary<IPoolableMonoBehaviour, string>();

		private static bool isInitialized = false;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			foreach (List<IPoolableMonoBehaviour> value in pools.Values)
			{
				value.Clear();
			}
			pools.Clear();
			prefabPoolSceneParents.Clear();
			leasedObjectToPrefabName.Clear();
			isInitialized = false;
		}

		public static T Get(string prefabAddress)
		{
			lock (mutex)
			{
				if (!isInitialized)
				{
					Init();
				}
				if (!pools.ContainsKey(prefabAddress))
				{
					pools[prefabAddress] = new List<IPoolableMonoBehaviour>();
				}
				List<IPoolableMonoBehaviour> list = pools[prefabAddress];
				if (list.Count > 0)
				{
					IPoolableMonoBehaviour poolableMonoBehaviour = list[0];
					list.RemoveAt(0);
					((MonoBehaviour)poolableMonoBehaviour).gameObject.SetActive(value: true);
					leasedObjectToPrefabName[poolableMonoBehaviour] = prefabAddress;
					return poolableMonoBehaviour as T;
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
				IPoolableMonoBehaviour component = UnityEngine.Object.Instantiate(byAddress, prefabPoolSceneParents[prefabAddress]).GetComponent<T>();
				leasedObjectToPrefabName[component] = prefabAddress;
				return (T)component;
			}
		}

		public static void Return(T poolableMonoBehaviour)
		{
			lock (mutex)
			{
				if (poolableMonoBehaviour == null)
				{
					Log.Trace("Tried to return null object to MonoBehaviourPool.", "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\MonoBehaviourPool.cs");
					return;
				}
				if (!isInitialized)
				{
					Init();
				}
				if (!leasedObjectToPrefabName.Remove(poolableMonoBehaviour, out var value))
				{
					bool isEnabled;
					FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(65, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\MonoBehaviourPool.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Tried to return GameObject '");
						messageBuilder.AppendFormatted(poolableMonoBehaviour.name);
						messageBuilder.AppendLiteral("' to the pool that was never in there");
					}
					Log.Trace(messageBuilder);
				}
				else
				{
					if (!pools.ContainsKey(value))
					{
						pools[value] = new List<IPoolableMonoBehaviour>();
					}
					pools[value].Add(poolableMonoBehaviour);
					poolableMonoBehaviour.gameObject.SetActive(value: false);
					poolableMonoBehaviour.transform.localPosition = Vector3.zero;
					poolableMonoBehaviour.transform.SetParent(prefabPoolSceneParents[value], worldPositionStays: false);
				}
			}
		}

		private static void Init()
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(24, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\MonoBehaviourPool.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Initializing pool for '");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral("'");
			}
			Log.Info(messageBuilder);
			isInitialized = true;
			pools.Clear();
			prefabPoolSceneParents.Clear();
			leasedObjectToPrefabName.Clear();
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnMainSceneLeaving;
		}

		private static void OnMainSceneLeaving()
		{
			if (!isInitialized)
			{
				return;
			}
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(41, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Poolers\\MonoBehaviourPool.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Clearing pool for '");
				messageBuilder.AppendFormatted(typeof(T).Name);
				messageBuilder.AppendLiteral("' (OnMainSceneLeaving)");
			}
			Log.Info(messageBuilder);
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnMainSceneLeaving;
			}
			pools.Clear();
			leasedObjectToPrefabName.Clear();
			foreach (Transform value in prefabPoolSceneParents.Values)
			{
				UnityEngine.Object.Destroy(value.gameObject);
			}
			isInitialized = false;
		}
	}
}
