using System;

namespace VampireSurvivors.Framework.DLC
{
	[Serializable]
	public class BundleDlcData
	{
		public bool _Steam;

		public bool _Xbox;

		public bool _Switch;

		public bool _Android;

		public bool _iOS;

		public bool _AppleArcade;

		public bool _PlayStation;

		public bool IsIncludedWithBaseGame()
		{
			return false;
		}
	}
}
