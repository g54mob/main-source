using CTS.Core;

namespace CTS
{
	public class PrestigeLevelGoal : QuestNumericGoal
	{
		public PrestigeLevelGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Prestige.PrestigeLevelChanged -= OnPrestigeLevelChanged;
		}

		public override void StartObserving()
		{
			Prestige.PrestigeLevelChanged += OnPrestigeLevelChanged;
			OnPrestigeLevelChanged(MonoSingleton<Prestige>.Instance.CurrentPrestigeLevel);
		}

		private void OnPrestigeLevelChanged(PrestigeLevelData data)
		{
			SetGoalVariable(data.Level);
		}
	}
}
