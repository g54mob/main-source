using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;
using UnityEngine.Events;

namespace TH20
{
	public class ChallengeBudget : Challenge
	{
		private readonly ChallengeBudgetConfig _config;

		private int _month;

		private int _budget;

		private float _budgetPercent;

		private int _runningCost;

		private int _summedPatientsCured;

		private int _summedPatientsProcessed;

		private List<ChallengeBudgetAvgStat> _averagedStats;

		private int _currentScore;

		private int _maxScore;

		private UnityEvent _onBudgetUpdated;

		private UnityEvent _onCurrentScoreUpdated;

		private Level _level;

		public UnityEvent OnBudgetUpdated => _onBudgetUpdated;

		public UnityEvent OnCurrentScoreUpdated => _onCurrentScoreUpdated;

		public int Budget => _budget;

		public float BudgetPercent => _budgetPercent;

		public float MinBudgetPercent => _config.MinBudgetPercent;

		public float MaxBudgetPercent => _config.MaxBudgetPercent;

		public int RunningCost => _runningCost;

		public float CureRate
		{
			get
			{
				if (PatientsProcessed <= 0)
				{
					return 0f;
				}
				return (float)PatientsCured / (float)PatientsProcessed;
			}
		}

		public int PatientsCured
		{
			get
			{
				base.Level.LevelStatsDatabase.QueryCurrentMonthStat(LevelStatsDatabase.Stat.NumberOfCures, out var value);
				return _summedPatientsCured + (int)value;
			}
		}

		public int PatientsProcessed
		{
			get
			{
				base.Level.LevelStatsDatabase.QueryCurrentMonthStat(LevelStatsDatabase.Stat.NumberOfPatientsProcessed, out var value);
				return _summedPatientsProcessed + (int)value;
			}
		}

		public int NextPeriod => base.Level.TimelineManager.Month + _config.DurationInMonths - _month;

		public List<ChallengeBudgetAvgStat> AveragedStats => _averagedStats;

		public int CurrentScore => _currentScore;

		public int MaxScore => _maxScore;

		public ColourPercentMapping[] ColourPercentMappings => _config.ColourPercentMappings;

		public ChallengeBudget(ChallengeConfig definition, Level level)
			: base(definition, level)
		{
			_config = GetConfig<ChallengeBudgetConfig>();
			_budgetPercent = _config.MaxBudgetPercent / 100f;
			_onBudgetUpdated = new UnityEvent();
			_onCurrentScoreUpdated = new UnityEvent();
			_averagedStats = new List<ChallengeBudgetAvgStat>();
			_maxScore = 0;
			_level = level;
			if (_config.Stats == null)
			{
				return;
			}
			foreach (ChallengeBudgetEntry stat in _config.Stats)
			{
				_averagedStats.Add(new ChallengeBudgetAvgStat(stat.Stat, 0f));
				_maxScore += stat.Weight;
			}
			if (ShouldShowRunningCosts())
			{
				ShowRunningCostsDisplay();
			}
		}

		public bool ShouldShowRunningCosts()
		{
			if (_config.Stats != null && !_config.HideRunningCostsDisplay)
			{
				return _config.Stats.Count > 0;
			}
			return false;
		}

		public bool ShouldUseVibeIcon()
		{
			return _config.UseVibeIcon;
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			LevelStatsDatabase levelStatsDatabase = base.Level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthlyStatsUpdatedPreExpenses = (Action<LevelStatsDatabase.MonthStats, int, int>)Delegate.Combine(levelStatsDatabase.OnMonthlyStatsUpdatedPreExpenses, new Action<LevelStatsDatabase.MonthStats, int, int>(OnMonthCompleted));
		}

		private void UnregisterEvents()
		{
			LevelStatsDatabase levelStatsDatabase = base.Level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthlyStatsUpdatedPreExpenses = (Action<LevelStatsDatabase.MonthStats, int, int>)Delegate.Remove(levelStatsDatabase.OnMonthlyStatsUpdatedPreExpenses, new Action<LevelStatsDatabase.MonthStats, int, int>(OnMonthCompleted));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			if (base.ChallengeStatus == ChallengeState.InProgress)
			{
				RegisterEvents();
			}
			if (_onBudgetUpdated != null)
			{
				_onBudgetUpdated.RemoveAllListeners();
			}
			else
			{
				_onBudgetUpdated = new UnityEvent();
			}
			if (_onCurrentScoreUpdated == null)
			{
				_onCurrentScoreUpdated = new UnityEvent();
			}
			if (_averagedStats == null)
			{
				_averagedStats = new List<ChallengeBudgetAvgStat>();
			}
			_level = base.Level;
			if (ShouldShowRunningCosts())
			{
				ShowRunningCostsDisplay();
			}
		}

		protected override void OnChallengeStarted()
		{
			base.OnChallengeStarted();
			RegisterEvents();
		}

		protected override void OnChallengeFinished()
		{
			UnregisterEvents();
			base.OnChallengeFinished();
		}

