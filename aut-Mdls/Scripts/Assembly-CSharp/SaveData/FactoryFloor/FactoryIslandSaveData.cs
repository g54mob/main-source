using Data.FactoryFloor.Islands;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor
{
	public class FactoryIslandSaveData
	{
		[JsonProperty("s")]
		public Vector2Int Size;

		[JsonProperty("ft")]
		public Color32[] FloorTextureColors;

		[JsonProperty("id")]
		public string Guid;

		public FactoryIslandSaveData()
		{
		}

		public FactoryIslandSaveData(Vector2Int size, Color32[] floorTextureColors, string guid)
		{
			Size = size;
			FloorTextureColors = floorTextureColors;
			Guid = guid;
		}

		public FactoryIslandSaveData(IslandData island)
		{
			Size = island.Size;
			FloorTextureColors = island.GetFloorTextureToArray();
			Guid = island.Id.ToString();
		}
	}
}
