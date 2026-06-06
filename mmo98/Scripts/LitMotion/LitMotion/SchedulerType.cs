namespace LitMotion
{
	internal enum SchedulerType : byte
	{
		Default = 0,
		Initialization = 1,
		InitializationIgnoreTimeScale = 2,
		InitializationRealtime = 3,
		EarlyUpdate = 4,
		EarlyUpdateIgnoreTimeScale = 5,
		EarlyUpdateRealtime = 6,
		FixedUpdate = 7,
		PreUpdate = 8,
		PreUpdateIgnoreTimeScale = 9,
		PreUpdateRealtime = 10,
		Update = 11,
		UpdateIgnoreTimeScale = 12,
		UpdateRealtime = 13,
		PreLateUpdate = 14,
		PreLateUpdateIgnoreTimeScale = 15,
		PreLateUpdateRealtime = 16,
		PostLateUpdate = 17,
		PostLateUpdateIgnoreTimeScale = 18,
		PostLateUpdateRealtime = 19,
		TimeUpdate = 20,
		TimeUpdateIgnoreTimeScale = 21,
		TimeUpdateRealtime = 22,
		Manual = 23
	}
}
