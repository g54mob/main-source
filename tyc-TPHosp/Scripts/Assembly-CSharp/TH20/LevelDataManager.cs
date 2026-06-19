using System;

namespace TH20
{
	[DontSave]
	public class LevelDataManager : MustCallDestroy
	{
		private readonly Level _level;

		public LevelDataManager(Level level)
		{
			_level = level;
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				TimelineManager timelineManager = _level.TimelineManager;
				timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
				PushRichPresence();
			}
		}

		public override void Destroy()
		{
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				OnlineManager.ClearRichPresenceLevelData();
				TimelineManager timelineManager = _level.TimelineManager;
				timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			}
			base.Destroy();
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day == 0 || day == 7 || day == 15 || day == 23)
			{
				PushRichPresence();
			}
		}

		private void PushRichPresence()
		{
			OnlineManager.UpdateRichPresenceLevelData(new RichPresenceLevelData(_level.Config.UniqueId, _level.FinanceManager.Balance, _level.ReputationTracker.OverallReputation, _level.CharacterManager.StaffMorale));
		}
	}
}
