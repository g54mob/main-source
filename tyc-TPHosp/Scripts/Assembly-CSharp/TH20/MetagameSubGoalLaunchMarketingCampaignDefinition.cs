using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class MetagameSubGoalLaunchMarketingCampaignDefinition : SubGoalDefinition
	{
		public int NumCampaigns;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new MetagameSubGoalLaunchMarketingCampaign(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.LaunchMarketingCampaigns_Goal_CS;
			LocalisationParams.Set("COUNT", NumCampaigns);
			return LocalisationParams.Localise(ref text);
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
