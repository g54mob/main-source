using System;

namespace Coherence.Common
{
	[Flags]
	public enum HostAuthority
	{
		CreateEntities = 1,
		ValidateConnection = 2,
		KickConnection = 4
	}
}
