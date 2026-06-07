using System;
using System.IO;
using Newtonsoft.Json;

namespace Coherence.Log.Targets
{
	public static class JsonLogFormatter
	{
		private const string TIME_KEY = "time";

		private const string LEVEL_KEY = "level";

		private const string MESSAGE_KEY = "message";

		private const string LOGGER_KEY = "logger";

		private const string RFC3339_FORMAT = "yyyy-MM-dd'T'HH:mm:ss.fffK";

		[ThreadStatic]
		private static JsonSerializer serializer;

		[ThreadStatic]
		private static StringWriter stringWriter;

		[ThreadStatic]
		private static JsonTextWriter writer;

		public static string Format(LogLevel level, string message, (string key, object value)[] args, Type source)
		{
			return null;
		}
	}
}
