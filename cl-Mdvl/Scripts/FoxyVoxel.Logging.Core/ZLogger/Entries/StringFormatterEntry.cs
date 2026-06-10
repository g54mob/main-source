using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace ZLogger.Entries
{
	public class StringFormatterEntry<TState> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<StringFormatterEntry<TState>> cache = new ConcurrentQueue<StringFormatterEntry<TState>>();

		private static readonly byte[] newLineBytes = Encoding.UTF8.GetBytes(Environment.NewLine);

		private TState state;

		private Exception? exception;

		private Func<TState, Exception?, string> formatter;

		public LogInfo LogInfo { get; private set; }

		public static StringFormatterEntry<TState> Create(LogInfo info, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
		{
			if (!cache.TryDequeue(out StringFormatterEntry<TState> result))
			{
				result = new StringFormatterEntry<TState>();
			}
			result.LogInfo = info;
			result.state = state;
			result.exception = exception;
			result.formatter = formatter;
			return result;
		}

		public void FormatUtf8(IBufferWriter<byte> writer, ZLoggerOptions options, Utf8JsonWriter? jsonWriter)
		{
			string text = formatter(state, exception);
			if (options.EnableStructuredLogging && jsonWriter != null)
			{
				options.StructuredLoggingFormatter(jsonWriter, LogInfo);
				jsonWriter.WriteString(options.MessagePropertyName, text);
				jsonWriter.WriteNull(options.PayloadPropertyName);
				return;
			}
			options.PrefixFormatter?.Invoke(writer, LogInfo);
			if (text != null && MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)writer.GetMemory(Encoding.UTF8.GetMaxByteCount(text.Length)), out ArraySegment<byte> segment) && segment.Array != null)
			{
				int bytes = Encoding.UTF8.GetBytes(text, 0, text.Length, segment.Array, segment.Offset);
				writer.Advance(bytes);
			}
			options.SuffixFormatter?.Invoke(writer, LogInfo);
			if (LogInfo.Exception != null)
			{
				options.ExceptionFormatter(writer, LogInfo.Exception);
			}
		}

		public object? GetPayload()
		{
			return null;
		}

		public void SwitchCasePayload<TPayload>(Action<IZLoggerEntry, TPayload, object?> payloadCallback, object? state)
		{
		}

		public void Return()
		{
			state = default(TState);
			LogInfo = default(LogInfo);
			exception = null;
			formatter = null;
		}
	}
}
