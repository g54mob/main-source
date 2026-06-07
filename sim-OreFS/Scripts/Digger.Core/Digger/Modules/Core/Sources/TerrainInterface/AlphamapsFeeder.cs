using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Digger.Modules.Core.Sources.TerrainInterface
{
	public class AlphamapsFeeder
	{
		public struct AlphamapInfo
		{
			public float[] AlphamapArray;

			public int3 AlphamapArraySize;

			public int2 AlphamapArrayOrigin;
		}

		private readonly Dictionary<Vector2i, AlphamapInfo> alphamapsPerChunk = new Dictionary<Vector2i, AlphamapInfo>(new Vector2iComparer());

		private readonly DiggerSystem digger;

		public AlphamapsFeeder(DiggerSystem digger)
		{
			this.digger = digger;
		}

		public AlphamapInfo GetAlphamaps(Vector3i chunkPosition, Vector3 worldPosition, int sizeOfMesh)
		{
			Vector2i key = new Vector2i(chunkPosition.x, chunkPosition.z);
			if (alphamapsPerChunk.TryGetValue(key, out var value))
			{
				return value;
			}
			TerrainData terrainData = digger.Terrain.terrainData;
			int2 int5 = new int2(terrainData.alphamapWidth, terrainData.alphamapHeight);
			Vector2 vector = new Vector2(1f / terrainData.size.x, 1f / terrainData.size.z);
			Vector2 vector2 = new Vector2((worldPosition.x + 0f) * vector.x, (worldPosition.z + 0f) * vector.y);
			Vector2 vector3 = new Vector2((worldPosition.x + (float)sizeOfMesh * digger.HeightmapScale.x) * vector.x, (worldPosition.z + (float)sizeOfMesh * digger.HeightmapScale.z) * vector.y);
			Vector2 vector4 = new Vector2(vector2.x * (float)int5.x, vector2.y * (float)int5.y);
			Vector2 vector5 = new Vector2(vector3.x * (float)int5.x, vector3.y * (float)int5.y);
			int2 int6 = new int2(Math.Min(Math.Max(Convert.ToInt32(Math.Floor(vector4.x)) - 1, 0), int5.x), Math.Min(Math.Max(Convert.ToInt32(Math.Floor(vector4.y)) - 1, 0), int5.y));
			int2 int7 = new int2(Math.Min(Math.Max(Convert.ToInt32(Math.Ceiling(vector5.x)) + 3, 0), int5.x), Math.Min(Math.Max(Convert.ToInt32(Math.Ceiling(vector5.y)) + 3, 0), int5.y));
			value = new AlphamapInfo
			{
				AlphamapArray = GrabAlphamaps(int6, int7, out var alphamapCount),
				AlphamapArrayOrigin = int6
			};
			value.AlphamapArraySize.xy = int7 - int6;
			value.AlphamapArraySize.z = alphamapCount;
			alphamapsPerChunk.Add(key, value);
			return value;
		}

		private float[] GrabAlphamaps(int2 from, int2 to, out int alphamapCount)
		{
			int2 int5 = to - from;
			float[,,] alphamaps = digger.Terrain.terrainData.GetAlphamaps(from.x, from.y, int5.x, int5.y);
			int length = alphamaps.GetLength(1);
			int length2 = alphamaps.GetLength(0);
			alphamapCount = alphamaps.GetLength(2);
			float[] array = new float[int5.x * int5.y * alphamapCount];
			for (int i = 0; i < int5.x; i++)
			{
				for (int j = 0; j < int5.y; j++)
				{
					for (int k = 0; k < alphamapCount; k++)
					{
						float num = ((i < length && j < length2) ? alphamaps[j, i, k] : 0f);
						array[i * int5.y * alphamapCount + j * alphamapCount + k] = num;
					}
				}
			}
			return array;
		}
	}
}
