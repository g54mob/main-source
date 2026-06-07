using System.Collections.Generic;
using UnityEngine;

namespace Digger.Modules.Core.Sources.TerrainInterface
{
	public class HeightsFeeder
	{
		private readonly Dictionary<Vector2i, float[]> heightsPerChunk = new Dictionary<Vector2i, float[]>(new Vector2iComparer());

		private readonly DiggerSystem digger;

		private readonly TerrainData terrainData;

		private readonly int resolution;

		private readonly float resolutionInv;

		private readonly float toUVs;

		public HeightsFeeder(DiggerSystem digger, int resolution)
		{
			this.digger = digger;
			terrainData = digger.Terrain.terrainData;
			this.resolution = resolution;
			resolutionInv = 1f / (float)resolution;
			toUVs = 1f / (float)(resolution * terrainData.heightmapResolution);
		}

		public float GetHeight(int x, int z)
		{
			if (resolution == 1)
			{
				return terrainData.GetHeight(x, z);
			}
			int num = x / resolution;
			int num2 = z / resolution;
			return Utils.BilinearInterpolate(terrainData.GetHeight(num, num2), terrainData.GetHeight(num, num2 + 1), terrainData.GetHeight(num + 1, num2), terrainData.GetHeight(num + 1, num2 + 1), (float)(x % resolution) * resolutionInv, (float)(z % resolution) * resolutionInv);
		}

		public float[] GetHeights(Vector3i chunkPosition, Vector3i chunkVoxelPosition)
		{
			Vector2i key = new Vector2i(chunkPosition.x, chunkPosition.z);
			if (heightsPerChunk.TryGetValue(key, out var value))
			{
				return value;
			}
			int num = digger.SizeVox + 2;
			value = new float[num * num];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					value[i * num + j] = GetHeight(chunkVoxelPosition.x + i - 1, chunkVoxelPosition.z + j - 1);
				}
			}
			heightsPerChunk.Add(key, value);
			return value;
		}
	}
}
