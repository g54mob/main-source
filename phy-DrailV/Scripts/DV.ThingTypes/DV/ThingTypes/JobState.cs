namespace DV.ThingTypes
{
	public enum JobState : byte
	{
		Available = 0,
		InProgress = 1,
		Completed = 2,
		Abandoned = 3,
		Failed = 4,
		Expired = 5
	}
}
