namespace TH20
{
	public class AdvisorTriggerReceptionRequiredDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerReceptionRequired(this);
		}
	}
}
