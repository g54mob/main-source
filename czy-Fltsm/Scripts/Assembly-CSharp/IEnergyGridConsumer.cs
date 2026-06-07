public interface IEnergyGridConsumer : IEnergyGridComponent
{
	float CurrentEnergyConsumption { get; }

	float EnergyRequirement { get; }
}
