using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace GameCreator.Runtime.Common.Mathematics
{
	public class Tokenizer
	{
		public enum TokenType
		{
			EndOfExpression = 0,
			Add = 1,
			Subtract = 2,
			Multiply = 3,
			Divide = 4,
			OpenParenthesis = 5,
			CloseParenthesis = 6,
			Number = 7
		}

		private static readonly StringBuilder StringBuilder = new StringBuilder();

		private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;

		private const char CHAR_EOE = '\0';

		private const char CHAR_ADD = '+';

		private const char CHAR_SUBTRACT = '-';

		private const char CHAR_MULTIPLY = '*';

		private const char CHAR_DIVIDE = '/';

		private const char CHAR_PARENTHESIS_OPEN = '(';

		private const char CHAR_PARENTHESIS_CLOSE = ')';

		private const char CHAR_DOT = '.';

		private readonly TextReader m_Reader;

		private char CurrentCharacter { get; set; }

		public TokenType Type { get; private set; }

		public float Number { get; private set; }

		public Tokenizer(string expression)
		{
			m_Reader = new StringReader(expression);
			NextCharacter();
			NextToken();
		}

		private void NextCharacter()
		{
			int num = m_Reader.Read();
			CurrentCharacter = ((num >= 0) ? ((char)num) : '\0');
		}

		public void NextToken()
		{
			while (char.IsWhiteSpace(CurrentCharacter))
			{
				NextCharacter();
			}
			switch (CurrentCharacter)
			{
			case '\0':
				Type = TokenType.EndOfExpression;
				return;
			case '+':
				NextCharacter();
				Type = TokenType.Add;
				return;
			case '-':
				NextCharacter();
				Type = TokenType.Subtract;
				return;
			case '*':
				NextCharacter();
				Type = TokenType.Multiply;
				return;
			case '/':
				NextCharacter();
				Type = TokenType.Divide;
				return;
			case '(':
				NextCharacter();
				Type = TokenType.OpenParenthesis;
				return;
			case ')':
				NextCharacter();
				Type = TokenType.CloseParenthesis;
				return;
			}
			if (!char.IsDigit(CurrentCharacter) && CurrentCharacter != '.')
			{
				throw new Exception($"Unexpected character: {CurrentCharacter}");
			}
			StringBuilder.Clear();
			bool flag = false;
			while (char.IsDigit(CurrentCharacter) || (!flag && CurrentCharacter == '.'))
			{
				StringBuilder.Append(CurrentCharacter);
				flag = CurrentCharacter == '.';
				NextCharacter();
			}
			Number = float.Parse(StringBuilder.ToString(), Culture);
			Type = TokenType.Number;
		}
	}
}
