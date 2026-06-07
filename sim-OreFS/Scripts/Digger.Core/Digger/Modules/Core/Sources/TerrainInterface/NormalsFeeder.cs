using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.TerrainInterface
{
	public class NormalsFeeder
	{
		private readonly Dictionary<Vector2i, float3[]> normalsPerChunk = new Dictionary<Vector2i, float3[]>(new Vector2iComparer());

		private readonly DiggerSystem digger;

		private readonly TerrainData terrainData;

		private readonly double toUVs;

		public NormalsFeeder(DiggerSystem digger, int resolution)
		{
			this.digger = digger;
			terrainData = digger.Terrain.terrainData;
			toUVs = 1.0 / (double)(resolution * (terrainData.heightmapResolution - 1));
		}

		private float3 GetNormal(int x, int z)
		{
			return terrainData.GetInterpolatedNormal((float)((double)x * toUVs), (float)((double)z * toUVs));
		}

		public float3[] GetNormals(Vector3i chunkPosition, Vector3i chunkVoxelPosition)
		{
			Vector2i key = new Vector2i(chunkPosition.x, chunkPosition.z);
			if (normalsPerChunk.TryGetValue(key, out var value))
			{
				return value;
			}
			int num = digger.SizeVox + 2;
			value = new float3[num * num];
			for (int i = 0; i < num; i++)
			{
				for (int j = 0; j < num; j++)
				{
					value[i * num + j] = GetNormal(chunkVoxelPosition.x + i - 1, chunkVoxelPosition.z + j - 1);
				}
			}
			normalsPerChunk.Add(key, value);
			return value;
		}
	}
}
