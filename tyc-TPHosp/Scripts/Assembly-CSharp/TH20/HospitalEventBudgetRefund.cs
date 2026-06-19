using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventBudgetRefund : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnBudgetRefund = (Action<int>)Delegate.Combine(financeManager.OnBudgetRefund, new Action<int>(OnBudgetRefund));
			}

			public override void UnregisterEvents()
			{
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnBudgetRefund = (Action<int>)Delegate.Remove(financeManager.OnBudgetRefund, new Action<int>(OnBudgetRefund));
			}

			private void OnBudgetRefund(int amount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventBudgetRefund
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_value = amount
				});
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
			return ScriptLocalization.HospitalEvent.BudgetRefund_CS;
		}
	}
}
