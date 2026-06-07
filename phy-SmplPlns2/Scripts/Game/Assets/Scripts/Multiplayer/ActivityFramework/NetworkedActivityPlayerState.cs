namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	public enum NetworkedActivityPlayerState : byte
	{
		Unknown = 0,
		NotReady = 1,
		Ready = 2,
		Starting = 3,
		Playing = 4,
		Ending = 5,
		Ended = 6,
		Spectating = 7
	}
}
