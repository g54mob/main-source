using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Tilemap Pos")]
	public class TilemapPos
	{
		[Title("X")]
		public float x { get; set; }

		[Title("Y")]
		public float y { get; set; }
	}
}
