using CTS.Core;

namespace CTS
{
	public class BarValueGoal : QuestNumericGoal
	{
		public BarValueGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			BarValue.TotalValueChanged -= OnTotalValueChanged;
		}

		public override void StartObserving()
		{
			BarValue.TotalValueChanged += OnTotalValueChanged;
			OnTotalValueChanged(CTSSingleton<BarValue>.Instance.TotalValue);
		}

		private void OnTotalValueChanged(float value)
		{
			SetGoalVariable(value);
		}
	}
}
