using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RewardMoney : IReward
	{
		[SerializeField]
		private int _amount;

		public int Amount => _amount;

		public void Apply(Objective objective, Level level)
		{
			level.FinanceManager.OnMoneyAwarded.InvokeSafe(_amount);
		}

		public string Description(Objective objective)
		{
			return StringUtils.FormatCurrency(_amount);
		}
	}
}
