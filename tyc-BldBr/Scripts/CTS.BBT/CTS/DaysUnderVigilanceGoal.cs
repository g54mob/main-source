using CTS.Core;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DaysUnderVigilanceGoal : QuestNumericGoal
	{
		private string _maxVigilanceVariableName;

		public DaysUnderVigilanceGoal(Quest quest, int entryID, string variableName, string targetVariableName, string maxVigilanceVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
			_maxVigilanceVariableName = maxVigilanceVariableName;
		}

		public override void StopObserving()
		{
			CalendarHandlers.NewDay -= OnNewDay;
			VigilanceHandlers.VigilanceChanged -= OnVigilanceChanged;
		}

		public override void StartObserving()
		{
			CalendarHandlers.NewDay += OnNewDay;
			VigilanceHandlers.VigilanceChanged += OnVigilanceChanged;
		}

		private void OnVigilanceChanged(int newVigilance)
		{
			if (QuestLog.GetQuestEntryState(base.QuestName, base.EntryID) == QuestState.Active && MonoSingleton<VigilanceHandlers>.Instance.GetCurrentVigilancePercentageWithDifficulty() >= (float)DialogueLua.GetVariable(_maxVigilanceVariableName).asInt)
			{
				SetGoalVariable(0);
			}
		}

		private void OnNewDay()
		{
			if (MonoSingleton<VigilanceHandlers>.Instance.GetCurrentVigilancePercentageWithDifficulty() < (float)DialogueLua.GetVariable(_maxVigilanceVariableName).asInt)
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
