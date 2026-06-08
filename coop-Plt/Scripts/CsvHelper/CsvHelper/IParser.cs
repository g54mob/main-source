using System;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public interface IParser : IDisposable
	{
		long ByteCount { get; }

		long CharCount { get; }

		int Count { get; }

		string this[int index] { get; }

		string[] Record { get; }

		string RawRecord { get; }

		int Row { get; }

		int RawRow { get; }

		string Delimiter { get; }

		CsvContext Context { get; }

		IParserConfiguration Configuration { get; }

		bool Read();

		Task<bool> ReadAsync();
	}
}
