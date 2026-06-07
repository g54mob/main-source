using System;
using System.Globalization;
using System.Reflection;
using CsvHelper.TypeConversion;

namespace CsvHelper.Configuration
{
	public interface IReaderConfiguration : IParserConfiguration
	{
		bool HasHeaderRecord { get; set; }

		Action<bool, string[], int, ReadingContext> HeaderValidated { get; set; }

		Action<string[], int, ReadingContext> MissingFieldFound { get; set; }

		Func<CsvHelperException, bool> ReadingExceptionOccurred { get; set; }

		CultureInfo CultureInfo { get; set; }

		TypeConverterOptionsCache TypeConverterOptionsCache { get; set; }

		TypeConverterCache TypeConverterCache { get; set; }

		Func<string, int, string> PrepareHeaderForMatch { get; set; }

		Func<Type, bool> ShouldUseConstructorParameters { get; set; }

		Func<Type, ConstructorInfo> GetConstructor { get; set; }

		bool IgnoreReferences { get; set; }

		Func<string[], bool> ShouldSkipRecord { get; set; }

		bool IncludePrivateMembers { get; set; }

		Func<Type, string, string> ReferenceHeaderPrefix { get; set; }

		bool DetectColumnCountChanges { get; set; }

		MemberTypes MemberTypes { get; set; }

		ClassMapCollection Maps { get; }

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
