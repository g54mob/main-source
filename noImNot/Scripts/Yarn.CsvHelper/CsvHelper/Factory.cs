using System.IO;
using CsvHelper.Configuration;

namespace CsvHelper
{
	public class Factory : IFactory
	{
		public virtual IParser CreateParser(TextReader reader, CsvHelper.Configuration.Configuration configuration)
		{
			return null;
		}

		public virtual IParser CreateParser(TextReader reader)
		{
			return null;
		}

		public virtual IReader CreateReader(TextReader reader, CsvHelper.Configuration.Configuration configuration)
		{
			return null;
		}

		public virtual IReader CreateReader(TextReader reader)
		{
			return null;
		}

		public virtual IReader CreateReader(IParser parser)
		{
			return null;
		}

		public virtual IWriter CreateWriter(TextWriter writer, CsvHelper.Configuration.Configuration configuration)
		{
			return null;
		}

		public virtual IWriter CreateWriter(TextWriter writer)
		{
			return null;
		}

		public IHasMap<T> CreateClassMapBuilder<T>()
		{
			return null;
		}
	}
}
