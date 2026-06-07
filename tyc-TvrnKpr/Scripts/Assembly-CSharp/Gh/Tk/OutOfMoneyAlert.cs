namespace Gh.Tk
{
	public class OutOfMoneyAlert : AdvisorAlertBase
	{
		protected override bool TryTriggerInternal()
		{
			return false;
		}
	}
}
