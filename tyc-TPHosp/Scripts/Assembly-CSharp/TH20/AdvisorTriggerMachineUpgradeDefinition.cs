namespace TH20
{
	public class AdvisorTriggerMachineUpgradeDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerMachineUpgrade(this);
		}
	}
}
