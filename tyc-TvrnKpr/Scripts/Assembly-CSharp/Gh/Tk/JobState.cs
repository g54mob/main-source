namespace Gh.Tk
{
	public enum JobState
	{
		NotStarted = 0,
		Running = 1,
		Finished = 2,
		HandedOverToSubJob = 3,
		Error = 4,
		Aborting = 5,
		Aborted = 6
	}
}
