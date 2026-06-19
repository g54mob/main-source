using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionOpenRoom : SubGoalDefinition
	{
		public int RequiredCount = 1;

		[InspectorTooltip("Requires COUNT parameter in the loc string (for plural version)")]
		public LocalisedString GoalTextTerm;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalOpenRoom(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			return LocalisedString.Replace(LocalisedString.GetTranslationPlural(GoalTextTerm.Term, RequiredCount), new SubPair[1]
			{
				new SubPair("{[COUNT]}", RequiredCount.ToString())
			});
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
