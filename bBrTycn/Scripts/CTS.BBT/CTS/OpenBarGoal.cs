using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class OpenBarGoal : QuestGoal
	{
		private bool _cancelable;

		public OpenBarGoal(Quest quest, int entryID, bool cancelable = false)
			: base(quest, entryID)
		{
			_cancelable = cancelable;
		}

		public override void StopObserving()
		{
			LevelParameters.OnBarOpenedStatusChanged -= OnBarOpening;
		}

		public override void StartObserving()
		{
			LevelParameters.OnBarOpenedStatusChanged += OnBarOpening;
			OnBarOpening(CTSSingleton<LevelParameters>.Instance.IsOpen);
		}

		private void OnBarOpening(bool value)
		{
			if (value)
			{
				AchieveGoal();
			}
			else if (_cancelable)
			{
				CancelGoalAchievment();
			}
		}
	}
}
