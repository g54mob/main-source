namespace Gh.Tk
{
	public class FireBrigadeAdvisorAlert : AdvisorAlertBase
	{
		protected override bool TryTriggerInternal()
		{
			return false;
		}

		public override AdvisorState GetAdvisorState()
		{
			return default(AdvisorState);
		}

		public static void TriggerManually()
		{
		}
	}
}
