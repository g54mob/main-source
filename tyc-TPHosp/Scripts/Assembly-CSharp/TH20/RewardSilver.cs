using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardSilver : IRewardMetagame
	{
		[SerializeField]
		private int _amount;

		public int Amount => _amount;

		public override void Apply(Metagame metagame)
		{
			metagame.AwardSilver(_amount);
		}

		public override string Description(Objective objective)
		{
			return StringUtils.FormatSilverCurrency(_amount);
		}

		public static RewardSilver Create(int amount)
		{
			return new RewardSilver
			{
				_amount = amount
			};
		}
	}
}
