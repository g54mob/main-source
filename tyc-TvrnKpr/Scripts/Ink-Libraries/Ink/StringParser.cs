using System.Collections.Generic;
using Ink.Parsed;

namespace Ink
{
	public class StringParser
	{
		public delegate object ParseRule();

		public delegate T SpecificParseRule<T>() where T : class;

		public delegate void ErrorHandler(string message, int index, int lineIndex, bool isWarning);

		public class ParseSuccessStruct
		{
		}

		public static ParseSuccessStruct ParseSuccess;

		public static CharacterSet numbersCharacterSet;

		private char[] _chars;

		protected ErrorHandler errorHandler { get; set; }

		public char currentCharacter => '\0';

		public StringParserState state { get; private set; }

		public bool hadError { get; protected set; }

		public bool endOfInput => false;

		public string remainingString => null;

		public int remainingLength => 0;

		public string inputString { get; private set; }

		public int lineIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int index
		{
			get
			{
				return 0;
			}
			private set
			{
			}
		}

		public StringParser(string str)
		{
		}

		protected virtual string PreProcessInputString(string str)
		{
			return null;
		}

		protected int BeginRule()
		{
			return 0;
		}

		protected object FailRule(int expectedRuleId)
		{
			return null;
		}

		protected void CancelRule(int expectedRuleId)
		{
		}

		protected object SucceedRule(int expectedRuleId, object result = null)
		{
			return null;
		}

		protected virtual void RuleDidSucceed(object result, StringParserState.Element startState, StringParserState.Element endState)
		{
		}

		protected object Expect(ParseRule rule, string message = null, ParseRule recoveryRule = null)
		{
			return null;
		}

		protected void Error(string message, bool isWarning = false)
		{
		}

		protected void ErrorWithParsedObject(string message, Object result, bool isWarning = false)
		{
		}

		protected void ErrorOnLine(string message, int lineNumber, bool isWarning)
		{
		}

		protected void Warning(string message)
		{
		}

		public string LineRemainder()
		{
			return null;
		}

		public void SetFlag(uint flag, bool trueOrFalse)
		{
		}

		public bool GetFlag(uint flag)
		{
			return false;
		}

		public object ParseObject(ParseRule rule)
		{
			return null;
		}

		public T Parse<T>(SpecificParseRule<T> rule) where T : class
		{
			return null;
		}

		public object OneOf(params ParseRule[] array)
		{
			return null;
		}

		public List<object> OneOrMore(ParseRule rule)
		{
			return null;
		}

		public ParseRule Optional(ParseRule rule)
		{
			return null;
		}

		public ParseRule Exclude(ParseRule rule)
		{
			return null;
		}

		public ParseRule OptionalExclude(ParseRule rule)
		{
			return null;
		}

		protected ParseRule String(string str)
		{
			return null;
		}

		private void TryAddResultToList<T>(object result, List<T> list, bool flatten = true)
		{
		}

		public List<T> Interleave<T>(ParseRule ruleA, ParseRule ruleB, ParseRule untilTerminator = null, bool flatten = true)
		{
			return null;
		}

		public string ParseString(string str)
		{
			return null;
		}

		public char ParseSingleCharacter()
		{
			return '\0';
		}

		public string ParseUntilCharactersFromString(string str, int maxCount = -1)
		{
			return null;
		}

		public string ParseUntilCharactersFromCharSet(CharacterSet charSet, int maxCount = -1)
		{
			return null;
		}

		public string ParseCharactersFromString(string str, int maxCount = -1)
		{
			return null;
		}

		public string ParseCharactersFromString(string str, bool shouldIncludeStrChars, int maxCount = -1)
		{
			return null;
		}

		public string ParseCharactersFromCharSet(CharacterSet charSet, bool shouldIncludeChars = true, int maxCount = -1)
		{
			return null;
		}

		public object Peek(ParseRule rule)
		{
			return null;
		}

		public string ParseUntil(ParseRule stopRule, CharacterSet pauseCharacters = null, CharacterSet endCharacters = null)
		{
			return null;
		}

		public int? ParseInt()
		{
			return null;
		}

		public float? ParseFloat()
		{
			return null;
		}

		protected string ParseNewline()
		{
			return null;
		}
	}
}