		private void ShowRunningCostsDisplay()
		{
			if (_level == null)
			{
				return;
			}
			TimeAndStatsMenu timeAndStatsMenu = _level.HUD.FindMenu<TimeAndStatsMenu>();
			if (timeAndStatsMenu != null)
			{
				RunningCostsDisplay componentInChildren = timeAndStatsMenu.GetComponentInChildren<RunningCostsDisplay>(includeInactive: true);
				if (componentInChildren != null)
				{
					GameObjectUtils.SetActive(componentInChildren.gameObject, isActive: true);
					componentInChildren.Initialise(this);
				}
			}
		}

		private void OnMonthCompleted(LevelStatsDatabase.MonthStats monthStats, int staffWages, int energyBill)
		{
			_month++;
			if (_month != _config.DurationInMonths)
			{
				if (_config.Stats.Count == 0)
				{
					_summedPatientsCured += monthStats.NumberOfCures;
					_summedPatientsProcessed += monthStats.NumberOfPatientsProcessed;
				}
				else
				{
					_averagedStats.Clear();
					_currentScore = 0;
					_maxScore = 0;
					foreach (ChallengeBudgetEntry stat in _config.Stats)
					{
						base.Level.LevelStatsDatabase.QueryPreviousMonthsStatSummed(stat.Stat, _month, out var value);
						value /= (double)_month;
						int num = (int)Math.Floor((float)value * 100f / stat.MaxValue);
						_averagedStats.Add(new ChallengeBudgetAvgStat(stat.Stat, num));
						value *= (double)stat.Weight / (double)stat.MaxValue;
						int num2 = (int)Math.Floor(value);
						_currentScore += num2;
						_maxScore += stat.Weight;
					}
					_onCurrentScoreUpdated.Invoke();
				}
			}
			else
			{
				if (_config.Stats.Count == 0)
				{
					float t = (float)PatientsCured / (float)PatientsProcessed;
					_budgetPercent = Mathf.Lerp(_config.MinBudgetPercent, _config.MaxBudgetPercent, t) / 100f;
				}
				else
				{
					_currentScore = 0;
					_maxScore = 0;
					foreach (ChallengeBudgetEntry stat2 in _config.Stats)
					{
						base.Level.LevelStatsDatabase.QueryPreviousMonthsStatSummed(stat2.Stat, _config.DurationInMonths, out var value2);
						value2 /= (double)_config.DurationInMonths * (double)stat2.MaxValue;
						value2 *= (double)stat2.Weight;
						_currentScore += (int)Math.Floor(value2);
						_maxScore += stat2.Weight;
					}
					_onCurrentScoreUpdated.Invoke();
					float t2 = (float)_currentScore / (float)_maxScore;
					_budgetPercent = Mathf.Lerp(_config.MinBudgetPercent, _config.MaxBudgetPercent, t2) / 100f;
					_onBudgetUpdated.Invoke();
					if (_budgetPercent >= _config.VibeAchievementTarget * 0.01f && ShouldUseVibeIcon())
					{
						PlatformStatsAndAchievements.TriggerAchievement(AchievementId.GoodVibe);
					}
				}
				ShowAdvisorMessage();
				_month = 0;
				_summedPatientsCured = 0;
				_summedPatientsProcessed = 0;
			}
			_runningCost = monthStats.RegularExpenses + staffWages + energyBill;
			_budget = (int)((float)_runningCost * _budgetPercent);
			base.Level.FinanceManager.OnBudgetRefund.InvokeSafe(_budget);
		}

		private void ShowAdvisorMessage()
		{
			if (!_config.DontShowAdvisorMessage)
			{
				string message = (_config.AdvisorMessageOverride.IsNull() ? LocalisedString.Replace(ScriptLocalization.Challenges.Budget_AdvisorMessage_CS, new SubPair[3]
				{
					new SubPair("{[CURED]}", PatientsCured),
					new SubPair("{[PROCESSED]}", PatientsProcessed),
					new SubPair("{[PERCENT]}", StringUtils.FormatPercentageValue(_budgetPercent))
				}) : LocalisedString.Replace(_config.AdvisorMessageOverride.Translation, new SubPair[1]
				{
					new SubPair("{[PERCENT]}", StringUtils.FormatPercentageValue(_budgetPercent))
				}));
				base.Level.Advisor.PushMessage(new AdvisorMessageDefinition
				{
					Message = message,
					Duration = 10f,
					UserCanDismiss = true
				}, interrupt: false, Advisor.PriorityLevel.Medium);
			}
		}

		public override bool ShouldShowTooltip()
		{
			return true;
		}

		public override string GetObjectiveMenuItemTooltip()
		{
			if (_config.TooltipLocString != null)
			{
				string translation = LocalizationManager.GetTranslation(_config.TooltipLocString);
				if (translation != null)
				{
					return LocalisedString.Replace(translation, new SubPair[2]
					{
						new SubPair("{[LOWER]}", StringUtils.FormatPercentageValue(_config.MinBudgetPercent / 100f)),
						new SubPair("{[UPPER]}", StringUtils.FormatPercentageValue(_config.MaxBudgetPercent / 100f))
					});
				}
			}
			return null;
		}

		protected override int CalculateChallengeScore()
		{
			return 0;
		}
	}
}
