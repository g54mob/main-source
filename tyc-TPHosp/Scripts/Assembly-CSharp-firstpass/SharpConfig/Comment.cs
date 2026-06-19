using System;

namespace SharpConfig
{
	public struct Comment
	{
		public string Value;

		public char Symbol;

		public Comment(string value)
		{
			Value = value;
			Symbol = Configuration.ValidCommentChars[0];
		}

		public Comment(string value, char symbol)
		{
			Value = value;
			Symbol = symbol;
		}

		public override string ToString()
		{
			char symbol = Symbol;
			return string.Join(Environment.NewLine, Array.ConvertAll((Value ?? string.Empty).Split(new string[2] { "\r\n", "\n" }, StringSplitOptions.None), (string s) => $"{symbol} {s}"));
		}
	}
}
