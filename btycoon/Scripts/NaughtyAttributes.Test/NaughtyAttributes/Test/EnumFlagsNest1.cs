using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class EnumFlagsNest1
	{
		[EnumFlags]
		public TestEnum flags1;

		public EnumFlagsNest2 nest2;
	}
}
