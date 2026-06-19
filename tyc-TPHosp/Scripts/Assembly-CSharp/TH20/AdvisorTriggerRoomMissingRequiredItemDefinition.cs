namespace TH20
{
	public class AdvisorTriggerRoomMissingRequiredItemDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerRoomMissingRequiredItem(this);
		}
	}
}
