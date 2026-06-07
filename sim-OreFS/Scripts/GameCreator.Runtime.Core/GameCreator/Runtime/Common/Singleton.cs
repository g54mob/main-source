using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	[DisallowMultipleComponent]
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _Instance { get; set; }

		public static T Instance
		{
			get
			{
				if (_Instance == null)
				{
					if (ApplicationManager.IsExiting)
					{
						return null;
					}
					GameObject gameObject = new GameObject();
					_Instance = gameObject.AddComponent<T>();
					string text = TextUtils.Humanize(typeof(T).Name);
					gameObject.name = text + " (singleton)";
					Singleton<T> component = _Instance.GetComponent<Singleton<T>>();
					component.OnCreate();
					if (component.SurviveSceneLoads)
					{
						Object.DontDestroyOnLoad(gameObject);
					}
				}
				return _Instance;
			}
		}

		protected virtual bool SurviveSceneLoads => true;

		protected void WakeUp()
		{
		}

		protected virtual void OnCreate()
		{
		}

		private void OnDestroy()
		{
			_Instance = null;
		}
	}
}
