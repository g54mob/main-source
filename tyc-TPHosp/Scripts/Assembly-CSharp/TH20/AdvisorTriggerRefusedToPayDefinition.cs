using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdvisorTriggerRefusedToPayDefinition : AdvisorTriggerDefinition
	{
		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerRefusedToPay(this);
		}
	}
}
