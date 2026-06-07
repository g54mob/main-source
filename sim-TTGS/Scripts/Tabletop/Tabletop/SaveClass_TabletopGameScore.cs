using System;

namespace Tabletop
{
	[Serializable]
	public class SaveClass_TabletopGameScore
	{
		public int miniatureBoxUnpacked;

		public int miniatureAssembled;

		public float paintingEarnings;

		public float wargameEarnings;

		public SaveClass_TabletopGameScore()
		{
			miniatureBoxUnpacked = 0;
			miniatureAssembled = 0;
			paintingEarnings = 0f;
			wargameEarnings = 0f;
		}
	}
}
