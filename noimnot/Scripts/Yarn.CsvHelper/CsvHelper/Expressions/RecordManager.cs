using System;

namespace CsvHelper.Expressions
{
	public class RecordManager
	{
		private readonly CsvReader reader;

		private readonly RecordCreatorFactory recordCreatorFactory;

		private readonly RecordHydrator recordHydrator;

		private readonly RecordWriterFactory recordWriterFactory;

		public RecordManager(CsvReader reader)
		{
		}

		public RecordManager(CsvWriter writer)
		{
		}

		public T Create<T>()
		{
			return default(T);
		}

		public object Create(Type recordType)
		{
			return null;
		}

		public void Hydrate<T>(T record)
		{
		}

		public void Write<T>(T record)
		{
		}
	}
}
