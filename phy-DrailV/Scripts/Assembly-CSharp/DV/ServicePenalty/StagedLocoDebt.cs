using System;
using DV.Utils;

namespace DV.ServicePenalty
{
	public class StagedLocoDebt : DisplayableDebt
	{
		public readonly CarDebtData locoDebtData;

		public override string ID => locoDebtData.id;

		public override bool IsTaxable => true;

		public override bool IsStaged => true;

		public StagedLocoDebt(CarDebtData locoDebtData, DateTime activationTime)
		{
			this.locoDebtData = locoDebtData;
			SetActivationTime(activationTime);
		}

		public override DebtType GetDebtType()
		{
			return DebtType.StagedLoco;
		}

		public override float GetTotalPrice()
		{
			return locoDebtData.GetTotalPriceOfDebt(IsTaxable);
		}

		public override CarDebtData[] GetCarDebts()
		{
			return new CarDebtData[1] { locoDebtData };
		}

		public override void Pay()
		{
			base.Pay();
			SingletonBehaviour<LocoDebtController>.Instance.PayStagedLocoDebt(this);
		}
	}
}
