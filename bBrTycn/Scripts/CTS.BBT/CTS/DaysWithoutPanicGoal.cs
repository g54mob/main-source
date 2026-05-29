using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DaysWithoutPanicGoal : QuestNumericGoal
	{
		public DaysWithoutPanicGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			CalendarHandlers.NewDay -= OnNewDay;
			PanicCounter.PanicActive -= OnPanicActive;
		}

		public override void StartObserving()
		{
			CalendarHandlers.NewDay += OnNewDay;
			PanicCounter.PanicActive += OnPanicActive;
		}

		private void OnPanicActive(bool active)
		{
			if (active)
			{
				SetGoalVariable(0);
			}
		}

		private void OnNewDay()
		{
			if (!PanicCounter.IsPanicActive)
			{
				AddToGoalVariable(1);
			}
			else if (QuestLog.GetQuestEntryState(base.QuestName, base.EntryID) == QuestState.Active)
			{
				SetGoalVariable(0);
			}
		}
	}
}
