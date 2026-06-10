namespace TwitchSDK.Interop
{
	public enum PollStatus : byte
	{
		Active = 0,
		Completed = 1,
		Terminated = 2,
		Archived = 3,
		Moderated = 4,
		Invalid = 5
	}
}
