using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.Receivables.ReceivableSettings;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.TravelEvents
{
	public class TravelEventConsequence
	{
		public int MinAmount;

		public int MaxAmount;

		public BaseReceivableSettings Reward;

		public BaseReceivable CreateReward(int seed)
		{
			int amount = Random.Range(MinAmount, MaxAmount + 1);
			return Reward.CreateReceivable(seed, amount);
		}
	}
}
