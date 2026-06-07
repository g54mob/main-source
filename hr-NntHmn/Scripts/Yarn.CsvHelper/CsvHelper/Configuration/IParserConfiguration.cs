using System;
using System.Text;

namespace CsvHelper.Configuration
{
	public interface IParserConfiguration
	{
		int BufferSize { get; set; }

		bool CountBytes { get; set; }

		Encoding Encoding { get; set; }

		Action<ReadingContext> BadDataFound { get; set; }

		bool LineBreakInQuotedFieldIsBadData { get; set; }

		char Comment { get; set; }

		bool AllowComments { get; set; }

		bool IgnoreBlankLines { get; set; }

		bool IgnoreQuotes { get; set; }

		char Quote { get; set; }

		string Delimiter { get; set; }

		char Escape { get; set; }

		TrimOptions TrimOptions { get; set; }
	}
}
