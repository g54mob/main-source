using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionThermalComfort : SubGoalDefinition
	{
		public int Target = 80;

		public float CharacterWeight = 1f;

		public float EnvironmentWeight = 1f;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalThermalComfort(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return ScriptLocalization.Challenges_SubGoals.ThermalComfort_Goal_CS.Replace("{[TARGET]}", StringUtils.FormatPercentageValue((float)Target / 100f));
		}

		public int CurrentThermalComfort(Level level)
		{
			float num = (float)GameAlgorithms.CalculateCharactersThermalComfort(level) * CharacterWeight;
			float num2 = (float)GameAlgorithms.CalculateEnvironmentThermalComfort(level) * EnvironmentWeight;
			return (int)((num + num2) / (CharacterWeight + EnvironmentWeight));
		}

		public override bool HasBeenAchieved(Level level)
		{
			return CurrentThermalComfort(level) >= Target;
		}
	}
}
