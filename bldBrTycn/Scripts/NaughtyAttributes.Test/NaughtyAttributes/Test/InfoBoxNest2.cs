using System;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class InfoBoxNest2
	{
		[InfoBox("Error", EInfoBoxType.Error)]
		public int error;
	}
}
