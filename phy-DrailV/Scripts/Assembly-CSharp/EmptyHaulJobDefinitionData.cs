public class EmptyHaulJobDefinitionData : JobDefinitionDataBase
{
	public string[] transportCarGuids;

	public string startTrackId;

	public string destinationTrackId;

	public EmptyHaulJobDefinitionData(float timeLimitForJob, float initialWage, string stationId, string originStationId, string destinationStationId, int requiredLicenses, string[] transportCarGuids, string startTrackId, string destinationTrackId)
		: base(timeLimitForJob, initialWage, stationId, originStationId, destinationStationId, requiredLicenses)
	{
		this.transportCarGuids = transportCarGuids;
		this.startTrackId = startTrackId;
		this.destinationTrackId = destinationTrackId;
	}
}
