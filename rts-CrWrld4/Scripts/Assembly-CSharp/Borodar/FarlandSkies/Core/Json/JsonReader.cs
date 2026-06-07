using System.IO;
using System.Text;

namespace Borodar.FarlandSkies.Core.Json
{
	internal sealed class JsonReader
	{
		private enum ReadPhase
		{
			ReadingStream = 0,
			HasReachedEndOfStream = 1,
			HasReachedEndOfInput = 2
		}

		private const int MaximumLookahead = 6;

		private readonly TextReader jsonReader;

		private StringBuilder stringLiteral;

		private StringBuilder unicodeSequence;

		private char[] buffer;

		private int bufferSize;

		private int bufferPos;

		private ReadPhase phase;

		private bool hasReachedEnd;

		private int lineNumber;

		private int linePosition;

		private bool initLineEnding;

		private char lineEnding;

		private int lineEndingLength;

		private bool HasReachedEnd => false;

		public static JsonReader Create(Stream stream)
		{
			return null;
		}

		public static JsonReader Create(TextReader reader)
		{
			return null;
		}

		private JsonReader(TextReader reader)
		{
		}

		private void ReadBuffer()
		{
		}

		private char Peek()
		{
			return '\0';
		}

		private char Peek(int offset)
		{
			return '\0';
		}

		private char ReadChar()
		{
			return '\0';
		}

		private void Accept(int count = 1)
		{
		}

		private void SkipWhitespace()
		{
		}

		private bool MatchString(string match)
		{
			return false;
		}

		public JsonNode Read()
		{
			return null;
		}

		private JsonNode ReadValue()
		{
			return null;
		}

		private string ReadStringLiteral(string context)
		{
			return null;
		}

		private void CheckStringCharacter(char c, string context)
		{
		}

		private JsonNode ReadArray()
		{
			return null;
		}

		private JsonNode ReadObject()
		{
			return null;
		}

		private JsonNode ReadNumeric()
		{
			return null;
		}
	}
}
