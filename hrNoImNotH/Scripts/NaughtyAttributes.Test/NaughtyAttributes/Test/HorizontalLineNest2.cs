using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class HorizontalLineNest2
	{
		[HorizontalLine(2f, EColor.Gray)]
		public int line2;
	}
}
