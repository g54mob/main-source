using FullInspector;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class SubGoalDefinitionMarketingCampaignCompleteIllness : SubGoalDefinitionMarketingCampaignComplete
	{
		[SerializeField]
		private SharedInstance<IllnessMarketingCampaignDefinition> _campaign;

		protected override MarketingCampaignDefinition GetCampaignDefinition()
		{
			if (!_campaign.IsNull())
			{
				return _campaign.Instance;
			}
			return null;
		}

		protected override bool IsMatchingCampaignType(MarketingCampaignDefinition campaign)
		{
			return campaign is IllnessMarketingCampaignDefinition;
		}

		public override string GetCompletionText()
		{
			return ScriptLocalization.Challenges_SubGoals.MarketingCampaignCompleteIllness_CS;
		}
	}
}
