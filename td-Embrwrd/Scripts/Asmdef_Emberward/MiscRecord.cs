using System;

[Serializable]
public class MiscRecord
{
	public bool PlayerLearnedHoldShiftToBuild;

	public bool UsedScrapMasterBefore;

	public int HalloweenEvent_2024_BestRecord;

	public int HalloweenEvent_2024_V2_BestRecord;

	public int HalloweenEvent_2024_V3_BestRecord;

	public int SanctumOfEnigma_BestRecord;

	public int maxSimultaneousAltarPact_Casual;

	public int maxSimultaneousAltarPact_Normal;

	public int maxSimultaneousAltarPact_Heroic;

	public AllCharacterClearRecord_RogueliteMode Character_BaseModeClear_Casual;

	public AllCharacterClearRecord_RogueliteMode Character_BaseModeClear_Normal;

	public AllCharacterClearRecord_RogueliteMode Character_BaseModeClear_Heroic;

	public AllCharacterScoreRecord_RogueliteMode Character_BestInfernoShard_Casual;

	public AllCharacterScoreRecord_RogueliteMode Character_BestInfernoShard_Normal;

	public AllCharacterScoreRecord_RogueliteMode Character_BestInfernoShard_Heroic;

	public AllCharacterScoreRecord_Event ScoreRecord_MistyGraveyard_V3;

	public AllCharacterScoreRecord_Event ScoreRecord_XMasEvent_V3;

	public AllCharacterScoreRecord_Event ScoreRecord_SanctumOfEnigma;

	public int GetBestAltarPactRecord(eGameDifficultyType difficulty)
	{
		return 0;
	}

	public void SetBestAltarPactRecord(eGameDifficultyType difficulty, int value)
	{
	}
}
