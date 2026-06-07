using System;

namespace CsvHelper.Expressions
{
	public class PrimitiveRecordCreator : RecordCreator
	{
		public PrimitiveRecordCreator(CsvReader reader)
			: base(null)
		{
		}

		protected override Delegate CreateCreateRecordDelegate(Type recordType)
		{
			return null;
		}
	}
}
