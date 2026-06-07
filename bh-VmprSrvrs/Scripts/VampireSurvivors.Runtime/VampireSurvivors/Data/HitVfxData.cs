using System;

namespace VampireSurvivors.Data
{
	[Serializable]
	public class HitVfxData
	{
		public bool isTintFill { get; set; }

		public int targetTint { get; set; }

		public string hitFrameName { get; set; }

		public string impactFrameName { get; set; }

		public int duration { get; set; }
	}
}
