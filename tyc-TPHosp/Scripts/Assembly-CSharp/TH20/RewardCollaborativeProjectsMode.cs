using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardCollaborativeProjectsMode : IReward
	{
		public void Apply(Objective objective, Level level)
		{
			level.App.UserProfile.IsCollaborativeProjectsUnlocked = true;
		}

		public string Description(Objective objective)
		{
			return string.Empty;
		}
	}
}
