namespace DV.ServicePenalty
{
	public class StagedOwnedCarDebt : DisplayableDebt
	{
		public readonly CarDebtData carDebtData;

		public override string ID => carDebtData.id;

		public override bool IsPayable => false;

		public override bool IsStaged => true;

		public StagedOwnedCarDebt(CarDebtData carDebtData)
		{
			this.carDebtData = carDebtData;
		}

		public override DebtType GetDebtType()
		{
			return DebtType.StagedOwnedCar;
		}

		public override float GetTotalPrice()
		{
			return carDebtData.GetTotalPriceOfDebt(IsTaxable, ignoreEnvironmentDamage: true);
		}

		public override CarDebtData[] GetCarDebts()
		{
			return new CarDebtData[1] { carDebtData };
		}
	}
}
