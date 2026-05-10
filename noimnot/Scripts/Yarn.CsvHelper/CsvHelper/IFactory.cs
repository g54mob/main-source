using System.IO;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public interface IFactory
	{
		IParser CreateParser(TextReader reader, CsvHelper.Configuration.Configuration configuration);

		IParser CreateParser(TextReader reader);

		IReader CreateReader(TextReader reader, CsvHelper.Configuration.Configuration configuration);

		IReader CreateReader(TextReader reader);

		IReader CreateReader(IParser parser);

		IWriter CreateWriter(TextWriter writer, CsvHelper.Configuration.Configuration configuration);

		IWriter CreateWriter(TextWriter writer);

		IHasMap<T> CreateClassMapBuilder<T>();
	}
}
