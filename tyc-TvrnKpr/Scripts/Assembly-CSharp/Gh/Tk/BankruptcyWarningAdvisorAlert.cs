namespace Gh.Tk
{
	public class BankruptcyWarningAdvisorAlert : AdvisorAlertBase
	{
		public override AdvisorState GetAdvisorState()
		{
			return default(AdvisorState);
		}

		protected override bool TryTriggerInternal()
		{
			return false;
		}
	}
}
