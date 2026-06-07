using System;

namespace UltimateReplay
{
	[Serializable]
	[Flags]
	internal enum ReplayBehaviourDataFlags : byte
	{
		None = 0,
		Variables = 1,
		Events = 2
	}
}
