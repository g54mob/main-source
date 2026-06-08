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
			this.reader = reader;
			recordCreatorFactory = ObjectResolver.Current.Resolve<RecordCreatorFactory>(new object[1] { reader });
			recordHydrator = ObjectResolver.Current.Resolve<RecordHydrator>(new object[1] { reader });
		}

		public RecordManager(CsvWriter writer)
		{
			recordWriterFactory = ObjectResolver.Current.Resolve<RecordWriterFactory>(new object[1] { writer });
		}

		public T Create<T>()
		{
			return recordCreatorFactory.MakeRecordCreator(typeof(T)).Create<T>();
		}

		public object Create(Type recordType)
		{
			return recordCreatorFactory.MakeRecordCreator(recordType).Create(recordType);
		}

		public void Hydrate<T>(T record)
		{
			recordHydrator.Hydrate(record);
		}

		public void Write<T>(T record)
		{
			recordWriterFactory.MakeRecordWriter(record).Write(record);
		}
	}
}
