using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllCharacterClearRecord_RogueliteMode
{
	[SerializeField]
	private List<RogueliteCharacterClearRecord> List_CharacterClearRecords;

	public void RecordCharacterClear(eCharacterType characterType, eWorldType worldType, eGameDifficultyType difficulty)
	{
	}

	public bool GetCharacterClearState(eCharacterType characterType, eWorldType worldType, eGameDifficultyType difficulty)
	{
		return false;
	}
}
