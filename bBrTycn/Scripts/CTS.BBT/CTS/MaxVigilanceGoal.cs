using CTS.Core;

namespace CTS
{
	public class MaxVigilanceGoal : QuestNumericGoal
	{
		public MaxVigilanceGoal(Quest quest, int entryID, string variableName, string targetVariableName, ENumericGoalType goalType = ENumericGoalType.LowerOrEqual)
			: base(quest, entryID, variableName, targetVariableName, goalType)
		{
		}

		public override void StopObserving()
		{
			VigilanceHandlers.VigilanceChanged -= OnVigilanceChanged;
		}

		public override void StartObserving()
		{
			VigilanceHandlers.VigilanceChanged += OnVigilanceChanged;
			OnVigilanceChanged(0);
		}

		private void OnVigilanceChanged(int newVigilancePercentage)
		{
			SetGoalVariable(MonoSingleton<VigilanceHandlers>.Instance.GetCurrentVigilancePercentageWithDifficulty());
		}
	}
}
