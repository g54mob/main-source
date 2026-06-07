namespace Gh.Tk
{
	public class BankruptcyImminentAlert : AdvisorAlertBase
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
