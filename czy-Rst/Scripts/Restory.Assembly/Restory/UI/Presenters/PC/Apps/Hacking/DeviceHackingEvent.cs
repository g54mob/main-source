using System;
using UnityEngine;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	[Serializable]
	public abstract class DeviceHackingEvent
	{
		private bool passed;

		public HackingEventType EventType { get; private set; }

		public float EventTime { get; private set; }

		public bool Passed
		{
			get
			{
				return passed;
			}
			set
			{
				passed = value;
			}
		}

		public float Bonus { get; private set; }

		public float Penalty { get; private set; }

		protected DeviceHackingEvent(HackingEventType eventType, float eventTime, float bonus, float penalty)
		{
			EventType = eventType;
			SetEventTime(eventTime);
			Bonus = bonus;
			Penalty = penalty;
			passed = false;
		}

		public void SetEventTime(float eventTime)
		{
			EventTime = Mathf.Clamp01(eventTime);
		}
	}
}
