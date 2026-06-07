namespace Gh.Tk
{
	public class PlayTimeAlert : AdvisorAlertBase
	{
		private static int _nextAlertInSeconds;

		private int HoursFromSeconds(float seconds)
		{
			return 0;
		}

		protected override bool TryTriggerInternal()
		{
			return false;
		}
	}
}
