using System;
using UnityEngine;

namespace CTS.Core
{
	public abstract class MonoSingleton<TSelf> : MonoBehaviour where TSelf : MonoSingleton<TSelf>
	{
		private static TSelf _instance;

		private bool _awake;

		public static TSelf Instance
		{
			get
			{
				if ((bool)_instance)
				{
					return _instance;
				}
				_instance = UnityEngine.Object.FindObjectOfType<TSelf>();
				if ((bool)_instance)
				{
					_instance.Awake();
				}
				if (_instance == null)
				{
					return null;
				}
				return _instance;
			}
		}

		public static event Action<TSelf> Awoken;

		public static event Action<TSelf> Destroyed;

		public static bool InstanceExists()
		{
			return _instance;
		}

		public static bool TryGetInstance(out TSelf outInstance)
		{
			outInstance = Instance;
			return outInstance;
		}

		public static TSelf GetOrCreateInstance()
		{
			if (TryGetInstance(out var outInstance))
			{
				return outInstance;
			}
			return new GameObject(typeof(TSelf).Name).AddComponent<TSelf>();
		}

		private void Awake()
		{
			if (_awake)
			{
				return;
			}
			if ((bool)_instance && _instance != this)
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			_awake = true;
			SetThisAsInstance();
			try
			{
				SingletonAwake();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			MonoSingleton<TSelf>.Awoken?.Invoke(_instance);
		}

		private void OnDestroy()
		{
			if (!(_instance != this))
			{
				try
				{
					OnSingletonDestroy();
				}
				catch (Exception message)
				{
					Debug.LogError(message);
				}
				MonoSingleton<TSelf>.Destroyed?.Invoke(_instance);
				_instance = null;
			}
		}

		private void SetThisAsInstance()
		{
			_instance = (TSelf)this;
			if (this is MonoPersistentSingleton<TSelf> target)
			{
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
		}

		protected abstract void SingletonAwake();

		protected abstract void OnSingletonDestroy();
	}
}
