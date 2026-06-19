using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardReputation : IReward
	{
		[SerializeField]
		private int _amount;

		public int Amount => _amount;

		public void Apply(Objective objective, Level level)
		{
			level.ReputationTracker.AwardReputation(_amount);
		}

		public string Description(Objective objective)
		{
			return StringUtils.FormatReputationValue(_amount);
		}
	}
}
