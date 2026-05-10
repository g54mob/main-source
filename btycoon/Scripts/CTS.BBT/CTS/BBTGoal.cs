using System;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	[Serializable]
	public abstract class BBTGoal<GoalType> : BBTSimpleGoal<GoalType> where GoalType : QuestNumericGoal
	{
		[VariablePopup(false)]
		public string Target;

		[VariablePopup(false)]
		public string Variable;

		public int TargetValue;

		public override void ResetVariable()
		{
			DialogueLua.SetVariable(Variable, 0);
		}

		public override void SetupTarget()
		{
			DialogueLua.SetVariable(Target, TargetValue);
		}

		protected override void InstantiateGoal()
		{
			Goal = (GoalType)Activator.CreateInstance(typeof(GoalType), Quest, Entry, Variable, Target);
		}
	}
}
