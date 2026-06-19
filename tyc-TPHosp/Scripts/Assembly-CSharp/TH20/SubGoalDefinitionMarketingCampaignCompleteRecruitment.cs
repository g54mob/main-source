using FullInspector;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class SubGoalDefinitionMarketingCampaignCompleteRecruitment : SubGoalDefinitionMarketingCampaignComplete
	{
		[SerializeField]
		private SharedInstance<RecruitmentMarketingCampaignDefinition> _campaign;

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
			return campaign is RecruitmentMarketingCampaignDefinition;
		}

		public override string GetCompletionText()
		{
			return ScriptLocalization.Challenges_SubGoals.MarketingCampaignCompleteRecruitment_CS;
		}
	}
}
