using UnityEngine;

public readonly struct MinesweeperRevealed
{
	public readonly Vector2Int Position;

	public MinesweeperRevealed(Vector2Int position)
	{
		Position = position;
	}
}
