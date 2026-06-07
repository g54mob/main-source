using UnityEngine;

namespace GUPS.EasyPerformanceMonitor.Singleton
{
	public class PersistentSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T singleton;

		private static object lockHandle = new object();

		public static T Singleton
		{
			get
			{
				lock (lockHandle)
				{
					if (singleton != null && singleton.gameObject == null)
					{
						singleton = null;
					}
					if (singleton == null)
					{
						singleton = (T)Object.FindObjectOfType(typeof(T));
						if (Object.FindObjectsOfType(typeof(T)).Length > 1)
						{
							return singleton;
						}
						if (singleton == null)
						{
							Create<T>();
						}
					}
					return singleton;
				}
			}
		}

		public static bool Exists => singleton != null;

		protected virtual void Awake()
		{
			if (Exists)
			{
				if (this != singleton && base.gameObject != null)
				{
					Object.DestroyImmediate(base.gameObject);
				}
			}
			else
			{
				singleton = this as T;
			}
		}

		private static void Create<T1>() where T1 : T
		{
			if (!Exists)
			{
				GameObject obj = new GameObject();
				singleton = (T)obj.AddComponent<T1>();
				obj.name = "(PersistentSingleton) " + typeof(T1).ToString();
				Object.DontDestroyOnLoad(obj);
			}
		}
	}
}
