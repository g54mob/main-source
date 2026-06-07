public struct LBEntry
{
	public int Rank;

	public string Name;

	public int Score;

	public int IconPtr;

	public int[] ExtraData;

	public override string ToString()
	{
		return null;
	}

	public LBEntry(int rank, string name, int score, int iconPtr, int[] extraData)
	{
		Rank = 0;
		Name = null;
		Score = 0;
		IconPtr = 0;
		ExtraData = null;
	}
}
