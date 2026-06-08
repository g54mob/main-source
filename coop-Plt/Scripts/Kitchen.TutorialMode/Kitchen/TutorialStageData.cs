using System.Collections.Generic;

namespace Kitchen
{
	public class TutorialStageData
	{
		public List<TutorialHint> Hints = new List<TutorialHint>();

		public List<TutorialCondition> Transitions = new List<TutorialCondition>();

		public List<TutorialAction> Actions = new List<TutorialAction>();

		public TutorialStageData When(TutorialStage stage, TutorialCondition condition, bool invert = false)
		{
			condition.LeadsTo = stage;
			condition.Invert = invert;
			Transitions.Add(condition);
			return this;
		}

		public TutorialStageData Not(TutorialStage stage, TutorialCondition condition)
		{
			return When(stage, condition, invert: true);
		}

		public TutorialStageData Add(TutorialHint hint)
		{
			Hints.Add(hint);
			return this;
		}

		public TutorialStageData Add(TutorialAction action)
		{
			Actions.Add(action);
			return this;
		}
	}
}
