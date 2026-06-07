using UnityEngine;

namespace Simulator
{
	public class TransientManager<T> : MonoBehaviour where T : TransientManager<T>
	{
		public static T Instance { get; private set; }

		private void Awake()
		{
			if (Instance != null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			Instance = this as T;
			Object.DontDestroyOnLoad(base.gameObject);
		}

		protected virtual void OnEnable()
		{
			EventManager.OnMenuEvent += OnMenuEvent;
			EventManager.OnWorldEvent += OnWorldEvent;
			EventManager.OnGameEvent += OnGameEvent;
		}

		protected virtual void OnDisable()
		{
			if (base.enabled)
			{
				EventManager.OnMenuEvent -= OnMenuEvent;
				EventManager.OnWorldEvent -= OnWorldEvent;
				EventManager.OnGameEvent -= OnGameEvent;
			}
		}

		protected virtual void OnMenuEvent(EMenuEvent menuEvent)
		{
		}

		protected virtual void OnWorldEvent(EWorldEvent worldEvent)
		{
		}

		protected virtual void OnGameEvent(EGameEvent gameEvent)
		{
		}
	}
}
