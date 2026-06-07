namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public enum NetworkedActivityState : byte
	{
		Unknown = 0,
		Created = 1,
		Initialized = 2,
		Starting = 3,
		Started = 4,
		Ending = 5,
		Ended = 6,
		Destroyed = 7
	}
}
