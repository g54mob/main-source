namespace Energy
{
	public class DefaultEnergyConsumer : IEnergyConsumer
	{
		private readonly float _energyConsumptionRate;

		public float RequestedEnergy => _energyConsumptionRate;

		public bool IsActive => true;

		public DefaultEnergyConsumer(float energyConsumptionRate)
		{
			_energyConsumptionRate = energyConsumptionRate;
		}

		public void SupplyEnergy(float amount)
		{
		}
	}
}
