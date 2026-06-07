using UnityEngine;

namespace RLD
{
	public static class TerrainEx
	{
		public static Vector2 ToNormCoords(this Terrain terrain, Vector3 worldPos)
		{
			Vector3 vector = Vector3.Scale(worldPos - terrain.transform.position, new Vector3(1f / terrain.terrainData.size.x, 1f, 1f / terrain.terrainData.size.z));
			return new Vector2(vector.x, vector.z);
		}

		public static Vector3 GetInterpolatedNormal(this Terrain terrain, Vector3 worldPos)
		{
			Vector2 vector = terrain.ToNormCoords(worldPos);
			return terrain.terrainData.GetInterpolatedNormal(vector.x, vector.y);
		}
	}
}
