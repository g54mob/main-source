using UnityEngine;

public static class MinesweeperDifficultyPresets
{
	public static MinesweeperDifficultyPreset Get(MinesweeperDifficulty difficulty)
	{
		return difficulty switch
		{
			MinesweeperDifficulty.Beginner => new MinesweeperDifficultyPreset(new Vector2Int(9, 9), 10), 
			MinesweeperDifficulty.Advanced => new MinesweeperDifficultyPreset(new Vector2Int(16, 16), 40), 
			MinesweeperDifficulty.Expert => new MinesweeperDifficultyPreset(new Vector2Int(30, 16), 99), 
			_ => new MinesweeperDifficultyPreset(new Vector2Int(9, 9), 10), 
		};
	}
}
