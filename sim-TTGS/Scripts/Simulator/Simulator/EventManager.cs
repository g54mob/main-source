using System;
using System.Collections.Generic;
using Dhs5.Utility.Debuggers;
using UnityEngine;

namespace Simulator
{
	public class EventManager : MonoBehaviour
	{
		[SerializeField]
		[ReadOnly(false, false)]
		private List<EMenuEvent> m_executedMenuEvents;

		[SerializeField]
		[ReadOnly(false, false)]
		private List<EWorldEvent> m_executedWorldEvents;

		[SerializeField]
		[ReadOnly(false, false)]
		private List<EGameEvent> m_executedGameEvents;

		private static EventManager Instance { get; set; }

		public static event Action<EMenuEvent> OnMenuEvent;

		public static event Action<EWorldEvent> OnWorldEvent;

		public static event Action<EGameEvent> OnGameEvent;

		private void Awake()
		{
			if (Instance != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		public static EventManager GetInstance()
		{
			return Instance;
		}

		public bool Contains(EMenuEvent menuEvent)
		{
			return m_executedMenuEvents.Contains(menuEvent);
		}

		public bool Contains(EWorldEvent worldEvent)
		{
			return m_executedWorldEvents.Contains(worldEvent);
		}

		public bool Contains(EGameEvent gameEvent)
		{
			return m_executedGameEvents.Contains(gameEvent);
		}

		public void ClearMenuEvents()
		{
			m_executedMenuEvents.Clear();
		}

		public void ClearWorldEvents()
		{
			m_executedWorldEvents.Clear();
		}

		public void ClearGameEvents()
		{
			m_executedGameEvents.Clear();
		}

		public void TriggerMenuEvent(EMenuEvent menuEvent)
		{
			Debugger<EDebugCategory>.Log(EDebugCategory.EVENTS, menuEvent, 0, onScreen: true);
			m_executedMenuEvents.Add(menuEvent);
			EventManager.OnMenuEvent?.Invoke(menuEvent);
		}

		public void TriggerWorldEvent(EWorldEvent worldEvent)
		{
			Debugger<EDebugCategory>.Log(EDebugCategory.EVENTS, worldEvent, 0, onScreen: true);
			m_executedWorldEvents.Add(worldEvent);
			EventManager.OnWorldEvent?.Invoke(worldEvent);
		}

		public void TriggerGameEvent(EGameEvent gameEvent)
		{
			Debugger<EDebugCategory>.Log(EDebugCategory.EVENTS, gameEvent, 0, onScreen: true);
			m_executedGameEvents.Add(gameEvent);
			EventManager.OnGameEvent?.Invoke(gameEvent);
		}
	}
}
