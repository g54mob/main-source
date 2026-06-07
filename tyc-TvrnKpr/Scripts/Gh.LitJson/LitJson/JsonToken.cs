namespace LitJson
{
	public enum JsonToken
	{
		None = 0,
		Null = 1,
		ObjectStart = 2,
		PropertyName = 3,
		ObjectEnd = 4,
		ArrayStart = 5,
		ArrayEnd = 6,
		Real = 7,
		Natural = 8,
		String = 9,
		Boolean = 10
	}
}
