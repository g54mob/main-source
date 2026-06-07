public struct LBParams
{
	public CharType TgtChar;

	public LevelType TgtLvl;

	public bool ShowPairScores;

	public bool ShowEndlessScores;

	public int NGPlus;

	public LBParams(bool showEndless, bool showPair, LevelType tgtLvl, CharType tgtChar, int ngPlus = 0)
	{
		TgtChar = default(CharType);
		TgtLvl = default(LevelType);
		ShowPairScores = false;
		ShowEndlessScores = false;
		NGPlus = 0;
	}

	public bool Equals(LBParams other)
	{
		return false;
	}
}
