using System;
using Dhs5.Utility.Debuggers;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class TimeController : WorldManager
	{
		[Header("Lighting")]
		[SerializeField]
		private Light m_sunLight;

		private Date m_date;

		private DayTime m_time;

		private UpdateTimelineInstanceHandle m_timelineHandle;

		private int m_hourSinceLastAutoSave;

		public Date Date => m_date;

		public DayTime Time => m_time;

		public Date DateElapsed => Date - DayCycleSettings.StartDate;

		public float NormalizedTime => m_timelineHandle.NormalizedTime;

		public static bool IsDay { get; private set; }

		public static event Action<Date> DateChanged;

		public static event Action<DayTime> TimeChanged;

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.INITIALISATION:
			{
				if (DayCycleSettings.TryGetUpdateTimeline(out var updateTimeline) && Updater.CreateTimelineInstance(updateTimeline, out m_timelineHandle))
				{
					RegisterTimelineEvents(register: true);
				}
				InitializeDate();
				break;
			}
			case EWorldEvent.SAVE:
				SaveManager.CurrentSave.globalState.date = m_date;
				SaveManager.CurrentSave.globalState.normalizedTime = m_timelineHandle.NormalizedTime;
				SaveManager.CurrentSave.globalState.dayTime = m_time;
				SaveManager.CurrentSave.globalState.isDay = IsDay;
				break;
			case EWorldEvent.PREPARE_QUIT:
				RegisterTimelineEvents(register: false);
				break;
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				InitializeTime();
				IsDay = true;
				break;
			case EGameEvent.OPEN_SHOP:
				if (!m_timelineHandle.IsActive && IsDay)
				{
					m_timelineHandle.Play();
				}
				break;
			case EGameEvent.DAY_CLEANUP:
				NextDay();
				break;
			}
		}

		private void RegisterTimelineEvents(bool register)
		{
			if (register)
			{
				m_timelineHandle.EventTriggered += OnTimelineEvent;
				m_timelineHandle.Updated += OnTimelineUpdate;
			}
			else
			{
				m_timelineHandle.EventTriggered -= OnTimelineEvent;
				m_timelineHandle.Updated -= OnTimelineUpdate;
			}
		}

		private void OnTimelineEvent(EUpdateTimelineEventType type, ushort id)
		{
			switch (type)
			{
			case EUpdateTimelineEventType.END:
				OnDayCycleEnd();
				break;
			case EUpdateTimelineEventType.CUSTOM:
				if (id == 1)
				{
					OnEveningBegin();
				}
				break;
			}
		}

		private void OnTimelineUpdate(float deltaTime)
		{
			float normalizedTime = m_timelineHandle.NormalizedTime;
			UpdateTime(normalizedTime);
			UpdateSunLight(normalizedTime);
		}

		private void OnEveningBegin()
		{
			World.Evening();
		}

		private void OnDayCycleEnd()
		{
			IsDay = false;
			World.Night();
		}

		private void InitializeTime()
		{
			m_time = DayCycleSettings.StartDayTime;
			TimeController.TimeChanged?.Invoke(m_time);
			UpdateSunLight(0f);
		}

		private void UpdateTime(float normalizedTime, bool init = false)
		{
			int num = DayCycleSettings.StartDayTime.TotalMinutes();
			int num2 = DayCycleSettings.EndDayTime.TotalMinutes();
			if (num2 < num)
			{
				num2 += 1439;
			}
			int num3 = (int)Mathf.Lerp(num, num2, normalizedTime);
			if (num3 == m_time.TotalMinutes())
			{
				return;
			}
			DayTime time = new DayTime(num3);
			if (!init && time.hour > m_time.hour)
			{
				m_hourSinceLastAutoSave++;
				if (SaveSettings.AutoSavePeriodically && (float)GameplayApplicationOptions.AutomaticSaveFrequency > 0f && (float)m_hourSinceLastAutoSave >= (float)GameplayApplicationOptions.AutomaticSaveFrequency)
				{
					SaveManager.AutoSaveAfterClassicUpdate();
					m_hourSinceLastAutoSave = 0;
				}
			}
			m_time = time;
			TimeController.TimeChanged?.Invoke(m_time);
		}

		private void InitializeDate()
		{
			m_date = SaveManager.CurrentSave.globalState.date;
			IsDay = SaveManager.CurrentSave.globalState.isDay;
			TimeController.DateChanged?.Invoke(m_date);
			if (SaveManager.CurrentSave.newSave)
			{
				return;
			}
			if (SaveManager.CurrentSave.shop.shopOpenThisDay)
			{
				float normalizedTime = SaveManager.CurrentSave.globalState.normalizedTime;
				m_timelineHandle.SetNormalizedTime(normalizedTime);
				UpdateTime(normalizedTime, init: true);
				UpdateSunLight(normalizedTime);
				if (!Mathf.Approximately(normalizedTime, 1f))
				{
					m_timelineHandle.Play();
				}
			}
			else
			{
				InitializeTime();
			}
			if (!IsDay)
			{
				OnDayCycleEnd();
			}
		}

		private void NextDay()
		{
			m_date = m_date.Tomorrow();
			TimeController.DateChanged?.Invoke(m_date);
		}

		private void UpdateSunLight(float normalizedTime)
		{
			m_sunLight.color = DayCycleSettings.LightColorGradient.Evaluate(normalizedTime);
			RenderSettings.ambientIntensity = DayCycleSettings.LightIntensityCurve.Evaluate(normalizedTime) * DayCycleSettings.LightIntensityMultiplier;
		}

		public void SetTimescale(float timescale)
		{
			if (m_timelineHandle.IsValid)
			{
				m_timelineHandle.Timescale = timescale;
			}
			else
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.BASE, "Can't set timescale for inactive timeline");
			}
		}

		public void SetNormalizedTime(float normalizedTime)
		{
			if (m_timelineHandle.IsValid)
			{
				m_timelineHandle.SetNormalizedTime(normalizedTime);
			}
			else
			{
				Debugger<EDebugCategory>.LogError(EDebugCategory.BASE, "Can't set normalized time for inactive timeline");
			}
		}
	}
}
