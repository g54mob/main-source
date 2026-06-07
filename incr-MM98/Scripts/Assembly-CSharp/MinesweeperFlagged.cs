using UnityEngine;

public readonly struct MinesweeperFlagged
{
	public readonly Vector2Int Position;

	public MinesweeperFlagged(Vector2Int position)
	{
		Position = position;
	}
}
