using UnityEngine;

namespace ModIO.Util
{
	public class SelfInstancingMonoSingleton<T> : MonoBehaviour, ISimpleMonoSingleton where T : MonoBehaviour
	{
		protected static T _instance;

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = (T)Object.FindObjectOfType(typeof(T));
					if (_instance != null)
					{
						return _instance;
					}
					GameObject obj = new GameObject();
					_instance = obj.AddComponent<T>();
					obj.name = _instance.ToString();
				}
				return _instance;
			}
			private set
			{
				_instance = value;
			}
		}

		protected virtual void Awake()
		{
			SetupSingleton();
		}

		public void SetupSingleton()
		{
			if (_instance != null && _instance != this)
			{
				Debug.Log("Instance of " + base.gameObject.name + " already exists on awake, killing.");
				Object.Destroy(_instance.gameObject);
				_instance = null;
			}
			_instance = this as T;
			_instance.name = ToString();
		}

		protected virtual void OnDestroy()
		{
			_instance = null;
		}

		protected virtual void OnApplicationQuit()
		{
			Object.Destroy(_instance.gameObject);
			Object.Destroy(base.gameObject);
			_instance = null;
		}

		public static bool SingletonIsInstantiated()
		{
			return _instance != null;
		}
	}
}
