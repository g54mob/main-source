using System;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	[Serializable]
	public class HackingDelayEvent : DeviceHackingEvent
	{
		public float Delay { get; private set; }

		public HackingDelayEvent(HackingEventType eventType, float eventTime, float bonus, float penalty, float delay)
			: base(eventType, eventTime, bonus, penalty)
		{
			Delay = delay;
		}
	}
}
