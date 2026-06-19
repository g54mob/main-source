using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class AdvisorTriggerRoomNavigationFailureDefinition : AdvisorTriggerDefinition
	{
		public LocalisedString DestinationInvalidText;

		public override AdvisorTrigger CreateAdvisorTrigger()
		{
			return new AdvisorTriggerRoomNavigationFailure(this);
		}
	}
}
