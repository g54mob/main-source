using System;
using System.Collections.Generic;
using NSMedieval.Map;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval
{
	public static class GridUtils
	{
		public const float LadderMidpoint = 1.5f;

		public static Vector3 GetWorldPosition(Vec3Int gridPos)
		{
			return new Vector3(gridPos.x, gridPos.y * World.MapBlockHeight, gridPos.z);
		}

		public static Vector3 GetWorldPosition(int x, int y, int z)
		{
			return new Vector3(x, y * World.MapBlockHeight, z);
		}

		public static Vec3Int GetGridPosition(Vector3 worldPosition, float raiseYAmount = 0f)
		{
			int value = Mathf.FloorToInt(worldPosition.x + 0.5f);
			int value2 = Mathf.FloorToInt((worldPosition.y + raiseYAmount) / (float)World.MapBlockHeight);
			return new Vec3Int(z: Math.Clamp(Mathf.FloorToInt(worldPosition.z + 0.5f), 0, GridDataIndexTools.SizeZ - 1), x: Math.Clamp(value, 0, GridDataIndexTools.SizeX - 1), y: Math.Clamp(value2, 0, GridDataIndexTools.SizeY - 1));
		}

		public static Vec3Int GetGridPositionRoundY(Vector3 worldPosition, float raiseYAmount = 0f)
		{
			worldPosition.y = (worldPosition.y + raiseYAmount) / (float)World.MapBlockHeight;
			worldPosition.y = Mathf.Round(worldPosition.y) * (float)World.MapBlockHeight;
			return GetGridPosition(worldPosition);
		}

		public static Vec3Int GetCreatureLadderNodePosition(Vector3 worldPosition)
		{
			Vec3Int gridPosition = GetGridPosition(worldPosition, 0.01f);
			float num = (float)(gridPosition.y * World.MapBlockHeight) - worldPosition.y;
			if (num < -1.5f)
			{
				gridPosition.y++;
			}
			else if (num > 1.5f)
			{
				gridPosition.y--;
			}
			return gridPosition;
		}

		public static IEnumerable<Vector2Int> GetPointsOnLine2D(Vector2Int start, Vector2Int end)
		{
			bool steep = Math.Abs(end.y - start.y) > Math.Abs(end.x - start.x);
			if (steep)
			{
				int x = start.x;
				start.x = start.y;
				start.y = x;
				x = end.x;
				end.x = end.y;
				end.y = x;
			}
			if (start.x > end.x)
			{
				int x2 = start.x;
				start.x = end.x;
				end.x = x2;
				x2 = start.y;
				start.y = end.y;
				end.y = x2;
			}
			int dx = end.x - start.x;
			int dy = Math.Abs(end.y - start.y);
			int error = dx / 2;
			int ystep = ((start.y < end.y) ? 1 : (-1));
			int y = start.y;
			for (int i = start.x; i <= end.x; i++)
			{
				yield return new Vector2Int(steep ? y : i, steep ? i : y);
				error -= dy;
				if (error < 0)
				{
					y += ystep;
					error += dx;
				}
			}
		}
	}
}
