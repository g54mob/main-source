using System;

namespace Aggro.Core
{
	[Flags]
	public enum EntityWorldFlags : byte
	{
		CreateBasicUpdater = 1,
		GameObjectWorld = 2
	}
}
