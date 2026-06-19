using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TH20
{
	public class LoanManager : MustCallDestroy, IGameEventsBase
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public LoanOffer.Definition[] LoanOffers;
		}

		private readonly List<LoanOffer> _offers;

		private readonly Level _level;

		public Action<LoanOffer> OnTakeOutLoan;

		public Action<LoanOffer> OnRepayLoan;

		public Action<LoanOffer> OnLoanStateChanged;

		public Action<int, int> OnMonthlyPayment;

		private int _hospitalValue;

		private int _hospitalLevel;

		private int _currentBalance;

		private float _reputation;

		public List<LoanOffer> Offers => _offers;

		public LoanManager(Config config, Level level)
		{
			GameEventsRegistry.RegisterLevelEvent(this);
			_level = level;
			if (config.LoanOffers != null)
			{
				_offers = new List<LoanOffer>(config.LoanOffers.Length);
				LoanOffer.Definition[] loanOffers = config.LoanOffers;
				foreach (LoanOffer.Definition definition in loanOffers)
				{
					_offers.Add(new LoanOffer(definition, this));
				}
			}
			LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
			Refresh(levelStatsDatabase.HospitalValue, levelStatsDatabase.CurrentBalance, levelStatsDatabase.HospitalLevel);
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		public override void Destroy()
		{
			UnregisterEvents();
			base.Destroy();
		}

		private void RegisterEvents()
		{
			TimelineManager timelineManager = _level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Combine(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Combine(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthlyStatsUpdated));
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Combine(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
		}

		private void UnregisterEvents()
		{
			TimelineManager timelineManager = _level.TimelineManager;
			timelineManager.OnTimelineUpdated = (Action<int, int, int>)Delegate.Remove(timelineManager.OnTimelineUpdated, new Action<int, int, int>(OnTimelineUpdated));
			LevelStatsDatabase levelStatsDatabase = _level.LevelStatsDatabase;
			levelStatsDatabase.OnMonthCompleted = (Action<LevelStatsDatabase.MonthStats>)Delegate.Remove(levelStatsDatabase.OnMonthCompleted, new Action<LevelStatsDatabase.MonthStats>(OnMonthlyStatsUpdated));
			ReputationTracker reputationTracker = _level.ReputationTracker;
			reputationTracker.OnReputationChangedEvent = (Action<float>)Delegate.Remove(reputationTracker.OnReputationChangedEvent, new Action<float>(OnReputationChangedEvent));
		}

		public void VerifyEvents()
		{
			OnTakeOutLoan.VerifyIsNull();
			OnRepayLoan.VerifyIsNull();
			OnMonthlyPayment.VerifyIsNull();
			OnLoanStateChanged.VerifyIsNull();
		}

		private void OnTimelineUpdated(int day, int month, int year)
		{
			if (day != 0)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (LoanOffer offer in _offers)
			{
				if (offer.Active)
				{
					int num3 = offer.MakeMonthlyPayment();
					int monthlyInterest = offer.MonthlyInterest;
					num += num3 - monthlyInterest;
					num2 += monthlyInterest;
				}
			}
			if (num != 0)
			{
				OnMonthlyPayment.InvokeSafe(num, num2);
			}
		}

		public void TakeOutLoan(LoanOffer offer)
		{
			offer.Take();
			OnTakeOutLoan.InvokeSafe(offer);
		}

		public void RepayLoan(LoanOffer offer)
		{
			offer.Repay();
			OnRepayLoan.InvokeSafe(offer);
		}

		private void OnMonthlyStatsUpdated(LevelStatsDatabase.MonthStats stats)
		{
			Refresh(stats.HospitalValue, stats.Balance, stats.HospitalLevel);
		}

		private void Refresh(int hospitalValue, int currentBalance, int hospitalLevel)
		{
			_hospitalValue = hospitalValue;
			_hospitalLevel = hospitalLevel;
			_currentBalance = currentBalance;
			ValidateOffers();
		}

		private void OnReputationChangedEvent(float reputation)
		{
			_reputation = reputation;
			ValidateOffers();
		}

		private void ValidateOffers()
		{
			foreach (LoanOffer offer in _offers)
			{
				offer.UpdateAvailability(_hospitalValue, _currentBalance, _reputation, _hospitalLevel);
			}
		}
	}
}
