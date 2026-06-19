using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionCharacterModifier : SubGoalDefinition
	{
		public CharacterAttributes.Type ModifierType;

		public CharacterType CharacterType;

		public int TargetAmount;

		[InspectorTooltip("Must include {[COUNT]} in the loc string, ideally in the format 'Build {[COUNT]} rooms'")]
		public LocalisedString GoalLocText;

		[InspectorTooltip("Must include {[COUNT]} in the loc string, ideally in the format '{[COUNT]} remaining'")]
		public LocalisedString ProgressLocText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalCharacterModifier(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (GoalLocText.Term != null)
			{
				return GoalLocText.Translation.Replace("{[COUNT]}", StringUtils.FormatNumber(TargetAmount));
			}
			return null;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
