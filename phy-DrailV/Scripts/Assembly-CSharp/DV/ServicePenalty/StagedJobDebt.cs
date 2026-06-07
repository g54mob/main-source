using System;
using DV.Utils;

namespace DV.ServicePenalty
{
	public class StagedJobDebt : DisplayableDebt
	{
		public readonly JobDebtData jobDebtData;

		public override string ID => jobDebtData.id;

		public override bool IsStaged => true;

		public StagedJobDebt(JobDebtData jobDebtData, DateTime activationTime)
		{
			this.jobDebtData = jobDebtData;
			SetActivationTime(activationTime);
		}

		public override DebtType GetDebtType()
		{
			return DebtType.StagedJob;
		}

		public override float GetTotalPrice()
		{
			return jobDebtData.GetTotalPriceOfDebt(IsTaxable);
		}

		public override CarDebtData[] GetCarDebts()
		{
			return jobDebtData.GetCarsDebts();
		}

		public override void Pay()
		{
			base.Pay();
			SingletonBehaviour<JobDebtController>.Instance.PayStagedJobDebt(this);
		}
	}
}
