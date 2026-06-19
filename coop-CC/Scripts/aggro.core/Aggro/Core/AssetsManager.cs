using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Aggro.Core
{
	public static class AssetsManager
	{
		internal const string ASSETS_LABEL = "assets";

		private static AssetsInitializationState _initializationState;

		private static List<ScriptableObject> _objects = new List<ScriptableObject>();

		private static Dictionary<string, ScriptableObject> _pathToObj = new Dictionary<string, ScriptableObject>();

		private static Dictionary<ScriptableObject, string> _objToPath = new Dictionary<ScriptableObject, string>();

		public static bool isInitialized => _initializationState == AssetsInitializationState.Initialized;

		public static async Task InitializeAsync()
		{
			if (_initializationState == AssetsInitializationState.Initialized)
			{
				await Task.Yield();
			}
			else if (_initializationState == AssetsInitializationState.Initializing)
			{
				while (_initializationState == AssetsInitializationState.Initializing)
				{
					await Task.Yield();
				}
			}
			else
			{
				_initializationState = AssetsInitializationState.Initializing;
				await Addressables.InitializeAsync().Task;
				_initializationState = AssetsInitializationState.Initialized;
			}
		}

		internal static void AddAsset(ScriptableObject obj, string path)
		{
			_objects.Add(obj);
			_pathToObj[path] = obj;
			_objToPath[obj] = path;
		}

		public static T[] GetObjects<T>()
		{
			List<T> list = new List<T>();
			for (int i = 0; i < _objects.Count; i++)
			{
				if (_objects[i] is T item)
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}

		public static T[] GetObjects<T>(TagQuery query)
		{
			if (query == null)
			{
				query = TagQuery.ALL_QUERY;
			}
			List<T> list = new List<T>();
			for (int i = 0; i < _objects.Count; i++)
			{
				ScriptableObject scriptableObject = _objects[i];
				if (scriptableObject is T item && scriptableObject is ITaggedAsset taggedAsset)
				{
					TagList assetTagList = taggedAsset.GetAssetTagList();
					if (query.Evaluate(assetTagList))
					{
						list.Add(item);
					}
				}
			}
			return list.ToArray();
		}

		public static void RunAssetInitializations()
		{
			IAssetInitialization[] objects = GetObjects<IAssetInitialization>();
			int num = objects.Length;
			for (int i = 0; i < num; i++)
			{
				objects[i].InitializeAsset();
			}
		}

		public static bool TryGetObject(string path, out ScriptableObject scrob)
		{
			return _pathToObj.TryGetValue(path, out scrob);
		}

		public static string GetPath(ScriptableObject scrob)
		{
			return _objToPath[scrob];
		}
	}
}
