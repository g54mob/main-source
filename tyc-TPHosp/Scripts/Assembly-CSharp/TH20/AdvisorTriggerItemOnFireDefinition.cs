using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly]
	public class AdvisorTriggerItemOnFireDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerItemOnFire(this);
		}
	}
}
