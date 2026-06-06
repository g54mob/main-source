public interface IEnergyGridComponent
{
	EnergyGridConnector Connector { get; set; }

	EnergyGrid EnergyGrid { get; }

	void AddToEnergyGrid(EnergyGrid grid);

	void RemoveFromEnergyGrid(EnergyGrid grid);

	EnergyGridOverviewSlotUI ReturnUI();
}
