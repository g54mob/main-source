using DV.ThingTypes;

public class TransportJobDefinitionData : JobDefinitionDataBase
{
	public string[] transportCarGuids;

	public string startTrackId;

	public string destinationTrackId;

	public CargoType[] transportedCargoPerCar;

	public float[] cargoAmountPerCar;

	public TransportJobDefinitionData(float timeLimitForJob, float initialWage, string stationId, string originStationId, string destinationStationId, int requiredLicenses, string[] transportCarGuids, CargoType[] transportedCargoPerCar, float[] cargoAmountPerCar, string startTrackId, string destinationTrackId)
		: base(timeLimitForJob, initialWage, stationId, originStationId, destinationStationId, requiredLicenses)
	{
		this.transportCarGuids = transportCarGuids;
		this.transportedCargoPerCar = transportedCargoPerCar;
		this.cargoAmountPerCar = cargoAmountPerCar;
		this.startTrackId = startTrackId;
		this.destinationTrackId = destinationTrackId;
	}
}
