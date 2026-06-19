using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardRemixBadge : IRewardMetagame
	{
		public override void Apply(Metagame metagame)
		{
			metagame.AwardRemixBadge(metagame.CurrentLevel.Config, debug: false);
		}

		public override string Description(Objective objective)
		{
			return null;
		}
	}
}
