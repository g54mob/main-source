using System;
using System.Buffers;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace ZLogger
{
	public class ZLoggerOptions
	{
		[ThreadStatic]
		private static Utf8JsonWriter? jsonWriter;

		private static byte[] newLine = Encoding.UTF8.GetBytes(Environment.NewLine);

		public Action<LogInfo, Exception>? InternalErrorLogger { get; set; }

		public TimeSpan? FlushRate { get; set; }

		public Action<IBufferWriter<byte>, LogInfo>? PrefixFormatter { get; set; }

		public Action<IBufferWriter<byte>, LogInfo>? SuffixFormatter { get; set; }

		public Action<IBufferWriter<byte>, Exception> ExceptionFormatter { get; set; } = DefaultExceptionLoggingFormatter;

		public bool EnableStructuredLogging { get; set; }

		public Action<Utf8JsonWriter, LogInfo> StructuredLoggingFormatter { get; set; } = DefaultStructuredLoggingFormatter;

		public JsonEncodedText MessagePropertyName { get; set; } = JsonEncodedText.Encode("Message");

		public JsonEncodedText PayloadPropertyName { get; set; } = JsonEncodedText.Encode("Payload");

		public JsonSerializerOptions JsonSerializerOptions { get; set; } = new JsonSerializerOptions
		{
			WriteIndented = false,
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
		};

		internal Utf8JsonWriter GetThreadStaticUtf8JsonWriter(IBufferWriter<byte> buffer)
		{
			Utf8JsonWriter utf8JsonWriter;
			if (jsonWriter == null)
			{
				utf8JsonWriter = (jsonWriter = new Utf8JsonWriter(buffer, new JsonWriterOptions
				{
					Indented = JsonSerializerOptions.WriteIndented,
					SkipValidation = true,
					Encoder = JsonSerializerOptions.Encoder
				}));
			}
			else
			{
				utf8JsonWriter = jsonWriter;
				utf8JsonWriter.Reset(buffer);
			}
			return utf8JsonWriter;
		}

		private static void DefaultStructuredLoggingFormatter(Utf8JsonWriter writer, LogInfo info)
		{
			info.WriteToJsonWriter(writer);
		}

		private static void DefaultExceptionLoggingFormatter(IBufferWriter<byte> writer, Exception exception)
		{
			Write(writer, Environment.NewLine);
			WriteExceptionLoggingCore(writer, exception);
		}

		private static void WriteExceptionLoggingCore(IBufferWriter<byte> writer, Exception exception)
		{
			string fullName = exception.GetType().FullName;
			string message = exception.Message;
			Exception innerException = exception.InnerException;
			string stackTrace = exception.StackTrace;
			Write(writer, fullName, ": ", message ?? "");
			if (innerException != null)
			{
				Write(writer, Environment.NewLine, " ---> ");
				WriteExceptionLoggingCore(writer, innerException);
				Write(writer, Environment.NewLine, "   --- End of inner exception stack trace ---");
			}
			if (stackTrace != null)
			{
				Write(writer, Environment.NewLine, stackTrace);
			}
		}

		private static void Write(IBufferWriter<byte> writer, string message)
		{
			if (MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)writer.GetMemory(Encoding.UTF8.GetMaxByteCount(message.Length)), out ArraySegment<byte> segment) && segment.Array != null)
			{
				int bytes = Encoding.UTF8.GetBytes(message, 0, message.Length, segment.Array, segment.Offset);
				writer.Advance(bytes);
			}
		}

		private static void Write(IBufferWriter<byte> writer, string message1, string message2)
		{
			if (MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)writer.GetMemory(Encoding.UTF8.GetMaxByteCount(message1.Length + message2.Length)), out ArraySegment<byte> segment) && segment.Array != null)
			{
				int bytes = Encoding.UTF8.GetBytes(message1, 0, message1.Length, segment.Array, segment.Offset);
				int bytes2 = Encoding.UTF8.GetBytes(message2, 0, message2.Length, segment.Array, segment.Offset + bytes);
				writer.Advance(bytes + bytes2);
			}
		}

		private static void Write(IBufferWriter<byte> writer, string message1, string message2, string message3)
		{
			if (MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)writer.GetMemory(Encoding.UTF8.GetMaxByteCount(message1.Length + message2.Length + message3.Length)), out ArraySegment<byte> segment) && segment.Array != null)
			{
				int bytes = Encoding.UTF8.GetBytes(message1, 0, message1.Length, segment.Array, segment.Offset);
				int bytes2 = Encoding.UTF8.GetBytes(message2, 0, message2.Length, segment.Array, segment.Offset + bytes);
				int bytes3 = Encoding.UTF8.GetBytes(message3, 0, message3.Length, segment.Array, segment.Offset + bytes + bytes2);
				writer.Advance(bytes + bytes2 + bytes3);
			}
		}
	}
}
