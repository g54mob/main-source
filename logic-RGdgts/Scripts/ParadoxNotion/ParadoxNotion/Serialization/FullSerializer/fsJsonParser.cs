using System.Text;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public class fsJsonParser
	{
		private int _start;

		private string _input;

		private readonly StringBuilder _cachedStringBuilder;

		private fsResult MakeFailure(string message)
		{
			return default(fsResult);
		}

		private bool TryMoveNext()
		{
			return false;
		}

		private bool HasValue()
		{
			return false;
		}

		private bool HasValue(int offset)
		{
			return false;
		}

		private char Character()
		{
			return '\0';
		}

		private char Character(int offset)
		{
			return '\0';
		}

		private void SkipSpace()
		{
		}

		private bool IsHex(char c)
		{
			return false;
		}

		private uint ParseSingleChar(char c1, uint multipliyer)
		{
			return 0u;
		}

		private uint ParseUnicode(char c1, char c2, char c3, char c4)
		{
			return 0u;
		}

		private fsResult TryUnescapeChar(out char escaped)
		{
			escaped = default(char);
			return default(fsResult);
		}

		private fsResult TryParseExact(string content)
		{
			return default(fsResult);
		}

		private fsResult TryParseTrue(out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		private fsResult TryParseFalse(out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		private fsResult TryParseNull(out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		private bool IsSeparator(char c)
		{
			return false;
		}

		private fsResult TryParseNumber(out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		private fsResult TryParseString(out string str)
		{
			str = null;
			return default(fsResult);
		}

		private fsResult TryParseArray(out fsData arr)
		{
			arr = null;
			return default(fsResult);
		}

		private fsResult TryParseObject(out fsData obj)
		{
			obj = null;
			return default(fsResult);
		}

		private fsResult RunParse(out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		public static fsResult Parse(string input, out fsData data)
		{
			data = null;
			return default(fsResult);
		}

		public static fsData Parse(string input)
		{
			return null;
		}

		private fsJsonParser(string input)
		{
		}
	}
}
