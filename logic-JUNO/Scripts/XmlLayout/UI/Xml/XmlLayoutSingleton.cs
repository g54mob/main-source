using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Xml
{
	public class XmlLayoutSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T _Instance;

		protected bool dontInstantiate;

		private static bool sceneUnloading;

		public static T Instance
		{
			get
			{
				if (!_Instance)
				{
					_Instance = Object.FindObjectOfType<T>();
					if (!_Instance && !sceneUnloading)
					{
						_Instance = new GameObject
						{
							name = "__" + typeof(T).ToString()
						}.AddComponent<T>();
						SceneManager.sceneUnloaded += delegate(Scene scene)
						{
							OnSceneUnloaded(scene);
						};
						SceneManager.sceneLoaded += delegate(Scene scene, LoadSceneMode loadMode)
						{
							OnSceneLoaded(scene);
						};
					}
				}
				return _Instance;
			}
		}

		public virtual void Awake()
		{
			if (_Instance == null)
			{
				_Instance = this as T;
				return;
			}
			dontInstantiate = true;
			Object.Destroy(this);
			sceneUnloading = false;
		}

		private void OnDestroy()
		{
			sceneUnloading = true;
		}

		public static void OnSceneUnloaded(Scene scene)
		{
			sceneUnloading = true;
		}

		public static void OnSceneLoaded(Scene scene)
		{
			sceneUnloading = false;
		}
	}
}
