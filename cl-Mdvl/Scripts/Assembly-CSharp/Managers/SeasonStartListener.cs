using NSEipix.Base;
using NSMedieval;
using NSMedieval.GameEventSystem;

namespace Managers
{
	public class SeasonStartListener : MonoSingleton<SeasonStartListener>
	{
		private void OnEnable()
		{
			MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent += OnHourUpdate;
		}

		private void OnDisable()
		{
			if (MonoSingleton<WorldTimeManager>.IsInstantiated())
			{
				MonoSingleton<WorldTimeManager>.Instance.HourUpdateEvent -= OnHourUpdate;
			}
		}

		private void OnHourUpdate()
		{
			WorldDate dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			if (dateAndTime.HoursTotal > 24 && dateAndTime.HoursTotal % dateAndTime.HoursInSeason == 6)
			{
				string text = dateAndTime.Season.Name.ToLower();
				MonoSingleton<NSMedieval.GameEventSystem.GameEventSystem>.Instance.StartEvent("game_event_season_start_" + text);
				if (!string.IsNullOrEmpty(dateAndTime.Season.UnlockAchievementOnEnd))
				{
					MonoSingleton<AchievementManager>.Instance.UnlockAchievement(dateAndTime.Season.UnlockAchievementOnEnd);
				}
			}
		}
	}
}
