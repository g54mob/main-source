using System;
using System.Collections;
using Services.Time;
using UnityEngine;
using Zenject;

namespace Radio
{
	public class RadioConditionProcessor : MonoBehaviour
	{
		[Header("Health")]
		[SerializeField]
		private float lowHealthThreshold = 25f;

		[Header("Time slots")]
		[SerializeField]
		private TimeSlotConfig[] timeSlots = new TimeSlotConfig[4]
		{
			new TimeSlotConfig
			{
				label = "Night",
				atHour = 23.5f,
				condition = RadioCondition.Night
			},
			new TimeSlotConfig
			{
				label = "Morning",
				atHour = 6f,
				condition = RadioCondition.Morning
			},
			new TimeSlotConfig
			{
				label = "Afternoon",
				atHour = 12f,
				condition = RadioCondition.Day
			},
			new TimeSlotConfig
			{
				label = "Evening",
				atHour = 18f,
				condition = RadioCondition.Evening
			}
		};

		[Inject]
		private ITimeService _timeService;

		public RadioCondition ActiveConditions { get; private set; }

		public event Action<RadioCondition> OnConditionsChanged;

		private void OnEnable()
		{
			_timeService.OnTimeChanged += HandleTimeChanged;
			HandleTimeChanged(_timeService.CurrentTime);
		}

		private void OnDisable()
		{
			_timeService.OnTimeChanged -= HandleTimeChanged;
		}

		private void HandleTimeChanged(float hour)
		{
			SetCondition(RadioCondition.IsNight, hour < 6f || hour >= 22f);
			TimeSlotConfig[] array = timeSlots;
			foreach (TimeSlotConfig timeSlotConfig in array)
			{
				if (timeSlotConfig.ShouldFire(hour))
				{
					SetCondition(timeSlotConfig.condition);
					StartCoroutine(ClearAfterFrame(timeSlotConfig.condition));
				}
			}
		}

		private IEnumerator ClearAfterFrame(RadioCondition condition)
		{
			yield return null;
			ClearCondition(condition);
		}

		public void SetCondition(RadioCondition condition)
		{
			RadioCondition activeConditions = ActiveConditions;
			ActiveConditions |= condition;
			if (activeConditions != ActiveConditions)
			{
				this.OnConditionsChanged?.Invoke(ActiveConditions);
			}
		}

		public void ClearCondition(RadioCondition condition)
		{
			RadioCondition activeConditions = ActiveConditions;
			ActiveConditions &= ~condition;
			if (activeConditions != ActiveConditions)
			{
				this.OnConditionsChanged?.Invoke(ActiveConditions);
			}
		}

		public void SetCondition(RadioCondition condition, bool active)
		{
			if (active)
			{
				SetCondition(condition);
			}
			else
			{
				ClearCondition(condition);
			}
		}

		public bool IsAnyActive(RadioCondition mask)
		{
			return (ActiveConditions & mask) != 0;
		}

		public bool AreAllActive(RadioCondition mask)
		{
			return (ActiveConditions & mask) == mask;
		}

		public void OnWeatherChanged(bool isRaining)
		{
			SetCondition(RadioCondition.IsRaining, isRaining);
		}

		public void OnPlayerHealthChanged(float current, float max)
		{
			SetCondition(RadioCondition.PlayerLowHealth, current / max * 100f <= lowHealthThreshold);
		}

		public void OnPlayerDangerStateChanged(bool inDanger)
		{
			SetCondition(RadioCondition.PlayerInDanger, inDanger);
		}

		public void OnBossNearbyChanged(bool nearby)
		{
			SetCondition(RadioCondition.BossNearby, nearby);
		}

		public void OnQuestCompleted()
		{
			SetCondition(RadioCondition.QuestComplete);
			Invoke("ClearQuest", 0.1f);
		}

		private void ClearQuest()
		{
			ClearCondition(RadioCondition.QuestComplete);
		}
	}
}
