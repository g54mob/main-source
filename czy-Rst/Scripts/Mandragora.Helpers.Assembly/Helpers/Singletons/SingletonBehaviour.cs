using System;
using Helpers.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Helpers.Singletons
{
	public class SingletonBehaviour<T> : MonoBehaviour where T : Component
	{
		public static readonly UnityEvent<T> OnInstanceChanged = new UnityEventConcrete<T>();

		private static T instance = null;

		private static bool applicationQuit = false;

		public static bool IsInstanced => instance;

		public static string AssetPath => typeof(T).ToString().Replace('.', '/');

		[Obsolete("Avoid using singleton. Please, try to use Injection from Zenject")]
		public static T Instance
		{
			get
			{
				if (instance == null && !applicationQuit)
				{
					Instance = UnityEngine.Object.FindObjectOfType<T>();
					if (instance == null)
					{
						T val = Resources.Load<T>(AssetPath);
						if ((bool)val)
						{
							Instance = UnityEngine.Object.Instantiate(val);
							Debug.Log(typeof(T).Name + " instanced from resource.");
						}
					}
					if (instance == null)
					{
						Instance = new GameObject().AddComponent<T>();
						Debug.Log(typeof(T).Name + " instanced from scratch.");
					}
					if ((bool)instance)
					{
						instance.name = typeof(T).Name;
					}
					else
					{
						Debug.LogError(typeof(T).Name + " cannot be instanced.");
					}
				}
				return instance;
			}
			private set
			{
				instance = value;
				OnInstanceChanged.Invoke(instance);
			}
		}

		protected virtual bool Destroyable => false;

		protected virtual void Awake()
		{
			if (instance == null)
			{
				Instance = this as T;
				if (!Destroyable)
				{
					base.transform.SetParent(null);
					UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
				}
			}
			else if (Instance != this)
			{
				Debug.LogWarning(typeof(T).Name + " instance duplication.");
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void OnDestroy()
		{
			OnPreDestroy();
			if (Instance == this)
			{
				Instance = null;
			}
		}

		protected virtual void OnPreDestroy()
		{
		}

		protected virtual void OnApplicationQuit()
		{
			applicationQuit = true;
		}
	}
}
