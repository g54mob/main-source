using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalUpgradeItemDefinition : SubGoalDefinition
	{
		public int NumOfUpgrades;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalUpgradeItem(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.UpgradeItem_Goal_CS;
			LocalisationParams.Set("COUNT", NumOfUpgrades);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
