using System.Collections.Generic;
using UnityEngine;

public class DungeonCreator : MonoBehaviour
{
	private int width;

	private int height;

	private DungeonCellData[,] grid;

	public DungeonCellData[,] CreateDungeon(int width, int height, float wallDensity)
	{
		return null;
	}

	public bool CheckLayoutAvailable(eDoorFlags required, DungeonCellData cell)
	{
		return false;
	}

	private List<Vector2Int> FindLeaves()
	{
		return null;
	}

	private void DebugPrint()
	{
	}

	private bool InBounds(Vector2Int p)
	{
		return false;
	}

	private Vector2Int DirToVector(eDoorFlags d)
	{
		return default(Vector2Int);
	}

	private eDoorFlags Opposite(eDoorFlags d)
	{
		return default(eDoorFlags);
	}
}
