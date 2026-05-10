using System;

namespace NaughtyAttributes.Test
{
	[Flags]
	public enum DisableIfEnumFlag
	{
		Flag0 = 1,
		Flag1 = 2,
		Flag2 = 4,
		Flag3 = 8
	}
}
