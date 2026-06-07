using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Events
{
	public class StringGameEventListener : MonoBehaviour
	{
		[Tooltip("Events to register with.")]
		public List<StringGameEvent> gameEvents;

		[Tooltip("Responses to invoke when Event is raised.")]
		public List<UnityEvent<string>> responses;

		private void OnEnable()
		{
			for (int i = 0; i < gameEvents.Count; i++)
			{
				gameEvents[i].RegisterListener(this);
			}
		}

		private void OnDisable()
		{
			for (int i = 0; i < gameEvents.Count; i++)
			{
				gameEvents[i].UnregisterListener(this);
			}
		}

		public void OnEventRaised(string value, StringGameEvent gameEvent)
		{
			int num = gameEvents.IndexOf(gameEvent);
			if (num >= 0 && num < responses.Count)
			{
				responses[num].Invoke(value);
			}
		}
	}
}
