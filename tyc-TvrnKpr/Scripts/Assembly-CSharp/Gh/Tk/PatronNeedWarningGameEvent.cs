namespace Gh.Tk
{
	public class PatronNeedWarningGameEvent : GameEvent
	{
		public string NeedType { get; private set; }

		protected PatronNeedWarningGameEvent()
		{
		}

		public PatronNeedWarningGameEvent(int startHour, int endHour, string needType)
		{
		}

		public void UpdateStartEndTimes(int startHour, int endHour)
		{
		}

		public override void Trigger()
		{
		}
	}
}
