using System.Text;

namespace CsvHelper.Configuration
{
	public interface IParserConfiguration
	{
		bool CacheFields { get; }

		bool LeaveOpen { get; }

		string NewLine { get; }

		bool IsNewLineSet { get; }

		CsvMode Mode { get; }

		int BufferSize { get; }

		int ProcessFieldBufferSize { get; }

		bool CountBytes { get; }

		Encoding Encoding { get; }

		BadDataFound BadDataFound { get; }

		bool LineBreakInQuotedFieldIsBadData { get; }

		char Comment { get; }

		bool AllowComments { get; }

		bool IgnoreBlankLines { get; }

		char Quote { get; }

		string Delimiter { get; }

		bool DetectDelimiter { get; }

		string[] DetectDelimiterValues { get; }

		char Escape { get; }

		TrimOptions TrimOptions { get; }

		char[] WhiteSpaceChars { get; }

		bool ExceptionMessagesContainRawData { get; }
	}
}
