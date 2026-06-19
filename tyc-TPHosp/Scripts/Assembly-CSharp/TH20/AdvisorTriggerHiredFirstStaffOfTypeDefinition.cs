namespace TH20
{
	public class AdvisorTriggerHiredFirstStaffOfTypeDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerHiredFirstStaffOfType(this);
		}
	}
}
