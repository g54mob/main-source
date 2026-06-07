public class LoadJobDefinitionData : JobDefinitionDataBase
{
	public CarGuidsPerTrackId[] carGuidsPerStartingTrackId;

	public CarGuidsPerCargo[] carGuidsPerLoadCargo;

	public string loadMachineId;

	public string destinationTrackId;

	public LoadJobDefinitionData(float timeLimitForJob, float initialWage, string stationId, string originStationId, string destinationStationId, int requiredLicenses, CarGuidsPerTrackId[] carGuidsPerStartingTrackId, CarGuidsPerCargo[] carGuidsPerLoadCargo, string loadMachineId, string destinationTrackId)
		: base(timeLimitForJob, initialWage, stationId, originStationId, destinationStationId, requiredLicenses)
	{
		this.carGuidsPerStartingTrackId = carGuidsPerStartingTrackId;
		this.carGuidsPerLoadCargo = carGuidsPerLoadCargo;
		this.loadMachineId = loadMachineId;
		this.destinationTrackId = destinationTrackId;
	}
}
