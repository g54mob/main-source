using System;
using DV.Utils;

namespace DV.ServicePenalty
{
	public class ExistingLocoDebt : DisplayableDebt
	{
		public readonly LocoDebtTrackerBase locoDebtTracker;

		public TrainCar car;

		public override string ID => locoDebtTracker.GetDebtData().id;

		public override bool IsTaxable => true;

		public ExistingLocoDebt(TrainCar car, LocoDebtTrackerBase locoDebtTracker)
		{
			this.car = car;
			this.locoDebtTracker = locoDebtTracker;
		}

		public void LoadActivationTime(DateTime savedActivationTime)
		{
			SetActivationTime(savedActivationTime);
		}

		public override DebtType GetDebtType()
		{
			return DebtType.ExistingLoco;
		}

		public override float GetTotalPrice()
		{
			return locoDebtTracker.GetCurrentTotalPriceOfDebt(IsTaxable);
		}

		public override CarDebtData[] GetCarDebts()
		{
			return new CarDebtData[1] { locoDebtTracker.GetDebtData() };
		}

		public override void Pay()
		{
			base.Pay();
			SingletonBehaviour<LocoDebtController>.Instance.PayExistingLocoDebt(this);
			ClearActivationTime();
		}

		public override void UpdateDebtState()
		{
			locoDebtTracker.UpdateDebtValues();
			UpdateActivationTime();
		}
	}
}
