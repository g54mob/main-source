using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class HorizontalLineNest1
	{
		[HorizontalLine(2f, EColor.Gray)]
		public int line1;

		public HorizontalLineNest2 nest2;
	}
}
