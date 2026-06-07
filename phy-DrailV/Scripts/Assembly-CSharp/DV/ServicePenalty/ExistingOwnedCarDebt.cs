namespace DV.ServicePenalty
{
	public class ExistingOwnedCarDebt : DisplayableDebt
	{
		public readonly LocoDebtTrackerBase carDebtTrackerBase;

		public TrainCar car;

		public override string ID => carDebtTrackerBase.GetDebtData().id;

		public override bool IsPayable => false;

		public ExistingOwnedCarDebt(LocoDebtTrackerBase carDebtTrackerBase, TrainCar car)
		{
			this.carDebtTrackerBase = carDebtTrackerBase;
			this.car = car;
		}

		public override DebtType GetDebtType()
		{
			return DebtType.ExistingOwnedCar;
		}

		public override float GetTotalPrice()
		{
			return carDebtTrackerBase.GetCurrentTotalPriceOfDebt(IsTaxable, ignoreEnvironmentDamage: true);
		}

		public override CarDebtData[] GetCarDebts()
		{
			return new CarDebtData[1] { carDebtTrackerBase.GetDebtData() };
		}

		public override void UpdateDebtState()
		{
			carDebtTrackerBase.UpdateDebtValues();
		}
	}
}
