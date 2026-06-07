using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace GenericParsing
{
	public class GenericParser : IDisposable
	{
		private enum RowType
		{
			Unknown = 0,
			CommentRow = 1,
			HeaderRow = 2,
			SkippedRow = 3,
			DataRow = 4
		}

		public const int DefaultMaxBufferSize = 4096;

		public const int DefaultMaxRows = 0;

		public const int DefaultSkipStartingDataRows = 0;

		public const int DefaultExpectedColumnCount = 0;

		public const bool DefaultFirstRowHasHeader = false;

		public const bool DefaultTrimResults = false;

		public const bool DefaulStripControlCharacters = false;

		public const bool DefaulSkipEmptyRows = true;

		public const FieldType DefaultTextFieldType = FieldType.Delimited;

		public const bool DefaultFirstRowSetsExpectedColumnCount = false;

		public const char DefaultColumnDelimiter = ',';

		public const char DefaultTextQualifier = '"';

		public const char DefaultCommentCharacter = '#';

		private const string XML_ROOT_NODE = "GenericParser";

		private const string XML_COLUMN_WIDTH = "ColumnWidth";

		private const string XML_COLUMN_WIDTHS = "ColumnWidths";

		private const string XML_MAX_BUFFER_SIZE = "MaxBufferSize";

		private const string XML_MAX_ROWS = "MaxRows";

		private const string XML_SKIP_STARTING_DATA_ROWS = "SkipStartingDataRows";

		private const string XML_EXPECTED_COLUMN_COUNT = "ExpectedColumnCount";

		private const string XML_FIRST_ROW_HAS_HEADER = "FirstRowHasHeader";

		private const string XML_TRIM_RESULTS = "TrimResults";

		private const string XML_STRIP_CONTROL_CHARS = "StripControlChars";

		private const string XML_SKIP_EMPTY_ROWS = "SkipEmptyRows";

		private const string XML_TEXT_FIELD_TYPE = "TextFieldType";

		private const string XML_FIRST_ROW_SETS_EXPECTED_COLUMN_COUNT = "FirstRowSetsExpectedColumnCount";

		private const string XML_COLUMN_DELIMITER = "ColumnDelimiter";

		private const string XML_TEXT_QUALIFIER = "TextQualifier";

		private const string XML_ESCAPE_CHARACTER = "EscapeCharacter";

		private const string XML_COMMENT_CHARACTER = "CommentCharacter";

		private const string XML_SAFE_STRING_DELIMITER = ",";

		protected ParserState m_ParserState;

		protected List<string> m_lstData;

		protected List<string> m_lstColumnNames;

		private FieldType m_textFieldType;

		private int[] m_iaColumnWidths;

		private int m_intMaxBufferSize;

		private int m_intMaxRows;

		private int m_intSkipStartingDataRows;

		private int m_intExpectedColumnCount;

		private bool m_blnFirstRowHasHeader;

		private bool m_blnTrimResults;

		private bool m_blnStripControlChars;

		private bool m_blnSkipEmptyRows;

		private bool m_blnFirstRowSetsExpectedColumnCount;

		private char? m_chColumnDelimiter;

		private char? m_chTextQualifier;

		private char? m_chEscapeCharacter;

		private char? m_chCommentCharacter;

		private TextReader m_txtReader;

		private bool m_blnIsCurrentRowEmpty;

		private bool m_blnHeaderRowFound;

		private bool m_blnFoundTextQualifierAtStart;

		private bool m_blnContainsEscapedCharacters;

		private int m_intStartIndexOfNewData;

		private int m_intNumberOfCharactersInBuffer;

		private int m_intDataRowNumber;

		private int m_intFileRowNumber;

		private int m_intReadIndex;

		private int m_intStartOfCurrentColumnIndex;

		private char m_chCurrentChar;

		private char[] m_caBuffer;

		private RowType m_RowType;

		private object m_objLock;

		private bool m_blnDisposed;

		public bool IsDisposed => false;

		public int[] ColumnWidths
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int MaxBufferSize
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int MaxRows
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int SkipStartingDataRows
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int DataRowNumber => 0;

		public int FileRowNumber => 0;

		public int ExpectedColumnCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool FirstRowHasHeader
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool TrimResults
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool StripControlChars
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool SkipEmptyRows
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsCurrentRowEmpty => false;

		public FieldType TextFieldType
		{
			get
			{
				return default(FieldType);
			}
			set
			{
			}
		}

		public bool FirstRowSetsExpectedColumnCount
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ParserState State => default(ParserState);

		public char? ColumnDelimiter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public char? TextQualifier
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public char? EscapeCharacter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public char? CommentCharacter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string this[int intColumnIndex] => null;

		public string this[string strColumnName] => null;

		public int ColumnCount => 0;

		public int LargestColumnCount => 0;

		public event EventHandler Disposed
		{
			add
			{
			}
			remove
			{
			}
		}

		private static T[] CloneArray<T>(T[] array)
		{
			return null;
		}

		public GenericParser()
		{
		}

		public GenericParser(string strFileName)
		{
		}

		public GenericParser(string strFileName, Encoding encoding)
		{
		}

		public GenericParser(TextReader txtReader)
		{
		}

		public void SetDataSource(string strFileName)
		{
		}

		public void SetDataSource(string strFileName, Encoding encoding)
		{
		}

		public void SetDataSource(TextReader txtReader)
		{
		}

		public bool Read()
		{
			return false;
		}

		public void Load(XmlReader xrConfigXmlFile)
		{
		}

		public void Load(TextReader trConfigXmlFile)
		{
		}

		public void Load(Stream sConfigXmlFile)
		{
		}

		public void Load(string strConfigXmlFile)
		{
		}

		public virtual void Load(XmlDocument xmlConfig)
		{
		}

		public void Save(XmlWriter xwXmlConfig)
		{
		}

		public void Save(TextWriter twXmlConfig)
		{
		}

		public void Save(Stream sXmlConfig)
		{
		}

		public void Save(string strConfigXmlFile)
		{
		}

		public virtual XmlDocument Save()
		{
			return null;
		}

		public void Close()
		{
		}

		public int GetColumnIndex(string strColumnName)
		{
			return 0;
		}

		public string GetColumnName(int intColumnIndex)
		{
			return null;
		}

		public void Dispose()
		{
		}

		protected virtual void OnDisposed()
		{
		}

		protected virtual void Dispose(bool blnDisposing)
		{
		}

		private void _InitializeParse()
		{
		}

		private bool _GetNextCharacter()
		{
			return false;
		}

		private void _SkipCommentRows()
		{
		}

		private void _SkipToEndOfText()
		{
		}

		private void _CleanUpParser(bool blnCompletely)
		{
		}

		private void _ParseRowType()
		{
		}

		private void _SetColumnNames()
		{
		}

		private void _HandleEndOfRow(int intEndOfDataIndex)
		{
		}

		private void _ExtractColumn(int intEndOfDataIndex)
		{
		}

		private void _CopyRemainingDataToFront(int intStartIndex)
		{
		}

		private string _GetColumnName(int intColumnIndex)
		{
			return null;
		}

		private int _GetColumnIndex(string strColumnName)
		{
			return 0;
		}

		private ParsingException _CreateParsingException(string strMessage)
		{
			return null;
		}

		private void _InitializeConfigurationVariables()
		{
		}
	}
}
