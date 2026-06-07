using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Tilemap Tiled Img")]
	public class TilemapTiledIMG
	{
		[Title("Name")]
		public string name { get; set; }

		[Title("Path")]
		public string path { get; set; }
	}
}
