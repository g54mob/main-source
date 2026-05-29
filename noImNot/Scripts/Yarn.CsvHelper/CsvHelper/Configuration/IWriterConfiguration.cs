using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	public interface IWriterConfiguration : ISerializerConfiguration
	{
		string QuoteString { get; }

		string DoubleQuoteString { get; }

		Func<string, WritingContext, bool> ShouldQuote { get; set; }

		CultureInfo CultureInfo { get; set; }

		TypeConverterOptionsCache TypeConverterOptionsCache { get; set; }

		TypeConverterCache TypeConverterCache { get; set; }

		bool AllowComments { get; set; }

		char Comment { get; set; }

		bool HasHeaderRecord { get; set; }

		bool IgnoreReferences { get; set; }

		bool IncludePrivateMembers { get; set; }

		Func<Type, string, string> ReferenceHeaderPrefix { get; set; }

		MemberTypes MemberTypes { get; set; }

		ClassMapCollection Maps { get; }

		bool UseNewObjectForNullReferenceMembers { get; set; }

		IComparer<string> DynamicPropertySort { get; set; }

		TMap RegisterClassMap<TMap>() where TMap : ClassMap;

		ClassMap RegisterClassMap(Type classMapType);

		void RegisterClassMap(ClassMap map);

		void UnregisterClassMap<TMap>() where TMap : ClassMap;

		void UnregisterClassMap(Type classMapType);

		void UnregisterClassMap();

		ClassMap<T> AutoMap<T>();

		ClassMap AutoMap(Type type);
	}
}
