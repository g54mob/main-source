using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PajamaLlama.Utilities
{
	[DefaultExecutionOrder(int.MaxValue)]
	public class FinalUpdate : MonoBehaviour
	{
		private static FinalUpdate _instance;

		private static bool _allowRegistering = true;

		private readonly List<Action> _listeners = new List<Action>(16);

		private readonly List<Action> _oneShots = new List<Action>(16);

		private readonly List<Action> _endOfFrameListeners = new List<Action>(16);

		private readonly List<Action> _endOfFrameOneShots = new List<Action>(16);

		private readonly List<Action> _gameStartOneshots = new List<Action>(16);

		private readonly List<Action> _actions = new List<Action>(16);

		private void Awake()
		{
			if ((bool)_instance)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			_instance = this;
			UnityEngine.Object.DontDestroyOnLoad(this);
		}

		private IEnumerator Start()
		{
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			while (base.enabled)
			{
				yield return waitForEndOfFrame;
				Invoke(_endOfFrameListeners);
				List<Action> listeners = new List<Action>(_endOfFrameOneShots);
				_endOfFrameOneShots.Clear();
				Invoke(listeners);
			}
		}

		private void LateUpdate()
		{
			Invoke(_listeners);
			Invoke(_oneShots, oneshot: true);
		}

		private void OnDestroy()
		{
			_allowRegistering = false;
		}

		private void Invoke(List<Action> listeners, bool oneshot = false)
		{
			_actions.Clear();
			_actions.AddRange(listeners);
			if (oneshot)
			{
				listeners.Clear();
			}
			foreach (Action action in _actions)
			{
				action();
			}
		}

		public static void Register(Action listener)
		{
			if (_allowRegistering)
			{
				GetInstance()._listeners.AddUnique(listener);
			}
		}

		public static void RegisterOneShot(Action oneShot)
		{
			if (_allowRegistering)
			{
				GetInstance()._oneShots.AddUnique(oneShot);
			}
		}

		public static void RegisterEndOfFrame(Action listener)
		{
			if (_allowRegistering)
			{
				GetInstance()._endOfFrameListeners.AddUnique(listener);
			}
		}

		public static void RegisterEndOfFrameOneShot(Action oneShot)
		{
			if (_allowRegistering)
			{
				GetInstance()._endOfFrameOneShots.AddUnique(oneShot);
			}
		}

		public static void RegisterGameStartOneShot(Action oneShot)
		{
			if (_allowRegistering)
			{
				FinalUpdate instance = GetInstance();
				if (instance._gameStartOneshots.Count == 0)
				{
					GameEventDispatcher.AddListener(GameEventType.GameStart, instance.OnGameStart);
				}
				instance._gameStartOneshots.AddUnique(oneShot);
			}
		}

		public static bool Unregister(Action listener)
		{
			if (_instance != null)
			{
				return _instance._listeners.Remove(listener);
			}
			return false;
		}

		public static bool UnregisterEndOfFrame(Action listener)
		{
			if (_instance != null)
			{
				return _instance._endOfFrameListeners.Remove(listener);
			}
			return false;
		}

		private static FinalUpdate GetInstance()
		{
			if (_instance == null)
			{
				new GameObject("FinalUpdate", typeof(FinalUpdate));
			}
			return _instance;
		}

		private void OnGameStart(GameEvent gameEvent)
		{
			GameEventDispatcher.RemoveListener(GameEventType.GameStart, OnGameStart);
			foreach (Action gameStartOneshot in _gameStartOneshots)
			{
				gameStartOneshot();
			}
			_gameStartOneshots.Clear();
		}
	}
}
