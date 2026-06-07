using System;

namespace Cysharp.Threading.Tasks
{
	[Flags]
	public enum InjectPlayerLoopTimings
	{
		All = 0x3FFF,
		Standard = 0x3555,
		Minimum = 0x2110,
		Initialization = 1,
		LastInitialization = 2,
		EarlyUpdate = 4,
		LastEarlyUpdate = 8,
		FixedUpdate = 0x10,
		LastFixedUpdate = 0x20,
		PreUpdate = 0x40,
		LastPreUpdate = 0x80,
		Update = 0x100,
		LastUpdate = 0x200,
		PreLateUpdate = 0x400,
		LastPreLateUpdate = 0x800,
		PostLateUpdate = 0x1000,
		LastPostLateUpdate = 0x2000
	}
}
