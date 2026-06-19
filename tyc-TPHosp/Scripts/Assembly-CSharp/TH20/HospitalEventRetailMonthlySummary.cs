using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventRetailMonthlySummary : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
				levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			}

			public override void UnregisterEvents()
			{
				LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
				levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthCompleted));
			}

			private void OnMonthCompleted(LevelStatsDatabase.MonthStats monthStats)
			{
				if (monthStats.TotalRetailSpend != 0)
				{
					_level.HospitalEventLog.AddEvent(new HospitalEventRetailMonthlySummary
					{
						_config = this,
						Date = _level.TimelineManager.CurrentGameDate,
						_value = monthStats.TotalRetailSpend
					});
				}
			}
		}

		private int _value;

		public int GetFinanceValue()
		{
			return _value;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.RetailMonthlySummary_CS;
		}
	}
}
