using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Hard Bounds")]
	public class HardBounds
	{
		[Title("X")]
		public float x { get; set; }

		[Title("Y")]
		public float y { get; set; }

		[Title("Width")]
		public float width { get; set; }

		[Title("Height")]
		public float height { get; set; }
	}
}
