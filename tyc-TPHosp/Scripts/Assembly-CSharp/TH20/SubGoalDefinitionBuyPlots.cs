using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionBuyPlots : SubGoalDefinition
	{
		public int PlotCount;

		public bool EnergyPlotsOnly;

		public LocalisedString GoalTextOverride;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalBuyPlots(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			string text = (GoalTextOverride.IsNull() ? ScriptLocalization.Challenges_SubGoals.BuyPlots_Goal_CS : GoalTextOverride.Translation);
			LocalisationParams.Set("COUNT", PlotCount);
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return level.WorldState.OwnedHospitalMaps.Count >= PlotCount;
		}
	}
}
