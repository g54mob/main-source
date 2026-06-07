using System.Collections.Generic;
using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Events
{
	[CreateAssetMenu(fileName = "Scriptable Game Event", menuName = "Scriptable Game Events/New Game Event")]
	public class GameEvent : ScriptableObject
	{
		private readonly List<GameEventListener> _eventListeners = new List<GameEventListener>();

		public void Raise()
		{
			for (int num = _eventListeners.Count - 1; num >= 0; num--)
			{
				_eventListeners[num].OnEventRaised(this);
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			if (!_eventListeners.Contains(listener))
			{
				_eventListeners.Add(listener);
			}
		}

		public void UnregisterListener(GameEventListener listener)
		{
			if (_eventListeners.Contains(listener))
			{
				_eventListeners.Remove(listener);
			}
		}
	}
}
