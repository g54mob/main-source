using System.Collections.Generic;
using FractureField.Shared.Enums;

namespace FractureField.Rewards
{
	public class RewardBatcher
	{
		private struct PendingReward
		{
			public float Amount;

			public string Source;

			public string Detail;
		}

		private Dictionary<CurrencyType, PendingReward> _pendingRewards;

		private bool _hasPendingRewards;

		public bool HasPendingRewards => false;

		public void AddReward(CurrencyType currencyType, float amount, string source, string detail)
		{
		}

		public void FlushRewards()
		{
		}

		public float GetPendingAmount(CurrencyType currencyType)
		{
			return 0f;
		}
	}
}
