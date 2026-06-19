using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardFinalReward : IReward
	{
		public void Apply(Objective objective, Level level)
		{
		}

		public string Description(Objective objective)
		{
			return string.Empty;
		}
	}
}
