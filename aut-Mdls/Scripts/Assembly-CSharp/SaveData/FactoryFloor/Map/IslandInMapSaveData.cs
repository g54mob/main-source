using System;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveData.FactoryFloor.Map
{
	[Serializable]
	public class IslandInMapSaveData
	{
		[JsonProperty("x")]
		public int PositionX;

		[JsonProperty("y")]
		public int PositionY;

		[JsonProperty("z")]
		public int PositionZ;

		[JsonProperty("r")]
		public int Rotation;

		[JsonProperty("bi")]
		public int IslandBottomIndex;

		[JsonProperty("br")]
		public int IslandBottomRotation;

		[JsonProperty("gn")]
		public bool IsGNNGateIsland;

		[JsonProperty("id")]
		public Guid Id;

		[JsonIgnore]
		public Vector3Int Position => new Vector3Int(PositionX, PositionY, PositionZ);

		public IslandInMapSaveData()
		{
		}

		public IslandInMapSaveData(Vector3Int position, int rotation, int islandBottomIndex, int islandBottomRotation, bool isGnnGateIsland, Guid id)
		{
			PositionX = position.x;
			PositionY = position.y;
			PositionZ = position.z;
			Rotation = rotation;
			IslandBottomIndex = islandBottomIndex;
			IslandBottomRotation = islandBottomRotation;
			IsGNNGateIsland = isGnnGateIsland;
			Id = id;
		}
	}
}
