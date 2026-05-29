using System;

namespace CsvHelper.Expressions
{
	public class ObjectRecordCreator : RecordCreator
	{
		public ObjectRecordCreator(CsvReader reader)
			: base(null)
		{
		}

		protected override Delegate CreateCreateRecordDelegate(Type recordType)
		{
			return null;
		}
	}
}
