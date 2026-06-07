namespace R3
{
	internal enum PlayerLoopTiming
	{
		Initialization = 0,
		EarlyUpdate = 1,
		FixedUpdate = 2,
		PreUpdate = 3,
		Update = 4,
		PreLateUpdate = 5,
		PostLateUpdate = 6,
		TimeUpdate = 7,
		PostFixedUpdate = 8
	}
}
