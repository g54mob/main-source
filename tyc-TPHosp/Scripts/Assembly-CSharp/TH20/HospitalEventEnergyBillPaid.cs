using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventEnergyBillPaid : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnMonthlyEnergyBillPaid = (Action<int>)Delegate.Combine(financeManager.OnMonthlyEnergyBillPaid, new Action<int>(OnMonthlyEnergyBillPaid));
			}

			public override void UnregisterEvents()
			{
				FinanceManager financeManager = _level.FinanceManager;
				financeManager.OnMonthlyEnergyBillPaid = (Action<int>)Delegate.Remove(financeManager.OnMonthlyEnergyBillPaid, new Action<int>(OnMonthlyEnergyBillPaid));
			}

			private void OnMonthlyEnergyBillPaid(int amount)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventEnergyBillPaid
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
			return ScriptLocalization.HospitalEvent.EnergyBillPaid_CS;
		}
	}
}
