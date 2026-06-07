using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllCharacterScoreRecord_RogueliteMode
{
	[SerializeField]
	private List<RogueliteCharacterScoreRecord> List_CharacterBestScores;

	public void RecordCharacterScore(eCharacterType characterType, eWorldType worldType, eGameDifficultyType difficulty, int score)
	{
	}

	public int GetCharacterBestScore(eCharacterType characterType, eWorldType worldType, eGameDifficultyType difficulty)
	{
		return 0;
	}

	public RogueliteCharacterScoreRecord GetBestScoreEntry(eWorldType worldType, eGameDifficultyType difficulty, bool excludeEventCharacters = false)
	{
		return null;
	}
}
