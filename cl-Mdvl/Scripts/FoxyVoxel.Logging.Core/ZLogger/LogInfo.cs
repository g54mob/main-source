using System;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace ZLogger
{
	public readonly struct LogInfo
	{
		public readonly string CategoryName;

		public readonly DateTimeOffset Timestamp;

		public readonly LogLevel LogLevel;

		public readonly EventId EventId;

		public readonly Exception? Exception;

		private static readonly JsonEncodedText CategoryNameText = JsonEncodedText.Encode("CategoryName");

		private static readonly JsonEncodedText TimestampText = JsonEncodedText.Encode("Timestamp");

		private static readonly JsonEncodedText LogLevelText = JsonEncodedText.Encode("LogLevel");

		private static readonly JsonEncodedText EventIdText = JsonEncodedText.Encode("EventId");

		private static readonly JsonEncodedText EventIdNameText = JsonEncodedText.Encode("EventIdName");

		private static readonly JsonEncodedText ExceptionText = JsonEncodedText.Encode("Exception");

		private static readonly JsonEncodedText NameText = JsonEncodedText.Encode("Name");

		private static readonly JsonEncodedText MessageText = JsonEncodedText.Encode("Message");

		private static readonly JsonEncodedText StackTraceText = JsonEncodedText.Encode("StackTrace");

		private static readonly JsonEncodedText InnerExceptionText = JsonEncodedText.Encode("InnerException");

		private static readonly JsonEncodedText Trace = JsonEncodedText.Encode("Trace");

		private static readonly JsonEncodedText Debug = JsonEncodedText.Encode("Debug");

		private static readonly JsonEncodedText Information = JsonEncodedText.Encode("Information");

		private static readonly JsonEncodedText Warning = JsonEncodedText.Encode("Warning");

		private static readonly JsonEncodedText Error = JsonEncodedText.Encode("Error");

		private static readonly JsonEncodedText Critical = JsonEncodedText.Encode("Critical");

		private static readonly JsonEncodedText None = JsonEncodedText.Encode("None");

		public LogInfo(string categoryName, DateTimeOffset timestamp, LogLevel logLevel, EventId eventId, Exception? exception)
		{
			EventId = eventId;
			CategoryName = categoryName;
			Timestamp = timestamp;
			LogLevel = logLevel;
			Exception = exception;
		}

		public void WriteToJsonWriter(Utf8JsonWriter writer)
		{
			writer.WriteString(CategoryNameText, CategoryName);
			writer.WriteString(LogLevelText, LogLevelToEncodedText(LogLevel));
			writer.WriteNumber(EventIdText, EventId.Id);
			writer.WriteString(EventIdNameText, EventId.Name);
			writer.WriteString(TimestampText, Timestamp);
			writer.WritePropertyName(ExceptionText);
			WriteException(writer, Exception);
		}

		private static void WriteException(Utf8JsonWriter writer, Exception? ex)
		{
			if (ex == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();
			writer.WriteString(NameText, ex.GetType().FullName);
			writer.WriteString(MessageText, ex.Message);
			writer.WriteString(StackTraceText, ex.StackTrace);
			writer.WritePropertyName(InnerExceptionText);
			WriteException(writer, ex.InnerException);
			writer.WriteEndObject();
		}

		private static JsonEncodedText LogLevelToEncodedText(LogLevel logLevel)
		{
			switch (logLevel)
			{
			case LogLevel.Trace:
				return Trace;
			case LogLevel.Debug:
				return Debug;
			case LogLevel.Information:
				return Information;
			case LogLevel.Warning:
				return Warning;
			case LogLevel.Error:
				return Error;
			case LogLevel.Critical:
				return Critical;
			case LogLevel.None:
				return None;
			default:
			{
				int num = (int)logLevel;
				return JsonEncodedText.Encode(num.ToString());
			}
			}
		}
	}
}
