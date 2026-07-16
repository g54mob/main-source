using System;
using UnityEngine;

[Serializable]
public class WallComponent
{
	public enum WallFaceDirection
	{
		North = 0,
		East = 1,
		South = 2,
		West = 3
	}

	public GameObject Wall;

	public WallVisualizerComponent visualizer;

	public WallFaceDirection Direction;

	public bool outsideWall;

	public void Hide()
	{
		if (!outsideWall)
		{
			Wall.SetActive(value: false);
		}
	}

	public static WallFaceDirection GetOppositeDirection(WallFaceDirection direction)
	{
		return direction switch
		{
			WallFaceDirection.North => WallFaceDirection.South, 
			WallFaceDirection.East => WallFaceDirection.West, 
			WallFaceDirection.South => WallFaceDirection.North, 
			WallFaceDirection.West => WallFaceDirection.East, 
			_ => WallFaceDirection.North, 
		};
	}

	public static Vector2Int GetDirectionPosition(WallFaceDirection direction)
	{
		return direction switch
		{
			WallFaceDirection.North => new Vector2Int(0, 1), 
			WallFaceDirection.East => new Vector2Int(1, 0), 
			WallFaceDirection.South => new Vector2Int(0, -1), 
			WallFaceDirection.West => new Vector2Int(-1, 0), 
			_ => Vector2Int.zero, 
		};
	}

	public static WallFaceDirection GetDirection(Vector2Int direction)
	{
		if (direction.x == 0 && direction.y > 0)
		{
			return WallFaceDirection.North;
		}
		if (direction.x == 0 && direction.y < 0)
		{
			return WallFaceDirection.South;
		}
		if (direction.x > 0 && direction.y == 0)
		{
			return WallFaceDirection.East;
		}
		if (direction.x < 0 && direction.y == 0)
		{
			return WallFaceDirection.West;
		}
		return WallFaceDirection.North;
	}
}
