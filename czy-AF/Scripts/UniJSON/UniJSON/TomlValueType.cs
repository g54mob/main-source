namespace UniJSON
{
	public enum TomlValueType
	{
		BareKey = 0,
		QuotedKey = 1,
		DottedKey = 2,
		BasicString = 3,
		MultilineBasicString = 4,
		LiteralString = 5,
		MultilineLiteralString = 6,
		Integer = 7,
		Float = 8,
		Boolean = 9,
		OffsetDatetime = 10,
		Array = 11,
		Table = 12
	}
}
