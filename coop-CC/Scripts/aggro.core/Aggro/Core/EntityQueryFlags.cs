using System;

namespace Aggro.Core
{
	[Flags]
	public enum EntityQueryFlags : byte
	{
		EnabledEntities = 1,
		DisabledEntities = 2,
		InactiveBehaviours = 4,
		AliveEntities = 8,
		DyingEntities = 0x10,
		Default = 9,
		All = byte.MaxValue
	}
}
