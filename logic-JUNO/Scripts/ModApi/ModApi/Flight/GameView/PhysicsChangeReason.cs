namespace ModApi.Flight.GameView
{
	public enum PhysicsChangeReason
	{
		FlightEnd = 0,
		LoadedIntoGameView = 1,
		LoadPhysics = 2,
		UnloadedFromGameView = 3,
		UnloadPhysics = 4,
		Warp = 5
	}
}
