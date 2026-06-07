using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace GenericParsing
{
	public class GenericParserAdapter : GenericParser
	{
		public const bool DefaultIncludeFileLineNumber = false;

		public const int DefaultSkipEndingDataRows = 0;

		private const string XML_INCLUDE_FILE_LINE_NUMBER = "IncludeFileLineNumber";

		private const string XML_SKIP_ENDING_DATA_ROWS = "SkipEndingDataRows";

		private const string FILE_LINE_NUMBER = "FileLineNumber";

		private bool m_blnIncludeFileLineNumber;

		private int m_intSkipEndingDataRows;

		public bool IncludeFileLineNumber
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int SkipEndingDataRows
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		private static void AddColumnToTable(DataTable dtData, string strColumnName)
		{
		}

		public GenericParserAdapter()
		{
		}

		public GenericParserAdapter(string strFileName)
		{
		}

		public GenericParserAdapter(string strFileName, Encoding encoding)
		{
		}

		public GenericParserAdapter(TextReader txtReader)
		{
		}

		public XmlDocument GetXml()
		{
			return null;
		}

		public DataSet GetDataSet()
		{
			return null;
		}

		public DataTable GetDataTable()
		{
			return null;
		}

		public override void Load(XmlDocument xmlConfig)
		{
		}

		public override XmlDocument Save()
		{
			return null;
		}
	}
}
