using UnityEngine;

namespace TH20
{
	public class SubGoalDefinitionFlavourText : SubGoalDefinition
	{
		[SerializeField]
		private readonly LocalisedString _flavourText;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalFlavourText(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (_flavourText.Term == null)
			{
				return string.Empty;
			}
			return _flavourText.Translation;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
