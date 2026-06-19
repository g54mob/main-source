namespace Energy
{
	public interface IEnergyConsumer
	{
		float RequestedEnergy { get; }

		bool IsActive { get; }

		void SupplyEnergy(float amount);
	}
}
