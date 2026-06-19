using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerLeaderboardBoast : AdviceTrigger
	{
		public override Advisor.PriorityLevel GetMessagePriority()
		{
			return Advisor.PriorityLevel.DontShow;
		}

		protected override AdvisorMessageDefinition ConstructAdvisorMessage()
		{
			return default(AdvisorMessageDefinition);
		}
	}
}
