using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionMachineExplode : SubGoalDefinition
	{
		public int NumToExplode;

		public SharedInstance<RoomItemDefinition> RoomItemDefinition;

		public LocalisedString GoalString;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalMachineExplode(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = GoalString.Translation;
			LocalisationParams.Set("COUNT", NumToExplode);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
