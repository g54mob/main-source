using System;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public interface IParser : IDisposable
	{
		ReadingContext Context { get; }

		IParserConfiguration Configuration { get; }

		IFieldReader FieldReader { get; }

		string[] Read();

		Task<string[]> ReadAsync();
	}
}
