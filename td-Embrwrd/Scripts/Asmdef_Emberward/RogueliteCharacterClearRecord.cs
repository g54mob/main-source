using System;

[Serializable]
public class RogueliteCharacterClearRecord
{
	public eCharacterType CharacterType;

	public eGameDifficultyType Difficulty;

	public eWorldType WorldType;

	public bool IsCleared;

	public RogueliteCharacterClearRecord(eCharacterType characterType, eWorldType worldType, eGameDifficultyType difficulty)
	{
	}
}
