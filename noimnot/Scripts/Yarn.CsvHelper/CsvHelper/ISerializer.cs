using System;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public interface ISerializer : IDisposable
	{
		WritingContext Context { get; }

		ISerializerConfiguration Configuration { get; }

		void Write(string[] record);

		Task WriteAsync(string[] record);

		void WriteLine();

		Task WriteLineAsync();
	}
}
