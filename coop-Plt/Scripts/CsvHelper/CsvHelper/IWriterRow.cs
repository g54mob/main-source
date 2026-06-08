using System;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvHelper
{
	public interface IWriterRow
	{
		string[] HeaderRecord { get; }

		int Row { get; }

		int Index { get; }

		CsvContext Context { get; }

		IWriterConfiguration Configuration { get; }

		void WriteConvertedField(string field, Type fieldType);

		void WriteField(string field);

		void WriteField(string field, bool shouldQuote);

		void WriteField<T>(T field);

		void WriteField<T>(T field, ITypeConverter converter);

		void WriteField<T, TConverter>(T field);

		void WriteComment(string comment);

		void WriteHeader<T>();

		void WriteHeader(Type type);

		void WriteRecord<T>(T record);
	}
}
