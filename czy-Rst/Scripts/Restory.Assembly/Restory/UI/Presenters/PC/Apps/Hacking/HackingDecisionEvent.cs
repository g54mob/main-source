using System;

namespace Restory.UI.Presenters.PC.Apps.Hacking
{
	[Serializable]
	public class HackingDecisionEvent : DeviceHackingEvent
	{
		public float Decision { get; private set; }

		public HackingDecisionEvent(float eventTime, float bonus, float penalty, float decision)
			: base(HackingEventType.Decision, eventTime, bonus, penalty)
		{
			Decision = decision;
		}
	}
}
