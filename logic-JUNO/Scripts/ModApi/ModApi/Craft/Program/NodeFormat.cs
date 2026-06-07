using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace ModApi.Craft.Program
{
	public static class NodeFormat
	{
		public enum TokenType
		{
			Text = 0,
			Boolean = 1,
			Input = 2,
			List = 3,
			LocalVariableDefinition = 4
		}

		public class Token
		{
			public int ExpressionIndex { get; set; }

			public string Text { get; set; }

			public TokenType TokenType { get; set; }

			public string Validation { get; set; }

			public Token(string text, TokenType tokenType)
			{
				if (text.Contains(":"))
				{
					string[] array = text.Split(new char[1] { ':' });
					if (array.Length == 2)
					{
						text = array[0];
						Validation = array[1];
					}
					else
					{
						Debug.LogErrorFormat("Invalid token name: {0}", text);
					}
				}
				int result = 0;
				if ((tokenType == TokenType.Boolean || tokenType == TokenType.Input) && !int.TryParse(text, out result))
				{
					throw new ProgramException($"Invalid expression index '{text}' found in format.");
				}
				Text = text;
				TokenType = tokenType;
				ExpressionIndex = result;
			}
		}

		public const string ReservedCharacters = "([{|)]}|";

		private const string TokenEndDelimiters = ")]}|";

		private const string TokenStartDelimiters = "([{|";

		public static int GetNumExpressionsInFormat(string format)
		{
			return (from x in Tokenize(format)
				where x.TokenType == TokenType.Boolean || x.TokenType == TokenType.Input
				select x).Count();
		}

		public static List<Token> Tokenize(string format)
		{
			List<Token> list = new List<Token>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			for (int i = 0; i < format.Length; i++)
			{
				if (")]}|".Contains(format[i]) && flag)
				{
					TokenType tokenType = TokenType.Text;
					switch (format[i])
					{
					case ')':
						tokenType = TokenType.Input;
						break;
					case '}':
						tokenType = TokenType.Boolean;
						break;
					case ']':
						tokenType = TokenType.List;
						break;
					case '|':
						tokenType = TokenType.LocalVariableDefinition;
						break;
					}
					list.Add(new Token(stringBuilder.ToString(), tokenType));
					stringBuilder.Clear();
					flag = false;
				}
				else if ("([{|".Contains(format[i]))
				{
					if (stringBuilder.Length > 0)
					{
						list.Add(new Token(stringBuilder.ToString(), TokenType.Text));
						stringBuilder.Clear();
					}
					flag = true;
				}
				else
				{
					stringBuilder.Append(format[i]);
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(new Token(stringBuilder.ToString(), TokenType.Text));
			}
			return list;
		}
	}
}
