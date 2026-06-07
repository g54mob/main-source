using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Events
{
	public class GameEventListener : MonoBehaviour
	{
		[Tooltip("Events to register with.")]
		public List<GameEvent> gameEvents;

		[Tooltip("Responses to invoke when Event is raised.")]
		public List<UnityEvent> responses;

		public string debugLogger = "";

		private void OnEnable()
		{
			foreach (GameEvent gameEvent in gameEvents)
			{
				gameEvent.RegisterListener(this);
			}
			if (debugLogger != "")
			{
				Debug.LogWarning(debugLogger);
			}
		}

		private void OnDisable()
		{
			foreach (GameEvent gameEvent in gameEvents)
			{
				gameEvent.UnregisterListener(this);
			}
		}

		public void OnEventRaised(GameEvent gameEvent)
		{
			int index = gameEvents.IndexOf(gameEvent);
			responses[index].Invoke();
		}
	}
}
