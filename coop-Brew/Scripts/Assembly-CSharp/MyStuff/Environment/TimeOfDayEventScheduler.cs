using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace MyStuff.Environment
{
	public class TimeOfDayEventScheduler : MonoBehaviour
	{
		[Header("Configuration")]
		[Tooltip("Settings asset with event definitions")]
		[SerializeField]
		private TimeOfDaySettings settings;

		[Header("Debug")]
		[Tooltip("Show debug logs for event firing")]
		[SerializeField]
		private bool showDebugLogs;

		private List<TimeEvent> activeEvents;

		private List<TimeEvent> sortedEventQueue;

		private List<ITimeEventListener> eventListeners;

		private int lastHour;

		private bool lastWasDaytime;

		private TimeOfDayManager manager;

		public event Action<int> OnHourChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnSunrise
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action OnSunset
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<TimeEventContext> OnAnyEventFired
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Initialize(TimeOfDaySettings newSettings, TimeOfDayManager timeManager)
		{
		}

		private void LoadEventsFromSettings()
		{
		}

		private void RebuildEventQueue(float currentNormalizedTime, int currentDayIndex)
		{
		}

		public void ProcessEvents(float currentNormalizedTime, float previousNormalizedTime, int currentDayIndex, TimePhase currentPhase)
		{
		}

		private void FireEvent(TimeEvent evt, float normalizedTime, int dayIndex, TimePhase phase)
		{
		}

		private void ProcessBuiltInEvents(float normalizedTime, TimePhase phase)
		{
		}

		public void RegisterListener(ITimeEventListener listener)
		{
		}

		public void UnregisterListener(ITimeEventListener listener)
		{
		}

		private void BroadcastToListeners(TimeEventContext context)
		{
		}

		public void OnClientReceiveEvent(TimeEventContext context)
		{
		}

		public Guid RegisterEvent(TimeEvent evt, Action<TimeEventContext> callback = null)
		{
			return default(Guid);
		}

		public bool UnregisterEvent(Guid eventId)
		{
			return false;
		}

		public TimeEvent GetNextScheduledEvent()
		{
			return null;
		}
	}
}
