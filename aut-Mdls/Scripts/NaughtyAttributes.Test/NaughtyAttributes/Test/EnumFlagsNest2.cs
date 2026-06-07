using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class EnumFlagsNest2
	{
		[EnumFlags]
		public TestEnum flags2;
	}
}
