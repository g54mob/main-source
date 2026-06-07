using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllCharacterScoreRecord_Event
{
	[SerializeField]
	private List<CharacterScoreRecord> List_CharacterBestScores;

	public void RecordCharacterScore(eCharacterType characterType, int score)
	{
	}

	public int GetCharacterBestScore(eCharacterType characterType)
	{
		return 0;
	}
}
