using System;

namespace UltimateReplay
{
	[Serializable]
	[Flags]
	internal enum ReplayTransformFlags
	{
		LowPrecision = 1,
		Position = 2,
		Rotation = 4,
		Scale = 8,
		LocalPosition = 0x10,
		LocalRotation = 0x20
	}
}
