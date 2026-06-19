using System;
using I2.Loc;
using UnityEngine;

namespace TH20
{
	public class HospitalEventLoanTakenOut : HospitalEvent, IHospitalEventFinance
	{
		public new class Config : HospitalEvent.Config
		{
			public Sprite Icon;

			public override void RegisterEvents(Level level, bool restoreFromSave)
			{
				_level = level;
				LoanManager loanManager = _level.LoanManager;
				loanManager.OnTakeOutLoan = (Action<LoanOffer>)Delegate.Combine(loanManager.OnTakeOutLoan, new Action<LoanOffer>(OnTakeOutLoan));
			}

			public override void UnregisterEvents()
			{
				LoanManager loanManager = _level.LoanManager;
				loanManager.OnTakeOutLoan = (Action<LoanOffer>)Delegate.Remove(loanManager.OnTakeOutLoan, new Action<LoanOffer>(OnTakeOutLoan));
			}

			private void OnTakeOutLoan(LoanOffer offer)
			{
				_level.HospitalEventLog.AddEvent(new HospitalEventLoanTakenOut
				{
					_config = this,
					Date = _level.TimelineManager.CurrentGameDate,
					_value = offer.Amount
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
			return ScriptLocalization.HospitalEvent.LoanTakenOut_CS;
		}
	}
}
