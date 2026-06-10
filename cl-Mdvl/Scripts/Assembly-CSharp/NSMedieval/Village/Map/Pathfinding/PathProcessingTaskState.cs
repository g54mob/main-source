namespace NSMedieval.Village.Map.Pathfinding
{
	public enum PathProcessingTaskState
	{
		None = 0,
		WaitingToProcess = 1,
		Processing = 2,
		Completed = 3,
		Failed = 4,
		Error = 5,
		Aborted = 6
	}
}
