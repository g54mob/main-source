using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardSandboxMode : IReward
	{
		public void Apply(Objective objective, Level level)
		{
			level.App.UserProfile.IsSandboxUnlocked = true;
		}

		public string Description(Objective objective)
		{
			return string.Empty;
		}
	}
}
