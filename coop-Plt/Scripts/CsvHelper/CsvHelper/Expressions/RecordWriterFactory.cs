using System;
using System.Dynamic;
using System.Reflection;

namespace CsvHelper.Expressions
{
	public class RecordWriterFactory
	{
		private readonly CsvWriter writer;

		private readonly ExpandoObjectRecordWriter expandoObjectRecordWriter;

		private readonly DynamicRecordWriter dynamicRecordWriter;

		private readonly PrimitiveRecordWriter primitiveRecordWriter;

		private readonly ObjectRecordWriter objectRecordWriter;

		public RecordWriterFactory(CsvWriter writer)
		{
			this.writer = writer;
			expandoObjectRecordWriter = new ExpandoObjectRecordWriter(writer);
			dynamicRecordWriter = new DynamicRecordWriter(writer);
			primitiveRecordWriter = new PrimitiveRecordWriter(writer);
			objectRecordWriter = new ObjectRecordWriter(writer);
		}

		public virtual RecordWriter MakeRecordWriter<T>(T record)
		{
			Type typeForRecord = writer.GetTypeForRecord(record);
			if (record is ExpandoObject)
			{
				return expandoObjectRecordWriter;
			}
			if (record is IDynamicMetaObjectProvider)
			{
				return dynamicRecordWriter;
			}
			if (typeForRecord.GetTypeInfo().IsPrimitive)
			{
				return primitiveRecordWriter;
			}
			return objectRecordWriter;
		}
	}
}
