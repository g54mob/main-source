using System;

[Serializable]
public class LevelData
{
	public LevelType Type;

	public int NGPlusLvl;

	public bool DidComplete;

	public bool SawCompletionUnlocks;

	public bool SawElevatorReadyToUpgrade;

	public int[] BestDifficultyByChar;

	public float[] BestTimeByChar;

	public int[][] BestDifficultyByCharCombo;

	public float[][] BestTimeByCharCombo;

	public PieceMetaData[] EnemyData;

	public int NumBlueprintDropAttempts;

	public int BestEndlessDepth;

	public int NumAttempts;

	public int[] NumAttemptsByChar;

	public int NumAttemptsBeforeCompletion;

	public int[] NumAttemptsBeforeCompletionByChar;

	public LevelData(LevelType t, int ngPlus)
	{
	}

	public void Reset()
	{
	}

	public int GetReqPrevLvlCompleted(int ngPlusLvl)
	{
		return 0;
	}

	public bool IsUnlocked()
	{
		return false;
	}

	public void ShowUnlockPopup()
	{
	}

	public bool DidCompleteWithChar(CharType t, int tgtDifficulty = 1)
	{
		return false;
	}

	public bool DidCompleteWithCharCombo(CharType t1, CharType t2, int tgtDifficulty = 1)
	{
		return false;
	}

	public int GetBestDiffCompleted()
	{
		return 0;
	}

	public int GetNumCharsCompleted()
	{
		return 0;
	}

	public int GetNumFastTiersCompleted()
	{
		return 0;
	}

	public LevelInfo GetInfo()
	{
		return null;
	}

	public PieceMetaData GetPieceMeta(GridPieceType pt)
	{
		return null;
	}
}
