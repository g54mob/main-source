using System;
using System.Collections.Generic;

public class Tokenizer
{
	public class InvalidTokenException : Parser.ParserException
	{
		public InvalidTokenException(string message)
			: base(message)
		{
		}
	}

	public readonly ICollection<string> KEYWORDS = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
	{
		"SELECT", "FROM", "WHERE", "GROUP", "HAVING", "ORDER", "DISTINCT", "ALL", "JOIN", "ON",
		"USING", "EXCEPT", "UNION", "INTERSECT"
	};

	private char[] queryChars;

	private int index;

	public Tokenizer(string query)
	{
		queryChars = query.ToCharArray();
		index = 0;
	}

	public bool HasNextToken()
	{
		int i;
		for (i = index; i < queryChars.Length && char.IsWhiteSpace(queryChars[i]); i++)
		{
		}
		return i < queryChars.Length;
	}

	public Token NextToken()
	{
		if (!HasNextToken())
		{
			return null;
		}
		char c = queryChars[index];
		if (char.IsWhiteSpace(c))
		{
			index++;
			return new Token(c.ToString(), Token.TYPE.WHITESPACE);
		}
		if (IsSpecialSingleChar(c) || IsSpecialMultiChar(c))
		{
			return GetSpecialToken(c);
		}
		if (char.IsLetter(c))
		{
			return GetNameToken(c);
		}
		if (char.IsDigit(c))
		{
			return GetNumberToken(c);
		}
		switch (c)
		{
		case '[':
		case '`':
			return GetNonQuotedIdentifier(c);
		case '"':
		case '\'':
			return GetStringToken(c);
		case '&':
			throw new InvalidTokenException($"The '{c}' character is not supported. Do you mean to use the 'AND' operator?");
		default:
			throw new InvalidTokenException("Invalid character not supported: " + c);
		}
	}

	public bool getSpecificToken(string expectedToken)
	{
		return expectedToken != NextToken().GetString();
	}

	public bool IsSpecialSingleChar(char c)
	{
		return "(),*;+%".IndexOf(c) >= 0;
	}

	public bool IsSpecialMultiChar(char c)
	{
		return "!<>|-.=/".IndexOf(c) >= 0;
	}

	private Token GetNonQuotedIdentifier(char startingChar)
	{
		Token.TYPE type = Token.TYPE.NON_QUOTED_IDENTIFER;
		string text = startingChar.ToString();
		char c = ((startingChar == '[') ? ']' : '`');
		index++;
		while (index < queryChars.Length)
		{
			char c2 = queryChars[index];
			text += c2;
			index++;
			if (c2 == c)
			{
				return new Token(text, type);
			}
		}
		throw new InvalidTokenException($"Column identifier that starts with: {startingChar} is not closed.");
	}

	private Token GetSpecialToken(char startingChar)
	{
		Token.TYPE type = Token.TYPE.SPECIAL;
		string text = startingChar.ToString();
		if (IsSpecialSingleChar(startingChar))
		{
			index++;
			return new Token(text, type);
		}
		char c = startingChar;
		index++;
		if (index >= queryChars.Length)
		{
			switch (c)
			{
			case '!':
				throw new InvalidTokenException("The '!' character must be followed by a '=' sign to create a NOT EQUALS operator.");
			case '|':
				throw new InvalidTokenException("The '|' character must be followed by another '|' sign to create a UNION operator.");
			}
		}
		else
		{
			char c2 = queryChars[index];
			switch (c)
			{
			case '!':
				text += c2;
				index++;
				if (c2 != '=')
				{
					throw new InvalidTokenException("The '!' character must be followed by a '=' sign to create a NOT EQUALS operator.");
				}
				break;
			case '<':
				if (c2 != '=' && c2 != '>')
				{
					return new Token(text, type);
				}
				text += c2;
				index++;
				break;
			case '>':
				if (c2 != '=')
				{
					return new Token(text, type);
				}
				text += c2;
				index++;
				break;
			case '=':
				if (c2 != '=')
				{
					return new Token(text, type);
				}
				text += c2;
				index++;
				break;
			case '|':
				text += c2;
				index++;
				if (c2 != '|')
				{
					throw new InvalidTokenException("The '|' character must be followed by another '|' sign to create a UNION operator.");
				}
				break;
			case '.':
				if (!char.IsDigit(c2))
				{
					return new Token(text, type);
				}
				index--;
				return GetNumberToken(c2);
			case '/':
				if (c2 != '*')
				{
					return new Token(text, type);
				}
				index++;
				return GetComment();
			default:
				if (c2 != '-')
				{
					return new Token(text, type);
				}
				throw new InvalidTokenException("Single line comments (lines that start with \"--\") are not supported.");
			}
		}
		return new Token(text, type);
	}

