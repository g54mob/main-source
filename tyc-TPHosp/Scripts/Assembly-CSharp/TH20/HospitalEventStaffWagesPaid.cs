using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventStaffWagesPaid : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnMonthlyWagesPaid = (Action<int>)Delegate.Combine(financeManager.OnMonthlyWagesPaid, new Action<int>(OnMonthlyWagesPaid));
			}

			public override void UnregisterEvents()
			{
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnMonthlyWagesPaid = (Action<int>)Delegate.Remove(financeManager.OnMonthlyWagesPaid, new Action<int>(OnMonthlyWagesPaid));
			}

			private void OnMonthlyWagesPaid(int amount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventStaffWagesPaid
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_value = -amount
				});
			}
		}

		private int _value;

		public int GetFinanceValue()
		{
			return _value;
		}

		public override Sprite GetEventIcon()
		{
			return ((Config)_config).Icon;
		}

		public override string GetDescription()
		{
			return ScriptLocalization.HospitalEvent.StaffWagesPaid_CS;
		}

		public bool IsFinanceValueValid()
		{
			return GetFinanceValue() != 0;
		}

		public bool ShowOnStatement()
		{
			return true;
		}
	}
}
