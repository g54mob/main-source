using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public static class SceneData
	{
		public static HashSet<Object> _persistentObjects = new HashSet<Object>();

		private const string SYSTEM_OBJ_TAG = "System";

		private static GameObject _system;

		public static HashSet<Object> PersistentObjects => _persistentObjects;

		public static GameObject SystemGObject
		{
			get
			{
				if (_system == null)
				{
					_system = GameObject.FindGameObjectWithTag("System");
					Debug.Log(_system);
					if (_system == null)
					{
						_system = new GameObject("System");
						_system.tag = "System";
					}
				}
				return _system;
			}
		}

		public static void MakeObjectPersistent(Object go)
		{
			Object.DontDestroyOnLoad(go);
			_persistentObjects.TryAdd(go);
		}

		public static bool IsPersistent(GameObject go)
		{
			return _persistentObjects.Contains(go);
		}
	}
}
