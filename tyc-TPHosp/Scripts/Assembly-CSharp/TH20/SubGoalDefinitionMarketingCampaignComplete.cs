using I2.Loc;

namespace TH20
{
	public abstract class SubGoalDefinitionMarketingCampaignComplete : SubGoalDefinition
	{
		public int NumCampaigns;

		public bool OnlyCompleteOnMatchingCampaignType;

		protected abstract MarketingCampaignDefinition GetCampaignDefinition();

		protected abstract bool IsMatchingCampaignType(MarketingCampaignDefinition campaign);

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalCompleteMarketingCampaign(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (NumCampaigns > 1)
			{
				string text = ScriptLocalization.Challenges_SubGoals.CompleteMarketingCampaigns_Goal_CS;
				LocalisationParams.Set("COUNT", NumCampaigns);
				return LocalisationParams.Localise(ref text);
			}
			if (GetCampaignDefinition() == null)
			{
				return GetCompletionText();
			}
			return ScriptLocalization.Challenges_SubGoals.MarketingCampaignComplete_CS.Replace("{[CAMPAIGN]}", GetCampaignDefinition().NameLocalised.Translation);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}

		public bool IsValidCampaign(MarketingCampaignDefinition campaign)
		{
			MarketingCampaignDefinition campaignDefinition = GetCampaignDefinition();
			if ((campaignDefinition != null || OnlyCompleteOnMatchingCampaignType) && campaign != campaignDefinition)
			{
				return IsMatchingCampaignType(campaign);
			}
			return true;
		}

		public virtual string GetCompletionText()
		{
			return ScriptLocalization.Challenges_SubGoals.MarketingCampaignCompleteAny_CS;
		}
	}
}
