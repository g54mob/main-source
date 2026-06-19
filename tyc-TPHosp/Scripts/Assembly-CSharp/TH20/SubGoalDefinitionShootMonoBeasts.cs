using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionShootMonoBeasts : SubGoalDefinition
	{
		public int NumToShoot;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalShootMonoBeasts(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.ShootMonoBeast_Goal_CS;
			LocalisationParams.Set("COUNT", NumToShoot);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
