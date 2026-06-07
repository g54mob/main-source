using UnityEngine;

namespace JBooth.MicroVerseCore
{
	public class StampData
	{
		public Terrain terrain;

		public float RealHeight => terrain.terrainData.heightmapScale.y * 2f;

		public Matrix4x4 WorldToTerrainMatrix => terrain.transform.worldToLocalMatrix;

		public Vector2 RealSize => new Vector2(terrain.terrainData.heightmapScale.x * (float)terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapScale.z * (float)terrain.terrainData.heightmapResolution);

		public StampData(Terrain terrain)
		{
			this.terrain = terrain;
		}
	}
}
