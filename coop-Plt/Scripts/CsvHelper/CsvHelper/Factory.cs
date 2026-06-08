using System.Globalization;
using System.IO;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public class Factory : IFactory
	{
		public virtual IParser CreateParser(TextReader reader, CsvConfiguration configuration)
		{
			return new CsvParser(reader, configuration);
		}

		public virtual IParser CreateParser(TextReader reader, CultureInfo cultureInfo)
		{
			return new CsvParser(reader, cultureInfo);
		}

		public virtual IReader CreateReader(TextReader reader, CsvConfiguration configuration)
		{
			return new CsvReader(reader, configuration);
		}

		public virtual IReader CreateReader(TextReader reader, CultureInfo cultureInfo)
		{
			return new CsvReader(reader, cultureInfo);
		}

		public virtual IReader CreateReader(IParser parser)
		{
			return new CsvReader(parser);
		}

		public virtual IWriter CreateWriter(TextWriter writer, CsvConfiguration configuration)
		{
			return new CsvWriter(writer, configuration);
		}

		public virtual IWriter CreateWriter(TextWriter writer, CultureInfo cultureInfo)
		{
			return new CsvWriter(writer, cultureInfo);
		}

		public IHasMap<T> CreateClassMapBuilder<T>()
		{
			return new ClassMapBuilder<T>();
		}
	}
}
