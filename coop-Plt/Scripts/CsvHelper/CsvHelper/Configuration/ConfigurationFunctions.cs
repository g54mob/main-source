using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CsvHelper.Configuration
{
	public static class ConfigurationFunctions
	{
		private static readonly char[] lineEndingChars = new char[2] { '\r', '\n' };

		public static void HeaderValidated(HeaderValidatedArgs args)
		{
			if (args.InvalidHeaders.Count() == 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			InvalidHeader[] invalidHeaders = args.InvalidHeaders;
			foreach (InvalidHeader invalidHeader in invalidHeaders)
			{
				stringBuilder.AppendLine(string.Format("Header with name '{0}'[{1}] was not found.", string.Join("' or '", invalidHeader.Names), invalidHeader.Index));
			}
			string value = "If you are expecting some headers to be missing and want to ignore this validation, set the configuration HeaderValidated to null. You can also change the functionality to do something else, like logging the issue.";
			stringBuilder.AppendLine(value);
			throw new HeaderValidationException(args.Context, args.InvalidHeaders, stringBuilder.ToString());
		}

		public static void MissingFieldFound(MissingFieldFoundArgs args)
		{
			string text = "You can ignore missing fields by setting MissingFieldFound to null.";
			if (args.HeaderNames == null || args.HeaderNames.Length == 0)
			{
				throw new MissingFieldException(args.Context, $"Field at index '{args.Index}' does not exist. {text}");
			}
			string text2 = ((args.Index > 0) ? $" at field index '{args.Index}'" : string.Empty);
			if (args.HeaderNames.Length == 1)
			{
				throw new MissingFieldException(args.Context, "Field with name '" + args.HeaderNames[0] + "'" + text2 + " does not exist. " + text);
			}
			throw new MissingFieldException(args.Context, "Field containing names '" + string.Join("' or '", args.HeaderNames) + "'" + text2 + " does not exist. " + text);
		}

		public static void BadDataFound(BadDataFoundArgs args)
		{
			throw new BadDataException(args.Context, "You can ignore bad data by setting BadDataFound to null.");
		}

		public static bool ReadingExceptionOccurred(ReadingExceptionOccurredArgs args)
		{
			return true;
		}

		public static bool ShouldQuote(ShouldQuoteArgs args)
		{
			IWriterConfiguration configuration = args.Row.Configuration;
			if (!string.IsNullOrEmpty(args.Field))
			{
				if (!args.Field.Contains(configuration.Quote) && args.Field[0] != ' ' && args.Field[args.Field.Length - 1] != ' ' && (configuration.Delimiter.Length <= 0 || !args.Field.Contains(configuration.Delimiter)) && (configuration.IsNewLineSet || args.Field.IndexOfAny(lineEndingChars) <= -1))
				{
					if (configuration.IsNewLineSet)
					{
						return args.Field.Contains(configuration.NewLine);
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool ShouldSkipRecord(ShouldSkipRecordArgs args)
		{
			return false;
		}

		public static string PrepareHeaderForMatch(PrepareHeaderForMatchArgs args)
		{
			return args.Header;
		}

		public static bool ShouldUseConstructorParameters(ShouldUseConstructorParametersArgs args)
		{
			if (!args.ParameterType.HasParameterlessConstructor() && args.ParameterType.HasConstructor() && !args.ParameterType.IsUserDefinedStruct() && !args.ParameterType.IsInterface)
			{
				return Type.GetTypeCode(args.ParameterType) == TypeCode.Object;
			}
			return false;
		}

		public static ConstructorInfo GetConstructor(GetConstructorArgs args)
		{
			return args.ClassType.GetConstructorWithMostParameters();
		}

		public static string GetDynamicPropertyName(GetDynamicPropertyNameArgs args)
		{
			if (args.Context.Reader.HeaderRecord == null)
			{
				return $"Field{args.FieldIndex + 1}";
			}
			string header = args.Context.Reader.HeaderRecord[args.FieldIndex];
			PrepareHeaderForMatchArgs args2 = new PrepareHeaderForMatchArgs(header, args.FieldIndex);
			return args.Context.Reader.Configuration.PrepareHeaderForMatch(args2);
		}
	}
}
