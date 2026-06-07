using System.Collections.Generic;
using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Scriptable_Game_Events
{
	[CreateAssetMenu(fileName = "Scriptable AudioClip Game Event", menuName = "Scriptable Game Events/New AudioClip Game Event")]
	public class AudioClipGameEvent : ScriptableObject
	{
		private readonly List<AudioClipGameEventListener> _eventListeners = new List<AudioClipGameEventListener>();

		public void Raise(AudioClip clip)
		{
			for (int num = _eventListeners.Count - 1; num >= 0; num--)
			{
				_eventListeners[num].OnEventRaised(clip);
			}
		}

		public void RegisterListener(AudioClipGameEventListener listener)
		{
			if (!_eventListeners.Contains(listener))
			{
				_eventListeners.Add(listener);
			}
		}

		public void UnregisterListener(AudioClipGameEventListener listener)
		{
			if (_eventListeners.Contains(listener))
			{
				_eventListeners.Remove(listener);
			}
		}
	}
}
