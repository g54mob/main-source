using System;
using Poncle.Schema.Attributes.Attributes;

namespace VampireSurvivors.Data.Stage
{
	[Serializable]
	[Title("Tile Set")]
	public class Tileset
	{
		[Title("Set Key")]
		public string setKey { get; set; }

		[Title("Set Path")]
		public string setPath { get; set; }

		[Title("Map Key")]
		public string mapKey { get; set; }

		[Title("Map Path")]
		public string mapPath { get; set; }

		[Title("Is Tiling")]
		public bool isTiling { get; set; }

		[Title("Is Horizontal Road")]
		public bool isHorizontalRoad { get; set; }

		[Title("Has Walls Check Destructible Logic")]
		public bool hasWallsCheckDestructibleLogic { get; set; }

		[Title("Size X")]
		public float? SizeX { get; set; }

		[Title("Size Y")]
		public float? SizeY { get; set; }

		[Title("Min Treasure X")]
		public float? minTreasureX { get; set; }

		[Title("Max Treasure X")]
		public float? maxTreasureX { get; set; }

		[Title("Min Treasure Y")]
		public float? minTreasureY { get; set; }

		[Title("Max Treasure Y")]
		public float? maxTreasureY { get; set; }

		[Title("Tint")]
		[Minimum(0f)]
		public uint? tint { get; set; }

		[Title("Map Relic")]
		public ItemType? mapRelic { get; set; }

		[Title("Details Texture")]
		public string detailsTexture { get; set; }

		public HardBounds hardBounds { get; set; }
	}
}
