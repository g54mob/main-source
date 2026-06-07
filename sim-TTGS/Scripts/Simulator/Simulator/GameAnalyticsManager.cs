using Simulator.GameWorld;
using UnityEngine;

namespace Simulator
{
	public class GameAnalyticsManager : MonoBehaviour
	{
		private void OnEnable()
		{
			EventManager.OnMenuEvent += OnMenuEvent;
			EventManager.OnWorldEvent += OnWorldEvent;
			EventManager.OnGameEvent += OnGameEvent;
			Application.quitting += OnApplicationQuitting;
		}

		private void OnDisable()
		{
			EventManager.OnMenuEvent -= OnMenuEvent;
			EventManager.OnWorldEvent -= OnWorldEvent;
			EventManager.OnGameEvent -= OnGameEvent;
			Application.quitting -= OnApplicationQuitting;
		}

		private static void OnApplicationQuitting()
		{
			GameAnalytics.SendBatchEvents();
		}

		private void OnMenuEvent(EMenuEvent menuEvent)
		{
			if (menuEvent == EMenuEvent.INITIALISATION)
			{
				GameAnalytics.Initialize();
			}
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			switch (worldEvent)
			{
			case EWorldEvent.START:
				GameAnalytics.ClearBatchEvents();
				break;
			case EWorldEvent.PREPARE_QUIT:
				SendAnalytics();
				break;
			}
		}

		private void OnGameEvent(EGameEvent gameEvent)
		{
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				GameAnalytics.ClearBatchEvents();
				break;
			case EGameEvent.DAY_END:
				SendAnalytics();
				break;
			}
		}

		private static void SendAnalytics()
		{
			World.TriggerAnalyticsEvent();
			GameAnalytics.SendBatchEvents();
		}
	}
}
