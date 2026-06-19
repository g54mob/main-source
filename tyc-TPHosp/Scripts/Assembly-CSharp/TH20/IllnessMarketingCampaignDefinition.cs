using System.Collections.Generic;
using FullInspector;
using UnityEngine;

namespace TH20
{
	public class IllnessMarketingCampaignDefinition : MarketingCampaignDefinition
	{
		[SerializeField]
		private SharedInstance<IllnessDefinition> Illness;

		[SerializeField]
		private SharedInstance<RoomDefinition> TreatmentRoom;

		[SerializeField]
		private float ReputationModifier;

		public float IllnessWeightMultiplier;

		public override void Apply(float multiplier, MarketingManager marketingManager)
		{
			marketingManager.OnApplyIllnessCampaign.InvokeSafe(this, ReputationModifier / 30.44f * multiplier);
		}

		public bool IsValid(IllnessDefinition illness)
		{
			if (Illness.NotNull())
			{
				return illness == Illness.Instance;
			}
			if (TreatmentRoom.NotNull())
			{
				return illness.UsesTreatmentRoom(TreatmentRoom.Instance);
			}
			return false;
		}

		public List<IllnessDefinition> GetIllnesses(Level level)
		{
			List<IllnessDefinition> list = new List<IllnessDefinition>();
			if (Illness.NotNull())
			{
				list.Add(Illness.Instance);
			}
			else if (TreatmentRoom.NotNull())
			{
				RoomDefinition instance = TreatmentRoom.Instance;
				foreach (IllnessDefinition discoveredIllness in level.GameplayStatsTracker.DiscoveredIllnesses)
				{
					if (discoveredIllness.UsesTreatmentRoom(instance))
					{
						list.Add(discoveredIllness);
					}
				}
			}
			return list;
		}
	}
}
