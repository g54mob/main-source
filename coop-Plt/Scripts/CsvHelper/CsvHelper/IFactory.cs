using System.Globalization;
using System.IO;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public interface IFactory
	{
		IParser CreateParser(TextReader reader, CsvConfiguration configuration);

		IParser CreateParser(TextReader reader, CultureInfo cultureInfo);

		IReader CreateReader(TextReader reader, CsvConfiguration configuration);

		IReader CreateReader(TextReader reader, CultureInfo cultureInfo);

		IReader CreateReader(IParser parser);

		IWriter CreateWriter(TextWriter writer, CsvConfiguration configuration);

		IWriter CreateWriter(TextWriter writer, CultureInfo cultureInfo);

		IHasMap<T> CreateClassMapBuilder<T>();
	}
}
