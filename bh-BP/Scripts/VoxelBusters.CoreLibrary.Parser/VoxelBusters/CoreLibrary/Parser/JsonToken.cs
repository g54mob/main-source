namespace VoxelBusters.CoreLibrary.Parser
{
	public enum JsonToken
	{
		CurlyOpenBracket = 0,
		CurlyCloseBracket = 1,
		SquareOpenBracket = 2,
		SquareCloseBracket = 3,
		Colon = 4,
		Comma = 5,
		String = 6,
		Number = 7,
		WhiteSpace = 8,
		True = 9,
		False = 10,
		Null = 11,
		None = 12
	}
}
