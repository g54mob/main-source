using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public abstract class IRewardChallenge : IReward
	{
		public abstract int GetCashPrize(Objective objective);

		public abstract void Apply(Objective objective, Level level);

		public virtual string Description(Objective challenge)
		{
			return null;
		}
	}
}
