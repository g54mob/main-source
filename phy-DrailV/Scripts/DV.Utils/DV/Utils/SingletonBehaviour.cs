using System.Reflection;
using UnityEngine;

namespace DV.Utils
{
	public abstract class SingletonBehaviour<T> : __SingletonBehaviourBase where T : __SingletonBehaviourBase
	{
		private static T _instance;

		private static string _desiredName;

		private static bool _checkedString;

		private static string DesiredName
		{
			get
			{
				if (_checkedString)
				{
					return _desiredName;
				}
				MethodInfo method = typeof(T).GetMethod("AllowAutoCreate");
				if (method != null)
				{
					_desiredName = (string)method.Invoke(null, null);
				}
				else
				{
					Debug.LogWarning(string.Format("{0} doesn't implement {1} method, assuming 'false'", typeof(T), "AllowAutoCreate"));
				}
				_checkedString = true;
				return _desiredName;
			}
		}

		public static T Instance
		{
			get
			{
				if (_instance == null && !UnloadWatcher.isUnloading)
				{
					string desiredName = DesiredName;
					if (!string.IsNullOrEmpty(desiredName))
					{
						GameObject gameObject = new GameObject(desiredName);
						Debug.Log($"Creating {typeof(T)} singleton instance '{gameObject.name}' automatically", gameObject);
						gameObject.transform.SetSiblingIndex(0);
						_instance = gameObject.AddComponent<T>();
						_instance.CheckInitialization();
					}
				}
				return _instance;
			}
		}

		protected virtual void Awake()
		{
			CheckInstance();
		}

		public override void CheckInstance()
		{
			if (_instance != null && _instance != this)
			{
				Debug.LogError("Existing instance of singleton '" + GetType().Name + "' found while initializing new one", _instance);
			}
			_instance = this as T;
			CheckInitialization();
		}

		protected virtual void OnDestroy()
		{
			_instance = null;
		}
	}
}
