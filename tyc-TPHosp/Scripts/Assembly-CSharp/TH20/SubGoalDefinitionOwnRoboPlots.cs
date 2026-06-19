using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionOwnRoboPlots : SubGoalDefinition
	{
		public int PlotCount;

		public bool IncludeExisting;

		public LocalisedString GoalTextOverride;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalOwnRoboPlots(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = (GoalTextOverride.IsNull() ? ScriptLocalization.Challenges_SubGoals.OwnPlots_Goal_CS : GoalTextOverride.Translation);
			LocalisationParams.Set("COUNT", PlotCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			if (IncludeExisting)
			{
				return level.WorldState.OwnedHospitalMaps.Count >= PlotCount;
			}
			return false;
		}
	}
}
