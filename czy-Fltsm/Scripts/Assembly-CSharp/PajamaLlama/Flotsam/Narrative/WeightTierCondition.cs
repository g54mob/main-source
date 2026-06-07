using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class WeightTierCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		[Min(0f)]
		private int minimumWeightTierIndex;

		public bool IsMet()
		{
			return minimumWeightTierIndex <= Community.PlayerCommunity.WeightTierIndex;
		}
	}
}
