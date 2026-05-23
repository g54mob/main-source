using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class InfoBoxNest1
	{
		[InfoBox("Warning", EInfoBoxType.Warning)]
		public int warning;

		public InfoBoxNest2 nest2;
	}
}
