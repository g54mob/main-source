using System;
using System.Collections.Generic;
using System.Linq;
using FullSerializer;
using UnityEngine;

namespace FullInspector.Internal
{
	public class fiPersistentEditorStorage
	{
		private static Dictionary<Type, Type> _cachedRealComponentTypes = new Dictionary<Type, Type>();

		private const string SceneStorageName = "fiPersistentEditorStorage";

		private static GameObject _cachedSceneStorage;

		private static string PrefabPath = fiUtility.CombinePaths(fiSettings.RootGeneratedDirectory, "fiPersistentEditorStorage.prefab");

		private static GameObject _cachedPrefabStorage;

		public static GameObject SceneStorage
		{
			get
			{
				if (_cachedSceneStorage == null)
				{
					_cachedSceneStorage = GameObject.Find("fiPersistentEditorStorage");
					if (_cachedSceneStorage == null)
					{
						_cachedSceneStorage = fiLateBindings.EditorUtility.CreateGameObjectWithHideFlags("fiPersistentEditorStorage", HideFlags.HideInHierarchy);
					}
				}
				return _cachedSceneStorage;
			}
		}

		public static GameObject PrefabStorage
		{
			get
			{
				if (_cachedPrefabStorage == null)
				{
					_cachedPrefabStorage = (GameObject)fiLateBindings.AssetDatabase.LoadAssetAtPath(PrefabPath, typeof(GameObject));
					if (_cachedPrefabStorage == null)
					{
						GameObject gameObject = new GameObject();
						_cachedPrefabStorage = fiLateBindings.PrefabUtility.CreatePrefab(PrefabPath, gameObject);
						fiUtility.DestroyObject(gameObject);
						Debug.Log("Created new editor storage object at " + PrefabPath + "; this should only happen once. Please report a bug if it keeps on occurring.", _cachedPrefabStorage);
					}
				}
				return _cachedPrefabStorage;
			}
		}

		public static void Reset<T>(fiUnityObjectReference key)
		{
			fiBaseStorageComponent<T> fiBaseStorageComponent2 = ((!fiLateBindings.EditorUtility.IsPersistent(key.Target)) ? GetStorageDictionary<T>(SceneStorage) : GetStorageDictionary<T>(PrefabStorage));
			fiBaseStorageComponent2.Data.Remove(key.Target);
			fiLateBindings.EditorUtility.SetDirty(fiBaseStorageComponent2);
		}

		public static T Read<T>(fiUnityObjectReference key) where T : new()
		{
			fiBaseStorageComponent<T> fiBaseStorageComponent2 = ((!fiLateBindings.EditorUtility.IsPersistent(key.Target)) ? GetStorageDictionary<T>(SceneStorage) : GetStorageDictionary<T>(PrefabStorage));
			if (fiBaseStorageComponent2.Data.ContainsKey(key.Target))
			{
				return fiBaseStorageComponent2.Data[key.Target];
			}
			T result = (fiBaseStorageComponent2.Data[key.Target] = new T());
			fiLateBindings.EditorUtility.SetDirty(fiBaseStorageComponent2);
			return result;
		}

		private static fiBaseStorageComponent<T> GetStorageDictionary<T>(GameObject container)
		{
			if (!_cachedRealComponentTypes.TryGetValue(typeof(fiBaseStorageComponent<T>), out var value))
			{
				value = fiRuntimeReflectionUtility.AllSimpleTypesDerivingFrom(typeof(fiBaseStorageComponent<T>)).FirstOrDefault();
				_cachedRealComponentTypes[typeof(fiBaseStorageComponent<T>)] = value;
			}
			if (value == null)
			{
				throw new InvalidOperationException("Unable to find derived component type for " + typeof(fiBaseStorageComponent<T>).CSharpName());
			}
			Component component = container.GetComponent(value);
			if (component == null)
			{
				component = container.AddComponent(value);
			}
			return (fiBaseStorageComponent<T>)component;
		}
	}
}
