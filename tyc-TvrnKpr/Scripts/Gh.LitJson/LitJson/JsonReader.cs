using System.Collections.Generic;
using System.IO;

namespace LitJson
{
	public class JsonReader
	{
		private static readonly IDictionary<int, IDictionary<int, int[]>> parseTable;

		private Stack<int> automationStack;

		private Lexer lexer;

		private TextReader reader;

		private int currentInput;

		private int currentSymbol;

		private bool parserInString;

		private bool parserReturn;

		private bool readStarted;

		private bool readerIsOwned;

		public bool AllowComments
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AllowSingleQuotedStrings
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SkipNonMembers { get; set; }

		public bool TypeHinting { get; set; }

		public string HintTypeName { get; set; }

		public string HintValueName { get; set; }

		public bool EndOfInput { get; private set; }

		public bool EndOfJson { get; private set; }

		public JsonToken Token { get; private set; }

		public object Value { get; private set; }

		public JsonReader(string json)
		{
		}

		public JsonReader(TextReader reader)
		{
		}

		private JsonReader(TextReader reader, bool owned)
		{
		}

		static JsonReader()
		{
		}

		private static void TableAddCol(ParserToken row, int col, params int[] symbols)
		{
		}

		private static void TableAddRow(ParserToken rule)
		{
		}

		private void ProcessNumber(string number)
		{
		}

		private void ProcessSymbol()
		{
		}

		private bool ReadToken()
		{
			return false;
		}

		public void Close()
		{
		}

		public bool Read()
		{
			return false;
		}

		public string GetSourceTextDebug()
		{
			return null;
		}
	}
}
