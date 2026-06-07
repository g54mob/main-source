using System;
using DV.Logic.Job;
using DV.Utils;

namespace DV.ServicePenalty
{
	public class ExistingJobDebt : DisplayableDebt
	{
		public readonly JobDebtTracker jobDebtTracker;

		public readonly Job job;

		public override string ID => jobDebtTracker.id;

		public ExistingJobDebt(JobDebtTracker jobDebtTracker, Job job)
		{
			this.jobDebtTracker = jobDebtTracker;
			this.job = job;
		}

		public void LoadActivationTime(DateTime savedActivationTime)
		{
			SetActivationTime(savedActivationTime);
		}

		public override DebtType GetDebtType()
		{
			return DebtType.ExistingJob;
		}

		public override float GetTotalPrice()
		{
			return jobDebtTracker.GetCurrentTotalPriceOfDebt(IsTaxable);
		}

		public override CarDebtData[] GetCarDebts()
		{
			return jobDebtTracker.GetCarDebts();
		}

		public override void Pay()
		{
			base.Pay();
			SingletonBehaviour<JobDebtController>.Instance.PayExistingJobDebt(this);
			ClearActivationTime();
		}

		public override void UpdateDebtState()
		{
			jobDebtTracker.UpdateDebtValues();
			UpdateActivationTime();
		}
	}
}
