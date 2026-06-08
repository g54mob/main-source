using System;

namespace CsvHelper
{
	public readonly struct ShouldQuoteArgs
	{
		public readonly string Field;

		public readonly Type FieldType;

		public readonly IWriterRow Row;

		public ShouldQuoteArgs(string field, Type fieldType, IWriterRow row)
		{
			Field = field;
			FieldType = fieldType;
			Row = row;
		}
	}
}
