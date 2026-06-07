using System;
using System.Collections.Generic;
using UnityEngine;
using Utils.JsonConverterUtils;

namespace SaveData.FactoryFloor.Island
{
	[Serializable]
	public class IslandSaveData
	{
		public List<SavedObjectDto> FactorySavedObjectDtos = new List<SavedObjectDto>();

		public List<SavedObjectDto> TerrainSavedObjectDtos = new List<SavedObjectDto>();

		public Vector2Int Size;

		public Color32[] FloorTextureColors;

		public Vector3IntSerlializableDictionary BrushPositions = new Vector3IntSerlializableDictionary();

		public string Guid;

		public IslandSaveData()
		{
		}

		public IslandSaveData(string guid, List<SavedObjectDto> factorySavedObjectDtos, List<SavedObjectDto> terrainSavedObjectDtos, Vector2Int size, Color32[] floorTextureColors, Dictionary<Vector3Int, int> brushPositions)
		{
			Guid = guid;
			FactorySavedObjectDtos = factorySavedObjectDtos;
			TerrainSavedObjectDtos = terrainSavedObjectDtos;
			Size = size;
			FloorTextureColors = floorTextureColors;
			BrushPositions = new Vector3IntSerlializableDictionary();
			foreach (KeyValuePair<Vector3Int, int> brushPosition in brushPositions)
			{
				BrushPositions.Add(brushPosition.Key, brushPosition.Value);
			}
		}
	}
}
