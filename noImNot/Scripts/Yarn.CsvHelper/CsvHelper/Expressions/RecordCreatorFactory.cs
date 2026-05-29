using System;

namespace CsvHelper.Expressions
{
	public class RecordCreatorFactory
	{
		private readonly CsvReader reader;

		public RecordCreatorFactory(CsvReader reader)
		{
		}

		public virtual RecordCreator MakeRecordCreator(Type recordType)
		{
			return null;
		}
	}
}