	private Token GetComment()
	{
		Token.TYPE type = Token.TYPE.COMMENT;
		string text = "/*";
		bool flag = false;
		while (index < queryChars.Length)
		{
			char c = queryChars[index];
			text += c;
			if (flag && c == '/')
			{
				index++;
				return new Token(text, type);
			}
			if (c == '*')
			{
				flag = true;
			}
			index++;
		}
		throw new InvalidTokenException("Comments must be terminated and closed with a \"*/\" character.");
	}

	private Token GetNameToken(char startingChar)
	{
		string text = startingChar.ToString();
		index++;
		while (index < queryChars.Length)
		{
			char c = queryChars[index];
			if (!char.IsLetter(c) && !char.IsDigit(c) && c != '_')
			{
				return new Token(text, KEYWORDS.Contains(text) ? Token.TYPE.KEYWORD : Token.TYPE.NAME);
			}
			text += c;
			index++;
		}
		return new Token(text, KEYWORDS.Contains(text) ? Token.TYPE.KEYWORD : Token.TYPE.NAME);
	}

	private Token GetNumberToken(char startingChar)
	{
		Token.TYPE type = Token.TYPE.NUMBER;
		string text = startingChar.ToString();
		bool flag = false;
		bool flag2 = startingChar == '.';
		bool flag3 = false;
		bool flag4 = false;
		index++;
		while (index < queryChars.Length)
		{
			char c = queryChars[index];
			if (flag4 && !char.IsDigit(c))
			{
				throw new InvalidTokenException("Signed exponents must be followed by an integer. ");
			}
			if (char.IsLetter(c) && c != 'E' && c != 'e')
			{
				throw new InvalidTokenException($"Numerical values cannot contain the '{c}' character.");
			}
			if (!char.IsDigit(c) && c != 'E' && c != 'e' && c != '.' && c != '+' && c != '-')
			{
				return new Token(text, type);
			}
			switch (c)
			{
			case 'E':
			case 'e':
				if (flag)
				{
					throw new InvalidTokenException("Numbers cannot have two or more exponents (e/E).");
				}
				if (index + 1 >= queryChars.Length)
				{
					throw new InvalidTokenException($"Valid numeric values must have another number after the exponent ({c})");
				}
				if (char.IsWhiteSpace(queryChars[index + 1]))
				{
					throw new InvalidTokenException($"Valid numeric values must have another number after the exponent ({c})");
				}
				flag = true;
				flag3 = true;
				flag4 = false;
				break;
			case '.':
				if (flag2)
				{
					throw new InvalidTokenException("Numbers can only have one decimal character.");
				}
				if (flag)
				{
					throw new InvalidTokenException("Decimals cannot be placed after exponents.");
				}
				flag2 = true;
				flag3 = false;
				flag4 = false;
				break;
			case '+':
			case '-':
				if (!flag3)
				{
					return new Token(text, type);
				}
				if (index + 1 >= queryChars.Length)
				{
					throw new InvalidTokenException("Signed exponents must be followed by an integer. ");
				}
				flag3 = false;
				flag4 = true;
				break;
			default:
				if (char.IsDigit(c))
				{
					flag3 = false;
					flag4 = false;
				}
				break;
			}
			text += c;
			index++;
		}
		return new Token(text, type);
	}

	private Token GetStringToken(char startingChar)
	{
		Token.TYPE type = ((startingChar == '\'') ? Token.TYPE.STRING : Token.TYPE.QUOTED_IDENTIFIER);
		string text = startingChar.ToString();
		bool flag = startingChar == '\'';
		bool flag2 = false;
		index++;
		while (index < queryChars.Length)
		{
			char c = queryChars[index];
			if ((c == '\'' && flag) || (!flag && c == '"'))
			{
				flag2 = !flag2;
			}
			else if (flag2)
			{
				return new Token(text, type);
			}
			text += c;
			index++;
		}
		if (!flag2)
		{
			throw new InvalidTokenException($"String that starts with: {startingChar} is not closed.");
		}
		return new Token(text, type);
	}
}
