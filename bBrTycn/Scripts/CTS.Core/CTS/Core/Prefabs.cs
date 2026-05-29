using System;
using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Core
{
	public static class Prefabs
	{
		private static Dictionary<StringKey, PrefabReference> _registeredPrefabs = new Dictionary<StringKey, PrefabReference>();

		public static StringKey CreatePrefab(IPrefabConstructable constructable)
		{
			GameObject gameObject = new GameObject("New Prefab");
			gameObject.gameObject.SetActive(value: false);
			constructable.Construct(gameObject);
			StringKey stringKey = new StringKey(gameObject.name);
			DoRegisterPrefab(stringKey, gameObject);
			return stringKey;
		}

		public static StringKey RegisterPrefab(Component component)
		{
			return RegisterPrefab(component.gameObject);
		}

		public static StringKey RegisterPrefab(GameObject gameObject)
		{
			if (gameObject.scene.IsValid())
			{
				return default(StringKey);
			}
			GameObject gameObject2 = gameObject.transform.root.gameObject;
			StringKey result = new StringKey(gameObject2.name);
			DoRegisterPrefab(new StringKey(gameObject2.name), gameObject2);
			return result;
		}

		public static TPrefab GetPrefab<TPrefab>(StringKey key, int componentIndex = 0) where TPrefab : Component
		{
			if (!_registeredPrefabs.ContainsKey(key))
			{
				return null;
			}
			PrefabReference prefabReference = _registeredPrefabs[key];
			Type typeFromHandle = typeof(TPrefab);
			if (!prefabReference.TryGet(typeFromHandle, componentIndex, out var outComponent))
			{
				return null;
			}
			return outComponent.Cast<TPrefab>();
		}

		public static GameObject GetPrefab(StringKey key)
		{
			if (!_registeredPrefabs.TryGetValue(key, out var value))
			{
				return null;
			}
			return value.RootObject;
		}

		private static void DoRegisterPrefab(StringKey key, GameObject gameObject)
		{
			if (!_registeredPrefabs.ContainsKey(key))
			{
				if (gameObject.scene.IsValid())
				{
					UnityEngine.Object.DontDestroyOnLoad(gameObject);
				}
				PrefabReference value = new PrefabReference(gameObject);
				_registeredPrefabs[key] = value;
			}
		}
	}
}
