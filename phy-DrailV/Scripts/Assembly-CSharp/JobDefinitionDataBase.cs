public abstract class JobDefinitionDataBase
{
	public float timeLimitForJob;

	public float initialWage;

	public string stationId;

	public string originStationId;

	public string destinationStationId;

	public int requiredLicenses;

	public JobDefinitionDataBase(float timeLimitForJob, float initialWage, string stationId, string originStationId, string destinationStationId, int requiredLicenses)
	{
		this.timeLimitForJob = timeLimitForJob;
		this.initialWage = initialWage;
		this.stationId = stationId;
		this.originStationId = originStationId;
		this.destinationStationId = destinationStationId;
		this.requiredLicenses = requiredLicenses;
	}
}
