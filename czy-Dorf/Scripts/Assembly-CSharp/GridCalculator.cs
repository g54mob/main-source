using System.Collections.Generic;
using UnityEngine;

public static class GridCalculator
{
	public static readonly Vector2 _tileSize = new Vector2(1f, 0.8660254f);

	public static Vector2Int[] EvenColumnDirections = new Vector2Int[6]
	{
		new Vector2Int(0, 1),
		new Vector2Int(1, 1),
		new Vector2Int(1, 0),
		new Vector2Int(0, -1),
		new Vector2Int(-1, 0),
		new Vector2Int(-1, 1)
	};

	public static Vector2Int[] UnevenColumnDirections = new Vector2Int[6]
	{
		new Vector2Int(0, 1),
		new Vector2Int(1, 0),
		new Vector2Int(1, -1),
		new Vector2Int(0, -1),
		new Vector2Int(-1, -1),
		new Vector2Int(-1, 0)
	};

	public static Vector2Int WorldToGridPos(Vector3 worldPos)
	{
		int num = Mathf.RoundToInt(worldPos.x / (_tileSize.x * 0.75f));
		int y = Mathf.RoundToInt((worldPos.z + (float)Mathf.Abs(num % 2) * _tileSize.y / 2f) / _tileSize.y);
		return new Vector2Int(num, y);
	}

	internal static Vector2Int[] NeighborDirections(Vector2Int gridPos)
	{
		if (gridPos.x % 2 == 0)
		{
			return EvenColumnDirections;
		}
		return UnevenColumnDirections;
	}

	internal static Vector2Int[] GetNeighborGridPositions(Vector2Int gridPos)
	{
		Vector2Int[] array = new Vector2Int[6];
		Vector2Int[] array2 = NeighborDirections(gridPos);
		for (int i = 0; i < 6; i++)
		{
			Vector2Int vector2Int = gridPos + array2[i];
			array[i] = vector2Int;
		}
		return array;
	}

	internal static Vector2Int? GetNeighborGridPositionFromIndex(Vector2Int originGridPos, int neighborPositionIndex)
	{
		if (neighborPositionIndex < 0 || neighborPositionIndex > 5)
		{
			Debug.LogError($"{neighborPositionIndex} is not a valid neighbor position index. It should be [0...5]");
			return null;
		}
		return GetNeighborGridPositions(originGridPos)[neighborPositionIndex];
	}

	internal static int? GetNeighborIndexFromGridPos(Vector2Int originGridPos, Vector2Int neighborGridPos)
	{
		Vector2Int[] neighborGridPositions = GetNeighborGridPositions(originGridPos);
		for (int i = 0; i < neighborGridPositions.Length; i++)
		{
			if (neighborGridPositions[i].Equals(neighborGridPos))
			{
				return i;
			}
		}
		Debug.LogError($"{originGridPos} and {neighborGridPos} are not neighbors!");
		return null;
	}

	public static Vector3 GridToWorldPos(Vector2Int gridPos)
	{
		float x = (float)gridPos.x * _tileSize.x * 0.75f;
		float z = ((float)gridPos.y - (float)Mathf.Abs(gridPos.x % 2) / 2f) * _tileSize.y;
		return new Vector3(x, 0f, z);
	}

	public static int RotatedDirection(int directionIndex, int rotationIndex)
	{
		return (directionIndex + rotationIndex + 6) % 6;
	}

	public static List<int> RotateDirections(List<int> directions, int rotationAmount)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < directions.Count; i++)
		{
			list.Add((directions[i] + rotationAmount + 6) % 6);
		}
		return list;
	}

	public static int Distance(Vector2Int gridPos1, Vector2Int gridPos2)
	{
		Vector3Int cubePosition = OffsetCoordinateToCubeCoordinate(gridPos1);
		Vector3Int cubePosition2 = OffsetCoordinateToCubeCoordinate(gridPos2);
		return CubeCoordinateDistance(cubePosition, cubePosition2);
	}

	public static Vector3Int OffsetCoordinateToCubeCoordinate(Vector2Int offsetCoordinate)
	{
		int x = offsetCoordinate.x;
		int num = offsetCoordinate.y - (offsetCoordinate.x + (offsetCoordinate.x & 1)) / 2;
		int y = -x - num;
		return new Vector3Int(x, y, num);
	}

	public static int CubeCoordinateDistance(Vector3Int cubePosition1, Vector3Int cubePosition2)
	{
		return (Mathf.Abs(cubePosition1.x - cubePosition2.x) + Mathf.Abs(cubePosition1.y - cubePosition2.y) + Mathf.Abs(cubePosition1.z - cubePosition2.z)) / 2;
	}
}
