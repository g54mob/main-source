using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionVIPSatisfied : SubGoalDefinition
	{
		public int VIPSatisfiedTarget;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalVIPSatisfied(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.ImpressVIPs_Goal_CS;
			LocalisationParams.Set("COUNT", VIPSatisfiedTarget);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
