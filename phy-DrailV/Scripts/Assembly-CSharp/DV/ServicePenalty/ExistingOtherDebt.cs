using System;
using System.Collections.Generic;
using System.Linq;
using DV.Localization;
using DV.Utils;

namespace DV.ServicePenalty
{
	public class ExistingOtherDebt : DisplayableDebt
	{
		private const string ID_LOCALIZATION_KEY = "fees/idle_cars";

		public readonly List<DebtTrackerCar> joblessCarsTrackers;

		private readonly string localizedId;

		public int NumberOfDebts => joblessCarsTrackers.Count;

		public override string ID => localizedId;

		public ExistingOtherDebt()
		{
			joblessCarsTrackers = new List<DebtTrackerCar>();
			localizedId = LocalizationAPI.L("fees/idle_cars");
		}

		public void LoadActivationTime(DateTime savedActivationTime)
		{
			SetActivationTime(savedActivationTime);
		}

		public void AddJoblessCarTracker(DebtTrackerCar carTracker)
		{
			joblessCarsTrackers.Add(carTracker);
		}

		public bool RemoveJoblessCarTracker(DebtTrackerCar carTracker)
		{
			bool result = joblessCarsTrackers.Remove(carTracker);
			if (NumberOfDebts == 0)
			{
				ClearActivationTime();
			}
			return result;
		}

		public override DebtType GetDebtType()
		{
			return DebtType.ExistingOther;
		}

		public override float GetTotalPrice()
		{
			float num = 0f;
			foreach (DebtTrackerCar joblessCarsTracker in joblessCarsTrackers)
			{
				num += joblessCarsTracker.GetCurrentTotalPriceOfDebt(IsTaxable);
			}
			return num;
		}

		public override CarDebtData[] GetCarDebts()
		{
			return joblessCarsTrackers.Select((DebtTrackerCar t) => t.GetDebtData()).ToArray();
		}

		public override void Pay()
		{
			base.Pay();
			SingletonBehaviour<JobDebtController>.Instance.PayExistingJoblessCarsDebt();
			ClearActivationTime();
		}

		public override void UpdateDebtState()
		{
			foreach (DebtTrackerCar joblessCarsTracker in joblessCarsTrackers)
			{
				joblessCarsTracker.UpdateDebtValues();
			}
			UpdateActivationTime();
		}
	}
}
