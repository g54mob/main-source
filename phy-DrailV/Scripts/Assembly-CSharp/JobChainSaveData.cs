public class JobChainSaveData
{
	public JobDefinitionDataBase[] jobChainData;

	public string[] trainCarGuids;

	public bool jobTaken;

	public TaskSaveData[] currentJobTaskData;

	public string firstJobId;

	public JobChainSaveData(JobDefinitionDataBase[] jobChainData, string[] carGuids, bool jobTaken, TaskSaveData[] currentJobTaskData, string firstJobId)
	{
		this.jobChainData = jobChainData;
		trainCarGuids = carGuids;
		this.jobTaken = jobTaken;
		this.currentJobTaskData = currentJobTaskData;
		this.firstJobId = firstJobId;
	}
}
