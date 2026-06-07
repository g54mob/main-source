using System;
using System.Reflection;

namespace CsvHelper.Configuration
{
	public static class ConfigurationFunctions
	{
		private static readonly char[] quoteChars;

		public static void HeaderValidated(bool isValid, string[] headerNames, int headerNameIndex, ReadingContext context)
		{
		}

		public static void MissingFieldFound(string[] headerNames, int index, ReadingContext context)
		{
		}

		public static void BadDataFound(ReadingContext context)
		{
		}

		public static bool ReadingExceptionOccurred(CsvHelperException exception)
		{
			return false;
		}

		public static bool ShouldQuote(string field, WritingContext context)
		{
			return false;
		}

		public static bool ShouldSkipRecord(string[] record)
		{
			return false;
		}

		public static string PrepareHeaderForMatch(string header, int index)
		{
			return null;
		}

		public static bool ShouldUseConstructorParameters(Type type)
		{
			return false;
		}

		public static ConstructorInfo GetConstructor(Type type)
		{
			return null;
		}
	}
}
