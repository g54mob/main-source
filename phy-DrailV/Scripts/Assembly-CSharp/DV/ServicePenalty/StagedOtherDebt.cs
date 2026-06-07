using System;
using System.Collections.Generic;
using DV.Localization;
using DV.Utils;

namespace DV.ServicePenalty
{
	public class StagedOtherDebt : DisplayableDebt
	{
		private const string ID_LOCALIZATION_KEY = "fees/archive";

		public readonly List<CarDebtData> joblessCarsDebtData;

		private readonly string localizedId;

		public int NumberOfDebts => joblessCarsDebtData.Count;

		public override string ID => localizedId;

		public override bool IsStaged => true;

		public StagedOtherDebt()
		{
			joblessCarsDebtData = new List<CarDebtData>();
			localizedId = LocalizationAPI.L("fees/archive");
		}

		public void AddJoblessCarDebt(CarDebtData carDebt)
		{
			joblessCarsDebtData.Add(carDebt);
			if (NumberOfDebts == 1)
			{
				ActivationTimeToCurrentTime();
			}
		}

		public void ClearDebts()
		{
			joblessCarsDebtData.Clear();
			ClearActivationTime();
		}

		public void LoadJoblessCarDebtData(List<CarDebtData> debts, DateTime activationTime)
		{
			joblessCarsDebtData.Clear();
			joblessCarsDebtData.AddRange(debts);
			SetActivationTime(activationTime);
		}

		public override DebtType GetDebtType()
		{
			return DebtType.StagedOther;
		}

		public override float GetTotalPrice()
		{
			float num = 0f;
			foreach (CarDebtData joblessCarsDebtDatum in joblessCarsDebtData)
			{
				num += joblessCarsDebtDatum.GetTotalPriceOfDebt(IsTaxable);
			}
			return num;
		}

		public override CarDebtData[] GetCarDebts()
		{
			return joblessCarsDebtData.ToArray();
		}

		public override void Pay()
		{
			base.Pay();
			SingletonBehaviour<JobDebtController>.Instance.PayStagedJoblessCarsDebt();
		}
	}
}
