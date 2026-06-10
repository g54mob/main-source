using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using NSMedieval.Tools;
using NSMedieval.Tools.Math;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.Water
{
	public class RiverGeneration
	{
		private Vec3Int mapSize;

		private float[,] heightMap;

		private float[,] waterHeight;

		private float[,] riverData;

		private float[,] riverHeightLerpData;

		private readonly List<Vector2Int> riverPositionsLinear = new List<Vector2Int>();

		private readonly List<float> riverAnglesLinear = new List<float>();

		private readonly List<float> riverWidthLinear = new List<float>();

		private readonly List<float> riverDepthLinear = new List<float>();

		private readonly List<float> riverIslandWidthLinear = new List<float>();

		private readonly FastNoise noise = new FastNoise();

		private bool[,] terrainOccupiedMap;

		public bool[,] TerrainOccupiedMap => terrainOccupiedMap;

		public bool CreateRiver(CancellationToken cancellationToken, Vector2Int startPosition, float[,] heightMap, float[,] waterHeight, Vec3Int mapSize, float inputStartRiverWidth = 1f, float inputEndRiverWidth = 4f, float islandFrequency = 0.5f, float terrainCurveInfluence = 0.5f, float curveNoiseAmount = 0.5f)
		{
			Init(heightMap, waterHeight, mapSize);
			startPosition = ProjectToEdgeAndMove(startPosition, new Vector2Int(this.mapSize.x, this.mapSize.z), 5);
			Vector2Int vector2Int = new Vector2Int(-15, -15);
			Vector2Int vector2Int2 = new Vector2Int(this.mapSize.x + 15, this.mapSize.z + 15);
			ClearWaterMap();
			noise.SetSeed(startPosition.x ^ startPosition.y);
			riverPositionsLinear.Clear();
			riverAnglesLinear.Clear();
			riverWidthLinear.Clear();
			riverDepthLinear.Clear();
			riverIslandWidthLinear.Clear();
			System.Random random = new System.Random(startPosition.GetHashCode());
			Vector2 vector = new Vector2((float)this.mapSize.x / 2f, (float)this.mapSize.z / 2f);
			Vector2 vector2 = startPosition;
			float num = Vector2.SignedAngle(vector - vector2, Vector2.up) + ((float)random.NextDouble() - 0.5f) * 5f;
			float num2 = (float)random.NextDouble() * 0.5f + 0.5f;
			float num3 = (float)random.NextDouble() * 0.5f + 0.5f;
			float num4 = (float)(random.NextDouble() * 0.5 + 0.5);
			float num5 = (float)(random.NextDouble() * 0.5 + 0.5);
			for (int i = 0; i < 500; i++)
			{
				Vector2 vector3 = vector2;
				if (vector3 != Vector2.zero && (vector3.x < (float)vector2Int.x || vector3.x > (float)vector2Int2.x || vector3.y < (float)vector2Int.y || vector3.y > (float)vector2Int2.y))
				{
					break;
				}
				if (i % 10 == 0)
				{
					cancellationToken.ThrowIfCancellationRequested();
				}
				float num6 = num;
				num = GetNextAngle(startPosition, vector2, num, 70f, 10f);
				num = Mathf.LerpAngle(num6, num, MathfUtils.Clamp01(terrainCurveInfluence));
				float num7 = noise.GetPerlin(vector3.x * num2 * 40f * num2, vector3.y * num2 * 40f * num2) * 45f * num4;
				num7 += noise.GetPerlin((0f - vector3.x) * num3 * 20f * num3, (0f - vector3.y) * num3 * 20f * num3) * 10f * num5;
				num += num7 * curveNoiseAmount;
				vector2.x = vector3.x + Mathf.Sin(num * (MathF.PI / 180f)) * 5f;
				vector2.y = vector3.y + Mathf.Cos(num * (MathF.PI / 180f)) * 5f;
				if (GridDataIndexTools.InRangeX((int)vector2.x) && GridDataIndexTools.InRangeZ((int)vector2.y))
				{
					Vector2Int vector2Int3 = LimitFinalPos(vector2);
					if (terrainOccupiedMap[vector2Int3.x, vector2Int3.y])
					{
						return false;
					}
				}
				CalcSegment(new Vector2Int((int)vector3.x, (int)vector3.y), new Vector2Int((int)vector2.x, (int)vector2.y), num6, num);
			}
			Blur1D(riverAnglesLinear, 3);
			Blur1D(riverAnglesLinear, 6, 1.5f);
			cancellationToken.ThrowIfCancellationRequested();
			using PooledList<float> pooledList = ListPool<float>.GetJanitor();
			CalculateCurviness(pooledList);
			CalculateRiverWidth(pooledList, inputStartRiverWidth, inputEndRiverWidth);
			int count = riverPositionsLinear.Count;
			for (int j = 0; j < count; j++)
			{
				if (j % 5 == 0)
				{
					cancellationToken.ThrowIfCancellationRequested();
				}
				int index = ((j < count - 1) ? (j + 1) : j);
				bool isFlowIn = j < count / 4;
				CalculateRiverbedSegment(riverPositionsLinear[j], riverPositionsLinear[index], riverAnglesLinear[j], riverAnglesLinear[index], riverWidthLinear[j], riverWidthLinear[index], riverIslandWidthLinear[j], j, riverDepthLinear[j] - 1f, islandFrequency, isFlowIn);
			}
			FillHolesInMap(riverData);
			FillHolesInMap(this.waterHeight);
			FillHolesInMap(riverHeightLerpData);
			cancellationToken.ThrowIfCancellationRequested();
			for (int k = 0; k < this.mapSize.x; k++)
			{
				for (int l = 0; l < this.mapSize.z; l++)
				{
					if (riverHeightLerpData[k, l] > 0f)
					{
						this.heightMap[k, l] = Mathf.Lerp(this.heightMap[k, l], riverData[k, l], riverHeightLerpData[k, l]);
					}
				}
			}
			return true;
		}

		public static Vector2Int ProjectToEdgeAndMove(Vector2Int position, Vector2Int mapSize, int distance)
		{
			int x = position.x;
			int num = mapSize.x - position.x;
			int num2 = mapSize.y - position.y;
			int y = position.y;
			int num3 = Mathf.Min(x, num, num2, y);
			if (num3 == x)
			{
				return new Vector2Int(-distance, position.y);
			}
			if (num3 == num)
			{
				return new Vector2Int(mapSize.x + distance, position.y);
			}
			if (num3 == num2)
			{
				return new Vector2Int(position.x, mapSize.y + distance);
			}
			return new Vector2Int(position.x, -distance);
		}

		private void Init(float[,] heightMap, float[,] waterHeight, Vec3Int mapSize)
		{
			this.mapSize = mapSize;
			this.heightMap = heightMap;
			this.waterHeight = waterHeight;
			terrainOccupiedMap = new bool[mapSize.x, mapSize.z];
			riverData = new float[mapSize.x, mapSize.z];
			riverHeightLerpData = new float[mapSize.x, mapSize.z];
		}

		private float GetNextAngle(Vector2 startPos, Vector2 pos, float angle, float maxTurnAngle, float turnAngleStep)
		{
			using PooledDictionary<float, float> pooledDictionary = DictionaryPool<float, float>.GetJanitor();
			float num = 1f;
			Vector2 currentPosition = pos;
			float num2 = float.MaxValue;
			for (float num3 = 0f - maxTurnAngle; num3 <= maxTurnAngle; num3 += turnAngleStep)
			{
				float num4 = angle + num3;
				float num5 = Mathf.Sin(num4 * (MathF.PI / 180f)) * num;
				float num6 = Mathf.Cos(num4 * (MathF.PI / 180f)) * num;
				float num7 = 0f;
				for (int i = 1; i <= 7; i++)
				{
					currentPosition.x = pos.x + num5 * Mathf.Pow(i, 2f);
					currentPosition.y = pos.y + num6 * Mathf.Pow(i, 2f);
					Vector2Int vector2Int = LimitFinalPos(currentPosition);
					num7 += heightMap[vector2Int.x, vector2Int.y];
					num7 += ((terrainOccupiedMap[vector2Int.x, vector2Int.y] || waterHeight[vector2Int.x, vector2Int.y] > 0f) ? 32f : 0f);
					num7 -= 2f * (startPos - vector2Int).magnitude / mapSize.magnitude;
				}
				if (!pooledDictionary.ContainsKey(num7))
				{
					pooledDictionary.Add(num7, num4);
				}
				if (num7 < num2)
				{
					num2 = num7;
				}
			}
			angle = pooledDictionary[num2];
			return angle;
		}

		private void CalculateCurviness(IList<float> curviness)
		{
			int count = riverPositionsLinear.Count;
			for (int i = 0; i < count; i++)
			{
				if (i == count - 1)
				{
					curviness.Add(0f);
					continue;
				}
				float item = Math.Abs(riverAnglesLinear[i] - riverAnglesLinear[i + 1]);
				curviness.Add(item);
			}
			Blur1D(curviness, 10, 1.15f);
		}

		private void CalculateRiverWidth(IList<float> curviness, float startRiverWidth = 1f, float endRiverWidth = 4f)
		{
			int count = riverPositionsLinear.Count;
			float num = startRiverWidth;
			for (int i = 0; i < count; i++)
			{
				float num2 = Mathf.Lerp(startRiverWidth, endRiverWidth, (float)i / (float)count);
				num = Mathf.Lerp(num, num2 + curviness[i] * 4f, 0.3f);
				num = Mathf.Lerp(num, num2, 0.26f);
				riverWidthLinear.Add(num);
				float item = MathfUtils.Clamp((num - 5f) * 1.3f, 0f, num - 2f);
				riverIslandWidthLinear.Add(item);
			}
		}

		private void CalculateRiverbedSegment(Vector2Int position, Vector2Int nextPosition, float angleAtPos, float nextAngleAtPos, float width, float nextWidth, float islandVal, int riverPointIndex, float heightToSet, float islandFrequency = 0.5f, bool isFlowIn = false)
		{
			float num = Mathf.Sin(angleAtPos * (MathF.PI / 180f));
			float num2 = Mathf.Cos(angleAtPos * (MathF.PI / 180f));
			float num3 = Mathf.Sin(nextAngleAtPos * (MathF.PI / 180f));
			float num4 = Mathf.Cos(nextAngleAtPos * (MathF.PI / 180f));
			float num5 = position.x;
			float num6 = position.y;
			float num7 = nextPosition.x;
			float num8 = nextPosition.y;
			int num9 = (int)Math.Max(width, nextWidth);
			float num10 = MathfUtils.Clamp01(1f - islandFrequency) * 2f - 0.5f;
			for (int i = -num9; i <= num9; i++)
			{
				float num11 = MathfUtils.Clamp01(Math.Abs((float)i / width)) * MathfUtils.Sign(i);
				float num12 = MathfUtils.Clamp01(Math.Abs((float)i / nextWidth)) * MathfUtils.Sign(i);
				float x = num5 + width * num11 * num;
				float y = num6 + width * num11 * num2;
				float x2 = num7 + nextWidth * num12 * num3;
				float y2 = num8 + nextWidth * num12 * num4;
				SetData(riverData, x, y, x2, y2, heightToSet);
				SetData(riverHeightLerpData, x, y, x2, y2, 1f);
				bool flag = false;
				if ((float)Mathf.Abs(i) < islandVal && noise.GetPerlin(riverPointIndex * 8, i * 14) + 0.1f > num10)
				{
					SetData(riverData, x, y, x2, y2, heightToSet + 1f);
					flag = true;
				}
				if (!flag && i >= -num9 && i <= num9)
				{
					SetData(waterHeight, x, y, x2, y2, heightToSet + 1f);
				}
			}
			int num13 = 2 + (int)(MathfUtils.Clamp01(noise.GetPerlin((float)riverPointIndex * 2.5f, 2.5f) * 0.6f + 0.4f) * 8f);
			for (int j = 0; j <= num13; j++)
			{
				float x3 = num5 + (width + (float)j) * num;
				float y3 = num6 + (width + (float)j) * num2;
				float x4 = num7 + (nextWidth + (float)j) * num3;
				float y4 = num8 + (nextWidth + (float)j) * num4;
				SetData(riverHeightLerpData, x3, y3, x4, y4, 1f - (float)j / (float)num13);
				SetData(riverData, x3, y3, x4, y4, heightToSet + 1f);
				x3 = num5 - (width + (float)j) * num;
				y3 = num6 - (width + (float)j) * num2;
				x4 = num7 - (nextWidth + (float)j) * num3;
				y4 = num8 - (nextWidth + (float)j) * num4;
				SetData(riverHeightLerpData, x3, y3, x4, y4, 1f - (float)j / (float)num13);
				SetData(riverData, x3, y3, x4, y4, heightToSet + 1f);
			}
		}

		private static void SetData<T>(T[,] data, float x1, float y1, float x2, float y2, T valueToSet)
		{
			Vector2 vector = new Vector2(x1, y1);
			Vector2 vector2 = new Vector2(x2, y2);
			int num = Mathf.CeilToInt((vector2 - vector).magnitude);
			for (float num2 = 0f; num2 <= (float)num; num2 += 1f)
			{
				Vector2 vector3 = Vector2.Lerp(vector, vector2, num2 / (float)num);
				int num3 = Mathf.RoundToInt(vector3.x);
				int num4 = Mathf.RoundToInt(vector3.y);
				if (GridDataIndexTools.InRangeX(num3) && GridDataIndexTools.InRangeZ(num4))
				{
					data[num3, num4] = valueToSet;
				}
			}
		}

		private static void FillHolesInMap(float[,] map)
		{
			int length = map.GetLength(0);
			int length2 = map.GetLength(1);
			for (int i = 0; i < length; i++)
			{
				for (int j = 0; j < length2; j++)
				{
					if (map[i, j] > 0f)
					{
						continue;
					}
					int num = 0;
					float num2 = 0f;
					int num3 = 0;
					for (int k = 0; k < MapNodeUtils.NeighborsHorizontalX.Length; k++)
					{
						int num4 = i + MapNodeUtils.NeighborsHorizontalX[k];
						int num5 = j + MapNodeUtils.NeighborsHorizontalZ[k];
						if (GridDataIndexTools.InRangeX(num4) && GridDataIndexTools.InRangeZ(num5))
						{
							if (map[num4, num5] > 0f)
							{
								num++;
								num2 += map[num4, num5];
							}
							num3++;
						}
					}
					if (num >= 3)
					{
						map[i, j] = num2 / (float)num;
					}
				}
			}
		}

		private static void Blur1D(IList<float> list, int blurRadius, float addIndexPow = 1f)
		{
			int count = list.Count;
			using PooledList<float> pooledList = ListPool<float>.GetJanitor();
			using PooledList<int> pooledList2 = ListPool<int>.GetJanitor();
			pooledList.AddRange(list);
			for (int i = -blurRadius; i <= blurRadius; i++)
			{
				int item = (int)(Math.Pow(Math.Abs(i), 1.399999976158142) * (double)Math.Sign(i));
				pooledList2.Add(item);
			}
			for (int j = 0; j < count; j++)
			{
				float num = 0f;
				int num2 = 0;
				foreach (int item2 in pooledList2)
				{
					if (j + item2 < count && j + item2 >= 0)
					{
						num += pooledList[j + item2];
						num2++;
					}
				}
				list[j] = num / (float)num2;
			}
		}

		private void ClearWaterMap()
		{
			for (int i = 0; i < mapSize.x; i++)
			{
				for (int j = 0; j < mapSize.z; j++)
				{
					riverData[i, j] = 0f;
					riverHeightLerpData[i, j] = 0f;
					terrainOccupiedMap[i, j] = false;
				}
			}
		}

		private void CalcSegment(Vector2Int segmentFrom, Vector2Int segmentTo, float angleSegmentFrom, float angleSegmentTo)
		{
			int num = Mathf.CeilToInt((segmentTo - segmentFrom).magnitude);
			Vector2 vector = segmentTo - segmentFrom;
			vector.x /= num;
			vector.y /= num;
			float num2;
			if (riverDepthLinear.Count != 0)
			{
				List<float> list = riverDepthLinear;
				num2 = list[list.Count - 1];
			}
			else
			{
				num2 = float.MaxValue;
			}
			float num3 = num2;
			for (int i = 0; i < num; i++)
			{
				int x = (int)((float)segmentFrom.x + vector.x * (float)i);
				int num4 = (int)((float)segmentFrom.y + vector.y * (float)i);
				int num5 = LimitX(x);
				int num6 = LimitZ(num4);
				float num7 = 90f + Mathf.Lerp(angleSegmentFrom, angleSegmentTo, (float)i / (float)num);
				riverPositionsLinear.Add(new Vector2Int(x, num4));
				riverAnglesLinear.Add(num7);
				float num8 = heightMap[num5, num6];
				if (num8 < num3)
				{
					num3 = Math.Max(num8, 1f);
				}
				riverDepthLinear.Add(num3);
				MarkOccupiedOnSides(x, num4, num7);
			}
		}

		private void MarkOccupiedOnSides(int x, int y, float angle)
		{
			float num = Mathf.Sin(angle * (MathF.PI / 180f));
			float num2 = Mathf.Cos(angle * (MathF.PI / 180f));
			float num3 = Mathf.Sin((angle + 180f) * (MathF.PI / 180f));
			float num4 = Mathf.Cos((angle + 180f) * (MathF.PI / 180f));
			for (int i = 0; i < 18; i++)
			{
				float f = (float)x + (float)i * num;
				float f2 = (float)y + (float)i * num2;
				SetTerrainOccupied(Mathf.FloorToInt(f), Mathf.CeilToInt(f2));
				SetTerrainOccupied(Mathf.CeilToInt(f), Mathf.CeilToInt(f2));
				SetTerrainOccupied(Mathf.CeilToInt(f), Mathf.FloorToInt(f2));
				SetTerrainOccupied(Mathf.FloorToInt(f), Mathf.FloorToInt(f2));
				f = (float)x + (float)i * num3;
				f2 = (float)y + (float)i * num4;
				SetTerrainOccupied(Mathf.FloorToInt(f), Mathf.CeilToInt(f2));
				SetTerrainOccupied(Mathf.CeilToInt(f), Mathf.CeilToInt(f2));
				SetTerrainOccupied(Mathf.CeilToInt(f), Mathf.FloorToInt(f2));
				SetTerrainOccupied(Mathf.FloorToInt(f), Mathf.FloorToInt(f2));
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void SetTerrainOccupied(int x, int y)
		{
			if (GridDataIndexTools.InRangeX(x) && GridDataIndexTools.InRangeZ(y))
			{
				terrainOccupiedMap[x, y] = true;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Vector2Int LimitFinalPos(Vector2 currentPosition)
		{
			return new Vector2Int(LimitX((int)currentPosition.x), LimitZ((int)currentPosition.y));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int LimitX(int x)
		{
			if (x < 0)
			{
				return 0;
			}
			if (x > mapSize.x - 1)
			{
				return mapSize.x - 1;
			}
			return x;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int LimitZ(int z)
		{
			if (z < 0)
			{
				return 0;
			}
			if (z > mapSize.z - 1)
			{
				return mapSize.z - 1;
			}
			return z;
		}
	}
}
