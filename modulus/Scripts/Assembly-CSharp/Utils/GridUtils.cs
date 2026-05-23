#define ENABLE_DEBUG_ERRORS
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
	public static class GridUtils
	{
		public static Vector3 GridCellSize = new Vector3(1f, 1f, 1f);

		public static Vector3Int RotatePoint(Vector3Int point, int degrees)
		{
			while (degrees < -360)
			{
				degrees += 360;
			}
			while (degrees > 360)
			{
				degrees -= 360;
			}
			int x;
			int y;
			int z;
			switch (degrees)
			{
			case -90:
			case 270:
				x = -point.z;
				y = point.y;
				z = point.x;
				break;
			case -270:
			case 90:
				x = point.z;
				y = point.y;
				z = -point.x;
				break;
			case -180:
			case 180:
				x = -point.x;
				y = point.y;
				z = -point.z;
				break;
			default:
				x = point.x;
				y = point.y;
				z = point.z;
				break;
			}
			return new Vector3Int(x, y, z);
		}

		public static Vector3 RotatePoint(Vector3 point, int degrees)
		{
			while (degrees < -360)
			{
				degrees += 360;
			}
			while (degrees > 360)
			{
				degrees -= 360;
			}
			float x;
			float y;
			float z;
			switch (degrees)
			{
			case -90:
			case 270:
				x = 0f - point.z;
				y = point.y;
				z = point.x;
				break;
			case -270:
			case 90:
				x = point.z;
				y = point.y;
				z = 0f - point.x;
				break;
			case -180:
			case 180:
				x = 0f - point.x;
				y = point.y;
				z = 0f - point.z;
				break;
			default:
				x = point.x;
				y = point.y;
				z = point.z;
				break;
			}
			return new Vector3(x, y, z);
		}

		public static List<Vector3Int> RotatePoints(List<Vector3Int> points, int degrees)
		{
			while (degrees < -360)
			{
				degrees += 360;
			}
			while (degrees > 360)
			{
				degrees -= 360;
			}
			List<Vector3Int> list = new List<Vector3Int>();
			foreach (Vector3Int point in points)
			{
				int x;
				int y;
				int z;
				switch (degrees)
				{
				case -90:
				case 270:
					x = -point.z;
					y = point.y;
					z = point.x;
					break;
				case -270:
				case 90:
					x = point.z;
					y = point.y;
					z = -point.x;
					break;
				case -180:
				case 180:
					x = -point.x;
					y = point.y;
					z = -point.z;
					break;
				default:
					x = point.x;
					y = point.y;
					z = point.z;
					break;
				}
				list.Add(new Vector3Int(x, y, z));
			}
			return list;
		}

		public static Vector3Int[] GetNeighboringPositions(List<Vector3Int> positions, Vector3Int middlePos)
		{
			Vector3Int[] array = new Vector3Int[4];
			Vector3Int lhs = middlePos;
			Vector3Int lhs2 = middlePos;
			foreach (Vector3Int position in positions)
			{
				lhs = Vector3Int.Max(lhs, position);
				lhs2 = Vector3Int.Min(lhs2, position);
			}
			array[0] = new Vector3Int(middlePos.x, middlePos.y, lhs.z + 1);
			array[1] = new Vector3Int(lhs.x + 1, middlePos.y, middlePos.z);
			array[2] = new Vector3Int(middlePos.x, middlePos.y, lhs2.z - 1);
			array[3] = new Vector3Int(lhs2.x - 1, middlePos.y, middlePos.z);
			return array;
		}

		public static Vector3Int[] GetNeighboringPositions(Vector3Int pos)
		{
			return new Vector3Int[4]
			{
				new Vector3Int(pos.x, pos.y, pos.z + 1),
				new Vector3Int(pos.x + 1, pos.y, pos.z),
				new Vector3Int(pos.x, pos.y, pos.z - 1),
				new Vector3Int(pos.x - 1, pos.y, pos.z)
			};
		}

		public static bool IsGridPosInCameraView(Vector3Int gridPos, Camera camera)
		{
			Vector3 vector = camera.WorldToViewportPoint(gridPos);
			if (vector.x >= 0f && vector.x <= 1f && vector.y >= 0f && vector.y <= 1f && vector.z > 0f)
			{
				return true;
			}
			return false;
		}

		public static bool IsGridPosInCameraView(Vector3Int gridPos, Camera camera, out Vector3 viewportPoint)
		{
			viewportPoint = camera.WorldToViewportPoint(gridPos);
			if (viewportPoint.x >= 0f && viewportPoint.x <= 1f && viewportPoint.y >= 0f && viewportPoint.y <= 1f && viewportPoint.z > 0f)
			{
				return true;
			}
			return false;
		}

		public static int[] Rotate3x3IntGrid(int[] grid, int degrees)
		{
			if (grid.Length != 9)
			{
				throw new ArgumentException("Grid must have exactly 9 elements for a 3x3 layout.");
			}
			degrees = (degrees % 360 + 360) % 360;
			int[] array = new int[9];
			switch (degrees)
			{
			case 0:
				return grid;
			case 270:
				array[0] = grid[6];
				array[1] = grid[3];
				array[2] = grid[0];
				array[3] = grid[7];
				array[4] = grid[4];
				array[5] = grid[1];
				array[6] = grid[8];
				array[7] = grid[5];
				array[8] = grid[2];
				break;
			case 180:
				array[0] = grid[8];
				array[1] = grid[7];
				array[2] = grid[6];
				array[3] = grid[5];
				array[4] = grid[4];
				array[5] = grid[3];
				array[6] = grid[2];
				array[7] = grid[1];
				array[8] = grid[0];
				break;
			case 90:
				array[0] = grid[2];
				array[1] = grid[5];
				array[2] = grid[8];
				array[3] = grid[1];
				array[4] = grid[4];
				array[5] = grid[7];
				array[6] = grid[0];
				array[7] = grid[3];
				array[8] = grid[6];
				break;
			default:
				throw new ArgumentException("Rotation must be a multiple of 90 degrees.");
			}
			return array;
		}

		public static List<Vector3Int> GetOccupiedGridPositions(Vector3Int position, Vector2Int size)
		{
			List<Vector3Int> list = new List<Vector3Int>();
			int num = -(size.x / 2);
			int num2 = -(size.y / 2);
			list.Add(position);
			for (int i = 0; i < size.x; i++)
			{
				for (int j = 0; j < size.y; j++)
				{
					Vector3Int vector3Int = new Vector3Int(position.x + num + i, position.y, position.z + num2 + j);
					if (!(vector3Int == position))
					{
						list.Add(vector3Int);
					}
				}
			}
			return list;
		}

		public static Vector3Int GetDirectionFromRotation(int rotation)
		{
			switch (rotation)
			{
			case 0:
				return new Vector3Int(0, 0, 1);
			case 90:
				return new Vector3Int(1, 0, 0);
			case 180:
				return new Vector3Int(0, 0, -1);
			case 270:
				return new Vector3Int(-1, 0, 0);
			default:
				typeof(GridUtils).LogError($"Rotation is not a multiple of 90: {rotation}, returning default direction (0,0,1)", "GetDirectionFromRotation", 279);
				return new Vector3Int(0, 0, 1);
			}
		}
	}
}
