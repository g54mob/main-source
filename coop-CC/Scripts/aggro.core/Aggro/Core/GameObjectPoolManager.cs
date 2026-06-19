using System;
using System.Collections.Generic;
using UnityEngine;

namespace Aggro.Core
{
	public static class GameObjectPoolManager
	{
		public static bool enablePopulationForEditor;

		private static List<Action> _clearCallbacks = new List<Action>();

		private static List<Action> _clearDisabledCallbacks = new List<Action>();

		private static Transform _container;

		private static bool _initializedContainer;

		[RuntimeInitializeOnLoadMethod]
		private static void RunTimeInit()
		{
			_initializedContainer = false;
			_clearCallbacks.Clear();
			_clearDisabledCallbacks.Clear();
			enablePopulationForEditor = false;
			_container = null;
		}

		internal static void RegisterClear(Action callback)
		{
			_clearCallbacks.Add(callback);
		}

		internal static void RegisterClearDisabled(Action callback)
		{
			_clearDisabledCallbacks.Add(callback);
		}

		public static void ClearPrefabPools()
		{
			if (_container != null)
			{
				UnityEngine.Object.Destroy(_container.gameObject);
			}
			int count = _clearCallbacks.Count;
			for (int i = 0; i < count; i++)
			{
				_clearCallbacks[i]();
			}
			_clearCallbacks.Clear();
			_initializedContainer = false;
		}

		public static void ClearDisabledPrefabs()
		{
			int count = _clearDisabledCallbacks.Count;
			for (int i = 0; i < count; i++)
			{
				_clearDisabledCallbacks[i]();
			}
			_clearDisabledCallbacks.Clear();
		}

		internal static Transform GetContainer()
		{
			if (!_initializedContainer)
			{
				_initializedContainer = true;
				GameObject gameObject = new GameObject("[GameObject Pool]");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				_container = gameObject.transform;
			}
			return _container;
		}

		internal static bool IsPopulationEnabled()
		{
			return true;
		}
	}
}
