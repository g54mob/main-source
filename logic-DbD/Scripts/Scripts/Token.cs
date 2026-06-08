using System;

public class Token
{
	public enum TYPE
	{
		NAME = 0,
		SPECIAL = 1,
		NUMBER = 2,
		STRING = 3,
		QUOTED_IDENTIFIER = 4,
		NON_QUOTED_IDENTIFER = 5,
		COMMENT = 6,
		KEYWORD = 7,
		WHITESPACE = 8
	}

	private string token;

	private TYPE type;

	public Token(string token, TYPE type)
	{
		this.token = token;
		this.type = type;
	}

	public string GetString()
	{
		return token;
	}

	public TYPE GetTokenType()
	{
		return type;
	}

	public bool Equals(string value)
	{
		return token.Equals(value, StringComparison.OrdinalIgnoreCase);
	}

	public override string ToString()
	{
		return token;
	}

	public string Upper()
	{
		return token.ToUpperInvariant();
	}
}
