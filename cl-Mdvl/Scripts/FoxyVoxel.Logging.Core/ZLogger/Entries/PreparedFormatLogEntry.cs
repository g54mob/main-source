using System;
using System.Buffers;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Cysharp.Text;

namespace ZLogger.Entries
{
	public class PreparedFormatLogEntry<TPayload, T1> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1>>();

		private PreparedFormatLogState<TPayload, T1> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2>>();

		private PreparedFormatLogState<TPayload, T1, T2> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>);
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
	public class PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> : IZLoggerEntry
	{
		private static readonly ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>> cache = new ConcurrentQueue<PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>>();

		private PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> state;

		public LogInfo LogInfo { get; private set; }

		private PreparedFormatLogEntry()
		{
		}

		public static PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> Create(in LogInfo logInfo, in PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> state)
		{
			if (!cache.TryDequeue(out PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> result))
			{
				result = new PreparedFormatLogEntry<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>();
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
				Utf8ValueStringBuilder sb = ZString.CreateUtf8StringBuilder(notNested: true);
				try
				{
					state.Format.FormatTo(ref sb, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13, state.Arg14);
					jsonWriter.WriteString(options.MessagePropertyName, sb.AsSpan());
				}
				finally
				{
					sb.Dispose();
				}
				jsonWriter.WritePropertyName(options.PayloadPropertyName);
				JsonSerializer.Serialize(jsonWriter, state.Payload, options.JsonSerializerOptions);
			}
			else
			{
				options.PrefixFormatter?.Invoke(writer, LogInfo);
				state.Format.FormatTo(ref writer, state.Arg1, state.Arg2, state.Arg3, state.Arg4, state.Arg5, state.Arg6, state.Arg7, state.Arg8, state.Arg9, state.Arg10, state.Arg11, state.Arg12, state.Arg13, state.Arg14);
				options.SuffixFormatter?.Invoke(writer, LogInfo);
				if (LogInfo.Exception != null)
				{
					options.ExceptionFormatter(writer, LogInfo.Exception);
				}
			}
		}

		public void Return()
		{
			state = default(PreparedFormatLogState<TPayload, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>);
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
