using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NSEipix.Base;
using NSMedieval.Map;
using UnityEngine;

namespace NSMedieval.Manager
{
	public class StartPositionManager : MonoSingleton<StartPositionManager>
	{
		[SerializeField]
		private Texture2D tex;

		public const int MapBorderFromEdge = 3;

		public const int MapBorderFromEdgeFadeDistance = 16;

		private List<Vector2Int> startPoints = new List<Vector2Int>();

		private int[,] distMap;

		private Vector2Int startPositionCenter = Vector2Int.zero;

		private int maxDistance;

		private readonly HashSet<Vector2Int> isPositionUsed = new HashSet<Vector2Int>();

		private World world;

		private Heightmap heightmap;

		private int worldSizeX;

		private int worldSizeZ;

		public event Action StartPositionsSetEvent;

		private void Start()
		{
			world = MonoSingleton<World>.Instance;
			worldSizeX = world.SizeX;
			worldSizeZ = world.SizeZ;
			heightmap = MonoSingleton<Heightmap>.Instance;
		}

		public void CalculateDistanceMap()
		{
			distMap = new int[world.SizeX, world.SizeZ];
			startPoints.Clear();
			isPositionUsed.Clear();
			FloodfillArea largestArea = world.GetLargestArea();
			List<Vector2Int> list = new List<Vector2Int>();
			List<Vector2Int> list2 = new List<Vector2Int>
			{
				new Vector2Int(1, 0),
				new Vector2Int(-1, 0),
				new Vector2Int(0, 1),
				new Vector2Int(0, -1)
			};
			SlopeManager slopeManager = MonoSingleton<SlopeManager>.Instance;
			for (int i = 0; i < world.SizeX; i++)
			{
				for (int j = 0; j < world.SizeZ; j++)
				{
					distMap[i, j] = 0;
					if (slopeManager.IsSlopeAt(i, j))
					{
						distMap[i, j] = -1;
					}
				}
			}
			HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
			if (largestArea != null)
			{
				foreach (Vector2Int point in largestArea.Points)
				{
					hashSet.Add(point);
				}
			}
			int num = 1;
			while (true)
			{
				list.Clear();
				foreach (Vector2Int item in hashSet)
				{
					if (distMap[item.x, item.y] != 0)
					{
						continue;
					}
					bool flag = false;
					foreach (Vector2Int item2 in list2)
					{
						int num2 = item.x + item2.x;
						int num3 = item.y + item2.y;
						int heightAt = heightmap.GetHeightAt(num2, num3);
						if (!IsInBorderRange(num2, num3) || heightAt != largestArea.Elevation || distMap[num2, num3] != 0)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						list.Add(item);
					}
				}
				if (list.Count == 0)
				{
					break;
				}
				foreach (Vector2Int item3 in list)
				{
					distMap[item3.x, item3.y] = num;
					startPoints.Add(item3);
					hashSet.Remove(item3);
				}
				list.Clear();
				num++;
			}
			for (int k = 0; k < world.SizeX; k++)
			{
				for (int l = 0; l < world.SizeZ; l++)
				{
					int num4 = Math.Min(k, Math.Min(l, Math.Min(Math.Max(world.SizeX - k, 0), Math.Max(world.SizeZ - l, 0))));
					distMap[k, l] *= num4;
					if (maxDistance < distMap[k, l])
					{
						maxDistance = distMap[k, l];
					}
				}
			}
			startPositionCenter = Vector2Int.zero;
			foreach (Vector2Int startPoint in startPoints)
			{
				if (distMap[startPositionCenter.x, startPositionCenter.y] < distMap[startPoint.x, startPoint.y])
				{
					startPositionCenter = startPoint;
				}
			}
			float num5 = 10f;
			for (int m = 0; m < startPoints.Count; m++)
			{
				Vector2Int b = startPoints[m];
				float num6 = Vector2Int.Distance(startPositionCenter, b);
				if (num6 < num5)
				{
					distMap[b.x, b.y] += (int)(5.0 * (double)(num5 - num6));
					maxDistance = Math.Max(maxDistance, distMap[b.x, b.y]);
				}
			}
			startPoints.Sort((Vector2Int a, Vector2Int vector2Int) => distMap[a.x, a.y].CompareTo(distMap[vector2Int.x, vector2Int.y]));
			this.StartPositionsSetEvent?.Invoke();
		}

		public void MakeFreeSpace()
		{
			int num = isPositionUsed.Count * 2;
			for (int i = 0; i < num; i++)
			{
				isPositionUsed.Add(startPoints[startPoints.Count - 1]);
				startPoints.RemoveAt(startPoints.Count - 1);
			}
		}

		internal Vector2 GetStartPositionCenter()
		{
			return startPositionCenter;
		}

		public Vector2Int GetNextPosition()
		{
			if (startPoints.Count <= 0)
			{
				return Vector2Int.zero;
			}
			List<Vector2Int> list = startPoints;
			Vector2Int vector2Int = list[list.Count - 1];
			startPoints.RemoveAt(startPoints.Count - 1);
			isPositionUsed.Add(vector2Int);
			return vector2Int;
		}

		public Vector3 GetNextPositionWorldSpace()
		{
			Vector2Int nextPosition = GetNextPosition();
			return new Vector3(nextPosition.x, heightmap.GetHeightAt(nextPosition) * World.MapBlockHeight, nextPosition.y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal bool IsPositionUsed(Vector2Int pos)
		{
			return isPositionUsed.Contains(pos);
		}

		public Texture2D GetDistMapDbgTexture()
		{
			Texture2D texture2D = new Texture2D(world.SizeX, world.SizeZ);
			for (int i = 0; i < world.SizeX * world.SizeZ; i++)
			{
				texture2D.SetPixel(i % world.SizeX, i / world.SizeX, Color.black);
			}
			for (int j = 0; j < world.SizeX; j++)
			{
				for (int k = 0; k < world.SizeZ; k++)
				{
					float num = (float)distMap[j, k] / (float)maxDistance;
					if (num < 0.95f)
					{
						texture2D.SetPixel(j, k, new Color(num, num, num, 1f));
					}
					else
					{
						texture2D.SetPixel(j, k, Color.blue);
					}
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool IsInBorderRange(int x, int z)
		{
			if (x >= 3 && z >= 3 && x < worldSizeX - 3)
			{
				return z < worldSizeZ - 3;
			}
			return false;
		}
	}
}
