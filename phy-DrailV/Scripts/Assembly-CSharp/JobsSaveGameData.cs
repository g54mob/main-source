public class JobsSaveGameData
{
	public JobChainSaveData[] jobChains;

	public float logicTimer;

	public JobsSaveGameData(JobChainSaveData[] jobChains, float logicTimer)
	{
		this.jobChains = jobChains;
		this.logicTimer = logicTimer;
	}
}
