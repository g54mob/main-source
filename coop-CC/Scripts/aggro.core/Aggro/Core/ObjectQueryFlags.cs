using System;

namespace Aggro.Core
{
	[Flags]
	public enum ObjectQueryFlags : byte
	{
		ActiveAndEnabled = 1,
		InactiveOrDisabled = 2,
		AllObjects = 3
	}
}
