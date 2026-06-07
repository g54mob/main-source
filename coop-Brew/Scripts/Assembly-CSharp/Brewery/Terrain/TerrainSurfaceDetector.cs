using UnityEngine;

namespace Brewery.Terrain
{
	public static class TerrainSurfaceDetector
	{
		private static UnityEngine.Terrain _terrain;

		private static TerrainData _terrainData;

		private static float[,,] _alphamaps;

		private static int _alphaW;

		private static int _alphaH;

		private static int _layerCount;

		private static Vector3 _terrainPos;

		private static Vector3 _terrainSize;

		public static int[] GravelLayerIndices;

		public static void EnsureInitialized()
		{
		}

		public static bool IsOnLayers(Vector3 worldPos, int[] layerIndices, float threshold = 0.4f)
		{
			return false;
		}

		public static float GetLayerWeight(Vector3 worldPos, int[] layerIndices)
		{
			return 0f;
		}

		public static bool IsOnTerrain(Vector3 worldPos)
		{
			return false;
		}

		private static void WorldToAlphamap(Vector3 worldPos, out int ax, out int az)
		{
			ax = default(int);
			az = default(int);
		}
	}
}
