using System;

namespace CLanguage.Syntax
{
	public struct Token : IEquatable<Token>
	{
		public readonly int Kind;

		public readonly Location Location;

		public readonly Location EndLocation;

		public readonly object? Value;

		public string StringValue => null;

		public string Text => null;

		public Token(int kind, object? value, Location location, Location endLocation)
		{
			Kind = 0;
			Location = default(Location);
			EndLocation = default(Location);
			Value = null;
		}

		public Token(int kind, object? value)
		{
			Kind = 0;
			Location = default(Location);
			EndLocation = default(Location);
			Value = null;
		}

		public Token(char kind)
		{
			Kind = 0;
			Location = default(Location);
			EndLocation = default(Location);
			Value = null;
		}

		public override string ToString()
		{
			return null;
		}

		public Token AsKind(int kind)
		{
			return default(Token);
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(Token other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static bool operator ==(Token token1, Token token2)
		{
			return false;
		}

		public static bool operator !=(Token token1, Token token2)
		{
			return false;
		}
	}
}
