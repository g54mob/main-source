using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Cysharp.Text;

namespace ZLogger.Entries
{
	public class MessageLogEntry<TPayload> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<MessageLogEntry<TPayload>> cache = new ConcurrentQueue<MessageLogEntry<TPayload>>();

		private MessageLogState<TPayload> state;

		public LogInfo LogInfo { get; private set; }

		private MessageLogEntry()
		{
		}

		public static MessageLogEntry<TPayload> Create(in LogInfo logInfo, in MessageLogState<TPayload> state)
		{
			if (!cache.TryDequeue(out MessageLogEntry<TPayload> result))
			{
				result = new MessageLogEntry<TPayload>();
			}
			result.LogInfo = logInfo;
			result.state = state;
			return result;
		}

		public void FormatUtf8(IBufferWriter<byte> writer, ZLoggerOptions options, Utf8JsonWriter? jsonWriter)
		{
			if (options.EnableStructuredLogging && jsonWriter != null)
			{
				options.StructuredLoggingFormatter(jsonWriter, LogInfo);
				using (Utf8ValueStringBuilder utf8ValueStringBuilder = ZString.CreateUtf8StringBuilder(notNested: true))
				{
					utf8ValueStringBuilder.Append(state.Message);
					jsonWriter.WriteString(options.MessagePropertyName, utf8ValueStringBuilder.AsSpan());
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
				return;
			}
			options.PrefixFormatter?.Invoke(writer, LogInfo);
			string message = state.Message;
			if (message != null && MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)writer.GetMemory(Encoding.UTF8.GetMaxByteCount(message.Length)), out ArraySegment<byte> segment) && segment.Array != null)
			{
				int bytes = Encoding.UTF8.GetBytes(message, 0, message.Length, segment.Array, segment.Offset);
				writer.Advance(bytes);
			}
			options.SuffixFormatter?.Invoke(writer, LogInfo);
			if (LogInfo.Exception != null)
			{
				options.ExceptionFormatter(writer, LogInfo.Exception);
			}
		}

		public void Return()
		{
			state = default(MessageLogState<TPayload>);
			LogInfo = default(LogInfo);
			cache.Enqueue(this);
		}

		public void SwitchCasePayload<TPayload1>(Action<IZLoggerEntry, TPayload1, object?> payloadCallback, object? state)
		{
			if (typeof(TPayload1) == typeof(TPayload))
			{
				payloadCallback(this, Unsafe.As<TPayload, TPayload1>(ref Unsafe.AsRef(in this.state.Payload)), state);
			}
		}

		public object? GetPayload()
		{
			return state.Payload;
		}
	}
}
