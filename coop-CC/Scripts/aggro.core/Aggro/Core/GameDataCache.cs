using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

namespace Aggro.Core
{
	public static class GameDataCache
	{
		private static Dictionary<Type, GameDataObjectBase> _cache = new Dictionary<Type, GameDataObjectBase>();

		private static AssetsInitializationState _initializationState;

		private static bool _editorInitialized;

		public static bool isInitialized => _initializationState == AssetsInitializationState.Initialized;

		public static async Task InitializeAsync()
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
			await Assets<GameDataObjectBase>.LoadAsync();
			GameDataObjectBase[] objects = Assets<GameDataObjectBase>.GetObjects();
			foreach (GameDataObjectBase gameDataObjectBase in objects)
			{
				_cache[gameDataObjectBase.GetType()] = gameDataObjectBase;
			}
			for (int j = 0; j < objects.Length; j++)
			{
				objects[j].Initialize();
			}
			_initializationState = AssetsInitializationState.Initialized;
		}

		public static T Get<T>() where T : GameDataObject<T>
		{
			Type typeFromHandle = typeof(T);
			if (!_cache.TryGetValue(typeof(T), out var value) || value == null)
			{
				UnityEngine.Debug.LogWarning($"Could not find GameDataObject asset! ({typeFromHandle})");
				return null;
			}
			return (T)value;
		}

		public static bool Has<T>() where T : GameDataObject<T>
		{
			return _cache.ContainsKey(typeof(T));
		}

		[Conditional("UNITY_EDITOR")]
		private static void EditorCheckInitialize()
		{
		}
	}
}
