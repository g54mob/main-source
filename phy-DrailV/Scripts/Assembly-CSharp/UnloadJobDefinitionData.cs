public class UnloadJobDefinitionData : JobDefinitionDataBase
{
	public string startingTrackId;

	public CarGuidsPerTrackId[] carGuidsPerDestinationTrackId;

	public CarGuidsPerCargo[] carGuidsPerUnloadCargo;

	public string unloadMachineId;

	public UnloadJobDefinitionData(float timeLimitForJob, float initialWage, string stationId, string originStationId, string destinationStationId, int requiredLicenses, string startingTrackId, CarGuidsPerTrackId[] carGuidsPerDestinationTrackId, CarGuidsPerCargo[] carGuidsPerUnloadCargo, string unloadMachineId)
		: base(timeLimitForJob, initialWage, stationId, originStationId, destinationStationId, requiredLicenses)
	{
		this.startingTrackId = startingTrackId;
		this.carGuidsPerDestinationTrackId = carGuidsPerDestinationTrackId;
		this.carGuidsPerUnloadCargo = carGuidsPerUnloadCargo;
		this.unloadMachineId = unloadMachineId;
	}
}
