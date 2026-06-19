using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventEarlyLoanRepayment : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				LoanManager loanManager = _level.LoanManager;
				loanManager.OnRepayLoan = (Action<LoanOffer>)Delegate.Combine(loanManager.OnRepayLoan, new Action<LoanOffer>(OnRepayLoan));
			}

			public override void UnregisterEvents()
			{
				LoanManager loanManager = _level.LoanManager;
				loanManager.OnRepayLoan = (Action<LoanOffer>)Delegate.Remove(loanManager.OnRepayLoan, new Action<LoanOffer>(OnRepayLoan));
			}

			private void OnRepayLoan(LoanOffer offer)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventEarlyLoanRepayment
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_value = -offer.OutstandingBalance
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
			return ScriptLocalization.HospitalEvent.EarlyLoanRepayment_CS;
		}
	}
}
