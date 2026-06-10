namespace NSMedieval.State
{
	public enum ProductionState
	{
		None = 0,
		Paused = 1,
		TargetReached = 2,
		NoSkilledWorker = 3,
		WaitingForResources = 4,
		WaitingForWorker = 5,
		InProgress = 6
	}
}
