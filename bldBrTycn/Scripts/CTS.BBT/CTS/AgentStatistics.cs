using System;
using System.Collections.Generic;
using System.Linq;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class AgentStatistics : StatisticsContainer<EAgentStatistics>, ILockable
	{
		[Serializable]
		public struct StatisticData
		{
			public Dictionary<EAgentStatistics, NumericStatistic> statistics;

			public Dictionary<EAgentStatistics, StatisticBehaviour<EAgentStatistics>> behaviours;
		}

		[SerializeField]
		[Header("Agent Setup")]
		[InfoBox("If a role is assigned, StatisticsToInitialize and BehavioursToInitialize will be ignored", EInfoBoxType.Normal)]
		private AgentRole _role;

		[SerializeField]
		private List<DailyRefresh> _dailyRefreshes;

		public bool Paused { get; set; }

		public Lock ObjectLock { get; set; }

		public Action<bool> LockStateChanged { get; set; }

		public StatisticData SaveData
		{
			get
			{
				return new StatisticData
				{
					statistics = _statistics.Dict,
					behaviours = _behaviours
				};
			}
			set
			{
				_statistics.Clear();
				foreach (KeyValuePair<EAgentStatistics, NumericStatistic> statistic in value.statistics)
				{
					_statistics.Add(statistic);
				}
				_behaviours = value.behaviours;
			}
		}

		public event Action StatisticUpdated;

		public void AddDailyRefresh(DailyRefresh dailyRefreshToAdd)
		{
			_dailyRefreshes.Add(dailyRefreshToAdd);
		}

		public void ToggleStatisticRefresher(EAgentStatistics stat, bool enabledState)
		{
			DailyRefresh dailyRefresh = _dailyRefreshes.First((DailyRefresh d) => d._statToUpdate == stat);
			if (dailyRefresh != null)
			{
				dailyRefresh.Enabled = enabledState;
			}
		}

		public void LoadStatistics()
		{
			Clear();
			_dailyRefreshes.Clear();
			if ((bool)_role)
			{
				_role.AddStatisticsAndBehaviours(this);
				this.StatisticUpdated?.Invoke();
			}
			else
			{
				InitializeBaseSetup();
				this.StatisticUpdated?.Invoke();
			}
		}

		public bool RollStatistic(EAgentStatistics statistics)
		{
			if (!TryGetStatisticUnitInterval(statistics, out var statisticValue))
			{
				return false;
			}
			return UnityEngine.Random.value <= statisticValue;
		}

		private void OnEnable()
		{
			CalendarHandlers.NewDay += OnNewDay;
		}

		private void OnDisable()
		{
			CalendarHandlers.NewDay -= OnNewDay;
		}

		private void OnDestroy()
		{
			CalendarHandlers.NewDay -= OnNewDay;
		}

		private void OnNewDay()
		{
			if (Paused || ObjectLock.IsLocked())
			{
				return;
			}
			foreach (DailyRefresh dailyRefresh in _dailyRefreshes)
			{
				RefreshStat(dailyRefresh);
			}
		}

		private void RefreshStat(DailyRefresh dailyRefresh)
		{
			if (!dailyRefresh.Enabled)
			{
				return;
			}
			float statisticValue;
			if (dailyRefresh._useModifierRange)
			{
				if (!TryGetNumericStatistic(dailyRefresh._modifierStat, out var numericStatistic))
				{
					return;
				}
				statisticValue = UnityEngine.Random.Range(numericStatistic.Min, numericStatistic.Max);
			}
			else if (!TryGetStatisticValue(dailyRefresh._modifierStat, out statisticValue))
			{
				return;
			}
			if (dailyRefresh.UseModifierMultiplicator && TryGetStatisticValue(dailyRefresh._modifierMultiplicatorStat, out var statisticValue2))
			{
				statisticValue *= statisticValue2;
			}
			if (dailyRefresh._useDifficultyModifier)
			{
				float multiplicativeDifficulty = Difficulty.GetMultiplicativeDifficulty(dailyRefresh._difficultyModifier);
				statisticValue *= multiplicativeDifficulty;
			}
			TryAddToStatistic(dailyRefresh._statToUpdate, 0f - statisticValue);
		}

		void ILockable.OnLocked()
		{
		}

		void ILockable.OnUnlocked()
		{
		}
	}
}
