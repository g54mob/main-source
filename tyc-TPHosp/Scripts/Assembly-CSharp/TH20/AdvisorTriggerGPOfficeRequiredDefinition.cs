namespace TH20
{
	public class AdvisorTriggerGPOfficeRequiredDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerGPOfficeRequired(this);
		}
	}
}
