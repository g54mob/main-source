using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionMarketingCampaignMonthsSpentOn : SubGoalDefinition
	{
		public int Months;

		public LocalisedString ReplacementGoalText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalMonthsSpentOnMarketingCampaign(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = (ReplacementGoalText.IsNull() ? ScriptLocalization.Challenges_SubGoals.MarketingCampaignMonthsSpentOn_CS : ReplacementGoalText.Translation);
			LocalisationParams.Set("MONTHS", Months);
			return LocalisationParams.Localise(ref text);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
