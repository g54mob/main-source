using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionMachineCatchFire : SubGoalDefinition
	{
		public int NumToCatchFire;

		public SharedInstance<RoomItemDefinition> RoomItemDefinition;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalMachineCatchFire(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = ScriptLocalization.Challenges_SubGoals.MachinesCatchFire_Goal_CS;
			LocalisationParams.Set("COUNT", NumToCatchFire);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
