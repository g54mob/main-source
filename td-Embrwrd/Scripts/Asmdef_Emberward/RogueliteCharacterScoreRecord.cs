using System;

[Serializable]
public class RogueliteCharacterScoreRecord
{
	public eCharacterType CharacterType;

	public eGameDifficultyType Difficulty;

	public eWorldType WorldType;

	public int BestScore;

	public RogueliteCharacterScoreRecord(eCharacterType characterType, eWorldType worldType, eGameDifficultyType difficulty, int bestScore)
	{
	}
}
