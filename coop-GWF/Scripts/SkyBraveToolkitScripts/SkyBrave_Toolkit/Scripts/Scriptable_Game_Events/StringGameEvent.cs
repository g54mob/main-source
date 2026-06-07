using System.Collections.Generic;
using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Events
{
	[CreateAssetMenu(fileName = "Scriptable String Game Event", menuName = "Scriptable Game Events/New String Game Event")]
	public class StringGameEvent : ScriptableObject, IGameEvent
	{
		private readonly List<StringGameEventListener> _eventListeners = new List<StringGameEventListener>();

		public string Value;

		public void Raise()
		{
			for (int num = _eventListeners.Count - 1; num >= 0; num--)
			{
				_eventListeners[num].OnEventRaised(Value, this);
			}
		}

		public void RegisterListener(StringGameEventListener listener)
		{
			if (!_eventListeners.Contains(listener))
			{
				_eventListeners.Add(listener);
			}
		}

		public void UnregisterListener(StringGameEventListener listener)
		{
			if (_eventListeners.Contains(listener))
			{
				_eventListeners.Remove(listener);
			}
		}

		public void SetValueAndRaise(string value)
		{
			Value = value;
			Raise();
		}
	}
}
