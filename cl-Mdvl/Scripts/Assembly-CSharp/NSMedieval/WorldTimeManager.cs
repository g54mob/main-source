using NSEipix.Base;
using NSMedieval.Map;
using UnityEngine;

namespace NSMedieval
{
	public class WorldTimeManager : MonoSingleton<WorldTimeManager>
	{
		public delegate void DateTimeChange();

		private float timerCorrector;

		private float quarterHourUpdateEventCnt;

		private bool newSeasonNotified;

		private WorldDate dateAndTime;

		private int debugEventLogCooldown;

		public static float UnityTime { get; private set; }

		public static long UnityTimeLong => (long)UnityTime;

		public event DateTimeChange DateTimeInitalizeEvent;

		public event DateTimeChange TimeUpdateEvent;

		public event DateTimeChange QuarterHourUpdateEvent;

		public event DateTimeChange HourUpdateEvent;

		public event DateTimeChange DateUpdateEvent;

		public event DateTimeChange SeasonUpdateEvent;

		public void OnDebugSeekTime(uint prevDay, Season prevSeason)
		{
			if (prevDay != dateAndTime.DaysTotal)
			{
				DayCompleted();
			}
			if (prevSeason.Name != dateAndTime.Season.Name)
			{
				newSeasonNotified = false;
			}
		}

		private void OnTickTime(float tickDeltaTime)
		{
			UnityTime = Time.time;
			if (dateAndTime == null)
			{
				dateAndTime = GlobalSaveController.CurrentVillageData.DateAndTime;
			}
			timerCorrector += tickDeltaTime;
			dateAndTime.SetMinuteFractionalPart(timerCorrector % 1f);
			if (timerCorrector < 1f)
			{
				return;
			}
			uint year = dateAndTime.Year;
			if (!newSeasonNotified && dateAndTime.Day <= 1)
			{
				newSeasonNotified = true;
				this.SeasonUpdateEvent?.Invoke();
			}
			ushort num = (ushort)Mathf.Floor(timerCorrector);
			quarterHourUpdateEventCnt += (int)num;
			dateAndTime.AddMinute(num);
			debugEventLogCooldown--;
			if (debugEventLogCooldown <= 0)
			{
				debugEventLogCooldown = 1;
				DebugEventLog.TickTime();
			}
			timerCorrector -= (int)Mathf.Floor(timerCorrector);
			this.TimeUpdateEvent?.Invoke();
			float num2 = dateAndTime.MinutesInHour;
			if (quarterHourUpdateEventCnt >= num2 / 4f)
			{
				this.QuarterHourUpdateEvent?.Invoke();
				quarterHourUpdateEventCnt = 0f;
			}
			if ((float)dateAndTime.MinutesSinceDay % num2 != 0f)
			{
				return;
			}
			ChangeHour();
			if (dateAndTime.MinutesSinceDay % dateAndTime.MinutesInDay == 0)
			{
				DayCompleted();
				if (dateAndTime.Day == 1)
				{
					newSeasonNotified = false;
				}
				if (year != dateAndTime.Year)
				{
					MonoSingleton<AchievementManager>.Instance.UnlockAchievement("SURVIVE_FIRST_YEAR");
				}
			}
		}

		private void DayCompleted()
		{
			this.DateUpdateEvent?.Invoke();
			MonoSingleton<AchievementManager>.Instance.SetStat("DAY_CNT", (int)GlobalSaveController.CurrentVillageData.DateAndTime.DaysTotal);
		}

		private void ChangeHour()
		{
			this.HourUpdateEvent?.Invoke();
		}

		private void OnSceneSetup()
		{
			MonoSingleton<SceneController>.Instance.Tick += OnTickTime;
		}

		private void OnLoadingFinished(bool afterLoad)
		{
			this.DateTimeInitalizeEvent?.Invoke();
		}

		protected override void Awake()
		{
			base.Awake();
			UnityTime = Time.time;
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.MapLoadedEvent += OnLoadingFinished;
			MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
			GlobalSaveController.CurrentVillageData?.DateAndTime.ForceUpdateYearCycle();
			debugEventLogCooldown = 0;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
				MonoSingleton<SceneController>.Instance.Tick -= OnTickTime;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnLoadingFinished;
			}
			this.DateTimeInitalizeEvent = null;
			this.TimeUpdateEvent = null;
			this.QuarterHourUpdateEvent = null;
			this.HourUpdateEvent = null;
			this.DateUpdateEvent = null;
			this.SeasonUpdateEvent = null;
		}
	}
}
