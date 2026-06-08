using System;
using System.Reflection;

namespace CsvHelper.Expressions
{
	public class RecordCreatorFactory
	{
		private readonly CsvReader reader;

		private readonly DynamicRecordCreator dynamicRecordCreator;

		private readonly PrimitiveRecordCreator primitiveRecordCreator;

		private readonly ObjectRecordCreator objectRecordCreator;

		public RecordCreatorFactory(CsvReader reader)
		{
			this.reader = reader;
			dynamicRecordCreator = new DynamicRecordCreator(reader);
			primitiveRecordCreator = new PrimitiveRecordCreator(reader);
			objectRecordCreator = new ObjectRecordCreator(reader);
		}

		public virtual RecordCreator MakeRecordCreator(Type recordType)
		{
			if (recordType == typeof(object))
			{
				return dynamicRecordCreator;
			}
			if (recordType.GetTypeInfo().IsPrimitive)
			{
				return primitiveRecordCreator;
			}
			return objectRecordCreator;
		}
	}
}
