using System;
using System.Collections.Generic;

namespace Motorways.Audio
{
	public class AudioEventListener
	{
		private List<int> eventListenerIds = new List<int>();

		public virtual void Start(Action AddEventListeners)
		{
			AddEventListeners();
		}

		public virtual void Stop()
		{
			for (int i = 0; i < eventListenerIds.Count; i++)
			{
				AudioSystem.Instance.RemoveAudioEventListener(eventListenerIds[i]);
			}
			eventListenerIds.Clear();
		}

		public void Add(Action<AudioEvent> function, AudioEventType eventTypes, int groupIndex = -1)
		{
			AudioEventFilter filter = new AudioEventFilter(eventTypes);
			filter.GroupIndex = groupIndex;
			eventListenerIds.Add(AudioSystem.Instance.AddAudioEventListener(function.Invoke, filter));
		}

		public void Add(Action<AudioEvent> function, UIEventType uiEventTypes, UIAudioProfile uiAudioProfile = UIAudioProfile.None)
		{
			eventListenerIds.Add(AudioSystem.Instance.AddAudioEventListener(function.Invoke, new AudioEventFilter(uiEventTypes, uiAudioProfile)));
		}

		public void Add(Action<AudioEvent> function, AudioEventFilter filter)
		{
			eventListenerIds.Add(AudioSystem.Instance.AddAudioEventListener(function.Invoke, filter));
		}
	}
}
