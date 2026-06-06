using UnityEngine;

public readonly struct MinesweeperDifficultyPreset
{
	public Vector2Int Size { get; }

	public int MineCount { get; }

	public MinesweeperDifficultyPreset(Vector2Int size, int mineCount)
	{
		Size = size;
		MineCount = mineCount;
	}
}
