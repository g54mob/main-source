using UnityEngine;

namespace TH20
{
	public class GeneralMarketingCampaignDefinition : MarketingCampaignDefinition
	{
		[SerializeField]
		private float ReputationModifier;

		public override void Apply(float multiplier, MarketingManager marketingManager)
		{
			marketingManager.OnApplyGeneralCampaign.InvokeSafe(this, ReputationModifier / 30.44f * multiplier);
		}
	}
}
