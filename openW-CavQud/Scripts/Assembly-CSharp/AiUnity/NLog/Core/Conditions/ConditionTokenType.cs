namespace AiUnity.NLog.Core.Conditions
{
	internal enum ConditionTokenType
	{
		EndOfInput = 0,
		BeginningOfInput = 1,
		Number = 2,
		String = 3,
		Keyword = 4,
		Whitespace = 5,
		FirstPunct = 6,
		LessThan = 7,
		GreaterThan = 8,
		LessThanOrEqualTo = 9,
		GreaterThanOrEqualTo = 10,
		EqualTo = 11,
		NotEqual = 12,
		LeftParen = 13,
		RightParen = 14,
		Dot = 15,
		Comma = 16,
		Not = 17,
		And = 18,
		Or = 19,
		Minus = 20,
		LastPunct = 21,
		Invalid = 22,
		ClosingCurlyBrace = 23,
		Colon = 24,
		Exclamation = 25,
		Ampersand = 26,
		Pipe = 27
	}
}
