public interface IEnergyGridComponentPersistentData
{
	PersistentReference<EnergyGrid>.Reference EnergyGridReference { get; }

	EnergyGridConnector[] GetEnergyLinks();
}
