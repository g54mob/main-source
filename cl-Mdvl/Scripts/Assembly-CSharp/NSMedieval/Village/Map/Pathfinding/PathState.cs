namespace NSMedieval.Village.Map.Pathfinding
{
	public enum PathState
	{
		None = 0,
		Constructed = 1,
		Initialized = 2,
		Processing = 3,
		Calculated = 4,
		ProcessingError = 5,
		Abort = 6
	}
}
