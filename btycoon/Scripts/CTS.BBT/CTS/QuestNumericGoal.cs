using System;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public abstract class QuestNumericGoal : QuestGoal
	{
		public enum ENumericGoalType
		{
			HigherOrEqual = 0,
			LowerOrEqual = 1
		}

		private string _variableName;

		private string _targetVariableName;

		protected float TargetValue
		{
			get
			{
				return DialogueLua.GetVariable(_targetVariableName).asFloat;
			}
			set
			{
				if (TargetValue != value)
				{
					DialogueLua.SetVariable(_targetVariableName, value);
					WarnGoalUpdate();
				}
			}
		}

		public ENumericGoalType GoalType { get; private set; }

		public QuestNumericGoal(Quest quest, int entryID, string variableName, string targetVariableName, ENumericGoalType goalType = ENumericGoalType.HigherOrEqual)
			: base(quest, entryID)
		{
			_variableName = variableName;
			_targetVariableName = targetVariableName;
			GoalType = goalType;
		}

		protected void AddToGoalVariable(float value)
		{
			bool goalState = false;
			float asFloat = DialogueLua.GetVariable(_targetVariableName).asFloat;
			double num = Math.Round(DialogueLua.GetVariable(_variableName).asFloat + value, 2);
			switch (GoalType)
			{
			case ENumericGoalType.HigherOrEqual:
				if (num >= (double)asFloat)
				{
					num = asFloat;
					goalState = true;
				}
				break;
			case ENumericGoalType.LowerOrEqual:
				if (num <= (double)asFloat)
				{
					num = asFloat;
					goalState = true;
				}
				break;
			}
			DialogueLua.SetVariable(_variableName, num);
			WarnGoalUpdate();
			SetGoalState(goalState);
		}

		protected void SetGoalVariable(float value)
		{
			float asFloat = DialogueLua.GetVariable(_variableName).asFloat;
			AddToGoalVariable(value - asFloat);
		}

		protected void AddToGoalVariable(int value)
		{
			AddToGoalVariable((float)value);
		}

		protected void SetGoalVariable(int value)
		{
			SetGoalVariable((float)value);
		}
	}
}
