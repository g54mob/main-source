using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class LoanOffer
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Definition
		{
			public LocalisedString DisplayName;

			public Sprite Icon;

			public int MinLoanAmount;

			public int MaxLoanAmount;

			public int DefaultAmount;

			public int InterestRate;

			public int RepaymentPeriod;

			[InspectorHeader("Requirements")]
			public KeyValuePair<int, bool> HospitalValue;

			public KeyValuePair<int, bool> HospitalLevel;

			public KeyValuePair<int, bool> Balance;

			public KeyValuePair<float, bool> Reputation;
		}

		private readonly Definition _definition;

		private readonly LoanManager _loanManager;

		private int _remainingMonths;

		private int _loanAmount;

		private int _outstandingBalance;

		public bool Active { get; private set; }

		public bool Available { get; private set; }

		public int Amount
		{
			get
			{
				return _loanAmount;
			}
			set
			{
				_loanAmount = value;
			}
		}

		public int MinLoanAmount => _definition.MinLoanAmount;

		public int MaxLoanAmount => _definition.MaxLoanAmount;

		public int AmountToRepay => MonthlyRepayment * _definition.RepaymentPeriod;

		public int RepaymentPeriod => _definition.RepaymentPeriod;

		public float MonthlyInterestRate => (float)_definition.InterestRate / 12f / 100f;

		public int MonthlyRepayment
		{
			get
			{
				float num = Mathf.Pow(1f + MonthlyInterestRate, RepaymentPeriod);
				return Mathf.CeilToInt((float)Amount * MonthlyInterestRate * num / (num - 1f));
			}
		}

		public LocalisedString DisplayName => _definition.DisplayName;

		public Sprite LoanProviderIcon => _definition.Icon;

		public int APR => _definition.InterestRate;

		public int RemainingMonths => _remainingMonths;

		public int OutstandingBalance => _outstandingBalance;

		public int MonthlyInterest => Mathf.CeilToInt((float)OutstandingBalance * MonthlyInterestRate);

		public string RequiredString
		{
			get
			{
				bool flag = false;
				string text = string.Empty;
				if (_definition.HospitalValue.Value)
				{
					text = ScriptLocalization.Menu_Loans.RequiresHospitalValue_CS.Replace("{[VALUE]}", StringUtils.FormatCurrency(_definition.HospitalValue.Key));
					flag = true;
				}
				if (_definition.Balance.Value)
				{
					if (flag)
					{
						text += "\n";
					}
					flag = true;
					string requiresBalance_CS = ScriptLocalization.Menu_Loans.RequiresBalance_CS;
					requiresBalance_CS = requiresBalance_CS.Replace("{[VALUE]}", StringUtils.FormatCurrency(_definition.Balance.Key));
					text += requiresBalance_CS;
				}
				if (_definition.Reputation.Value)
				{
					if (flag)
					{
						text += "\n";
					}
					flag = true;
					string requiresReputation_CS = ScriptLocalization.Menu_Loans.RequiresReputation_CS;
					requiresReputation_CS = requiresReputation_CS.Replace("{[VALUE]}", ((int)(_definition.Reputation.Key * 100f)).ToString());
					text += requiresReputation_CS;
				}
				if (_definition.HospitalLevel.Value)
				{
					if (flag)
					{
						text += "\n";
					}
					string requiresHospitalLevel_CS = ScriptLocalization.Menu_Loans.RequiresHospitalLevel_CS;
					requiresHospitalLevel_CS = requiresHospitalLevel_CS.Replace("{[VALUE]}", _definition.HospitalLevel.Key.ToString());
					text += requiresHospitalLevel_CS;
				}
				return text;
			}
		}

		public LoanOffer(Definition definition, LoanManager loanManager)
		{
			_definition = definition;
			_loanManager = loanManager;
			_loanAmount = definition.DefaultAmount;
		}

		public void Take()
		{
			Active = true;
			_remainingMonths = _definition.RepaymentPeriod;
			_outstandingBalance = _loanAmount;
			_loanManager.OnLoanStateChanged.InvokeSafe(this);
		}

		public void Repay()
		{
			Active = false;
			_loanManager.OnLoanStateChanged.InvokeSafe(this);
		}

		public int MakeMonthlyPayment()
		{
			_remainingMonths--;
			_outstandingBalance += MonthlyInterest;
			_outstandingBalance -= MonthlyRepayment;
			if (_remainingMonths == 0)
			{
				_loanManager.RepayLoan(this);
			}
			else
			{
				_loanManager.OnLoanStateChanged.InvokeSafe(this);
			}
			return MonthlyRepayment;
		}

		public void UpdateAvailability(int hospitalValue, int currentBalance, float reputation, int hospitalLevel)
		{
			bool flag = true;
			if (_definition.HospitalValue.Value && hospitalValue < _definition.HospitalValue.Key)
			{
				flag = false;
			}
			else if (_definition.Balance.Value && currentBalance < _definition.Balance.Key)
			{
				flag = false;
			}
			else if (_definition.Reputation.Value && reputation < _definition.Reputation.Key)
			{
				flag = false;
			}
			else if (_definition.HospitalLevel.Value && hospitalLevel < _definition.HospitalLevel.Key)
			{
				flag = false;
			}
			if (Available != flag)
			{
				Available = flag;
				_loanManager.OnLoanStateChanged.InvokeSafe(this);
			}
		}
	}
}
