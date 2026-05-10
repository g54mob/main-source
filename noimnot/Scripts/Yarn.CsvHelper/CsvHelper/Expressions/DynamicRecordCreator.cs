using System;

namespace CsvHelper.Expressions
{
	public class DynamicRecordCreator : RecordCreator
	{
		public DynamicRecordCreator(CsvReader reader)
			: base(null)
		{
		}

		protected override Delegate CreateCreateRecordDelegate(Type recordType)
		{
			return null;
		}

		protected virtual object CreateDynamicRecord()
		{
			return null;
		}
	}
}
