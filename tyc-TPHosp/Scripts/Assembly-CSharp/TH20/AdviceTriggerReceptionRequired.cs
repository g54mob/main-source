using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AdviceTriggerReceptionRequired : AdviceTrigger
	{
		public override Advisor.PriorityLevel GetMessagePriority()
		{
			if (!Level.ReceptionManager.IsReceptionValid(out var _))
			{
				return Advisor.PriorityLevel.VeryHigh;
			}
			return Advisor.PriorityLevel.DontShow;
		}
	}
}
