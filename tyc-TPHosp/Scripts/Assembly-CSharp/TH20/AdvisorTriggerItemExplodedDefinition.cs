using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly]
	public class AdvisorTriggerItemExplodedDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerItemExploded(this);
		}
	}
}
