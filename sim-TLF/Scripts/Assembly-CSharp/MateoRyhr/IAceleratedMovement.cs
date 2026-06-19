namespace MateoRyhr
{
	public interface IAceleratedMovement : IMovement
	{
		float TimeToReachMaxSpeed { get; }

		float TimeToStop { get; }
	}
}
