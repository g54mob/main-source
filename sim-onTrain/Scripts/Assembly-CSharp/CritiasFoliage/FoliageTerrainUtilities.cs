using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageTerrainUtilities
	{
		public static Vector3 TerrainNormalizedToTerrainLocalPos(Vector3 terrainNormalizedLocalPos, Terrain terrain)
		{
			Vector3 size = terrain.terrainData.size;
			return new Vector3(Mathf.Lerp(0f, size.x, terrainNormalizedLocalPos.x), Mathf.Lerp(0f, size.y, terrainNormalizedLocalPos.y), Mathf.Lerp(0f, size.z, terrainNormalizedLocalPos.z));
		}

		public static Vector3 TerrainNormalizedToWorldPos(Vector3 terrainNormalizedLocalPos, Terrain terrain)
		{
			Vector3 size = terrain.terrainData.size;
			return new Vector3(Mathf.Lerp(0f, size.x, terrainNormalizedLocalPos.x), Mathf.Lerp(0f, size.y, terrainNormalizedLocalPos.y), Mathf.Lerp(0f, size.z, terrainNormalizedLocalPos.z)) + terrain.transform.position;
		}

		public static Vector3 TerrainLocalToTerrainNormalizedPos(Vector3 terrainLocalPos, Terrain terrain)
		{
			return new Vector3(Mathf.InverseLerp(0f, terrain.terrainData.size.x, terrainLocalPos.x), Mathf.InverseLerp(0f, terrain.terrainData.size.y, terrainLocalPos.y), Mathf.InverseLerp(0f, terrain.terrainData.size.z, terrainLocalPos.z));
		}

		public static Vector3 WorldToTerrainNormalizedPos(Vector3 worldPos, Terrain terrain)
		{
			Vector3 vector = terrain.transform.InverseTransformPoint(worldPos);
			return new Vector3(Mathf.InverseLerp(0f, terrain.terrainData.size.x, vector.x), Mathf.InverseLerp(0f, terrain.terrainData.size.y, vector.y), Mathf.InverseLerp(0f, terrain.terrainData.size.z, vector.z));
		}

		public static Vector3 TerrainNormal(Vector3 terrainNormalizedPos, Terrain terrain)
		{
			return terrain.terrainData.GetInterpolatedNormal(terrainNormalizedPos.x, terrainNormalizedPos.z);
		}

		public static float TerrainHeight(Vector3 terrainNormalizedPos, Terrain terrain)
		{
			return terrain.terrainData.GetInterpolatedHeight(terrainNormalizedPos.x, terrainNormalizedPos.z);
		}
	}
}
