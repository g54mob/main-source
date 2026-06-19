using UnityEngine;

namespace TH20
{
	public static class TerrainDataExtension
	{
		public static Vector3 WorldCoordToTerrain(this TerrainData terrainData, Vector3 worldCoord)
		{
			int heightmapResolution = terrainData.heightmapResolution;
			int heightmapResolution2 = terrainData.heightmapResolution;
			float x = worldCoord.x / terrainData.size.x * (float)heightmapResolution;
			float y = worldCoord.y / terrainData.size.y;
			float z = worldCoord.z / terrainData.size.z * (float)heightmapResolution2;
			return new Vector3(x, y, z);
		}

		public static Vector3 TerrainCoordToWorld(this TerrainData terrainData, Vector3 terrainCoord)
		{
			int heightmapResolution = terrainData.heightmapResolution;
			int heightmapResolution2 = terrainData.heightmapResolution;
			float x = terrainCoord.x * terrainData.size.x / (float)heightmapResolution;
			float y = terrainCoord.y * terrainData.size.y;
			float z = terrainCoord.z * terrainData.size.z / (float)heightmapResolution2;
			return new Vector3(x, y, z);
		}

		public static Vector3 WorldCoordToDetail(this TerrainData terrainData, Vector3 worldCoord)
		{
			int heightmapResolution = terrainData.heightmapResolution;
			int heightmapResolution2 = terrainData.heightmapResolution;
			float x = worldCoord.x / terrainData.size.x * (float)heightmapResolution;
			float z = worldCoord.z / terrainData.size.z * (float)heightmapResolution2;
			return new Vector3(x, 0f, z);
		}

		public static Vector3 DetailCoordToWorld(this TerrainData terrainData, Vector3 detailCoord)
		{
			int detailWidth = terrainData.detailWidth;
			int detailHeight = terrainData.detailHeight;
			float x = detailCoord.x * terrainData.size.x / (float)detailWidth;
			float z = detailCoord.z * terrainData.size.z / (float)detailHeight;
			return new Vector3(x, 0f, z);
		}
	}
}
