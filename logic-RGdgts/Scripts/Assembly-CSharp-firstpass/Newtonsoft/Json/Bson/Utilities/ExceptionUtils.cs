using System;

namespace Newtonsoft.Json.Bson.Utilities
{
	internal static class ExceptionUtils
	{
		internal static JsonReaderException CreateJsonReaderException(JsonReader reader, string message)
		{
			return null;
		}

		internal static JsonReaderException CreateJsonReaderException(JsonReader reader, string message, Exception ex)
		{
			return null;
		}

		internal static JsonReaderException CreateJsonReaderException(IJsonLineInfo lineInfo, string path, string message, Exception ex)
		{
			return null;
		}

		internal static JsonWriterException CreateJsonWriterException(JsonWriter writer, string message, Exception ex)
		{
			return null;
		}

		internal static JsonWriterException CreateJsonWriterException(string path, string message, Exception ex)
		{
			return null;
		}

		internal static JsonSerializationException CreateJsonSerializationException(IJsonLineInfo lineInfo, string path, string message, Exception ex)
		{
			return null;
		}

		private static string FormatMessage(IJsonLineInfo lineInfo, string path, string message)
		{
			return null;
		}
	}
}
