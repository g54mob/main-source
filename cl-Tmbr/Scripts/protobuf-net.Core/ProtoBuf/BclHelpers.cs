using System;
using System.Buffers;
using System.Buffers.Text;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using ProtoBuf.Internal;
using ProtoBuf.Serializers;
using ProtoBuf.WellKnownTypes;

namespace ProtoBuf
{
	public static class BclHelpers
	{
		internal static readonly DateTime[] EpochOrigin = new DateTime[3]
		{
			new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
			new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc),
			new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local)
		};

		private const int MAX_DECIMAL_BYTES = 32;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object GetUninitializedObject(Type type)
		{
			return FormatterServices.GetUninitializedObject(type);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteTimeSpan(TimeSpan timeSpan, ProtoWriter dest)
		{
			ProtoWriter.State state = dest.DefaultState();
			WriteTimeSpanImpl(ref state, timeSpan, DateTimeKind.Unspecified);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteTimeSpan(ref ProtoWriter.State state, TimeSpan value)
		{
			WriteTimeSpanImpl(ref state, value, DateTimeKind.Unspecified);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WriteTimeSpanImpl(ref ProtoWriter.State state, TimeSpan timeSpan, DateTimeKind kind)
		{
			switch (state.WireType)
			{
			case WireType.String:
			case WireType.StartGroup:
			{
				PrimaryTypeProvider.ScaledTicks value = new PrimaryTypeProvider.ScaledTicks(timeSpan, kind);
				state.WriteMessage(SerializerFeatures.OptionSkipRecursionCheck, value, SerializerCache<PrimaryTypeProvider>.InstanceField);
				break;
			}
			case WireType.Fixed64:
				state.WriteInt64(timeSpan.Ticks);
				break;
			default:
				ThrowHelper.ThrowProtoException("Unexpected wire-type: " + state.WireType);
				break;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TimeSpan ReadTimeSpan(ProtoReader source)
		{
			ProtoReader.State state = source.DefaultState();
			return ReadTimeSpan(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TimeSpan ReadTimeSpan(ref ProtoReader.State state)
		{
			switch (state.WireType)
			{
			case WireType.String:
			case WireType.StartGroup:
				return state.ReadMessage(SerializerFeatures.CategoryRepeated, default(PrimaryTypeProvider.ScaledTicks), SerializerCache<PrimaryTypeProvider>.InstanceField).ToTimeSpan();
			case WireType.Fixed64:
			{
				long num = state.ReadInt64();
				return num switch
				{
					long.MinValue => TimeSpan.MinValue, 
					long.MaxValue => TimeSpan.MaxValue, 
					_ => TimeSpan.FromTicks(num), 
				};
			}
			default:
				ThrowHelper.ThrowProtoException($"Unexpected wire-type: {state.WireType}");
				return default(TimeSpan);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TimeSpan ReadDuration(ProtoReader source)
		{
			ProtoReader.State state = source.DefaultState();
			return ReadDuration(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TimeSpan ReadDuration(ref ProtoReader.State state)
		{
			return state.ReadMessage(SerializerFeatures.CategoryRepeated, default(Duration), SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDuration(TimeSpan value, ProtoWriter dest)
		{
			ProtoWriter.State state = dest.DefaultState();
			WriteDuration(ref state, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDuration(ref ProtoWriter.State state, TimeSpan value)
		{
			state.WriteMessage(SerializerFeatures.OptionSkipRecursionCheck, (Duration)value, (ISerializer<Duration>)SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime ReadTimestamp(ProtoReader source)
		{
			ProtoReader.State state = source.DefaultState();
			return ReadTimestamp(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime ReadTimestamp(ref ProtoReader.State state)
		{
			return state.ReadMessage(SerializerFeatures.CategoryRepeated, default(Timestamp), SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteTimestamp(DateTime value, ProtoWriter dest)
		{
			ProtoWriter.State state = dest.DefaultState();
			WriteTimestamp(ref state, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteTimestamp(ref ProtoWriter.State state, DateTime value)
		{
			state.WriteMessage(SerializerFeatures.OptionSkipRecursionCheck, (Timestamp)value, (ISerializer<Timestamp>)SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime ReadDateTime(ProtoReader source)
		{
			ProtoReader.State state = source.DefaultState();
			return ReadDateTime(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static DateTime ReadDateTime(ref ProtoReader.State state)
		{
			switch (state.WireType)
			{
			case WireType.String:
			case WireType.StartGroup:
				return state.ReadMessage(SerializerFeatures.CategoryRepeated, default(PrimaryTypeProvider.ScaledTicks), SerializerCache<PrimaryTypeProvider>.InstanceField).ToDateTime();
			case WireType.Fixed64:
			{
				long num = state.ReadInt64();
				return num switch
				{
					long.MinValue => DateTime.MinValue, 
					long.MaxValue => DateTime.MaxValue, 
					_ => EpochOrigin[0].AddTicks(num), 
				};
			}
			default:
				ThrowHelper.ThrowProtoException($"Unexpected wire-type: {state.WireType}");
				return default(DateTime);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDateTime(DateTime value, ProtoWriter dest)
		{
			ProtoWriter.State state = dest.DefaultState();
			WriteDateTimeImpl(ref state, value, includeKind: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDateTime(ref ProtoWriter.State state, DateTime value)
		{
			WriteDateTimeImpl(ref state, value, includeKind: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDateTimeWithKind(DateTime value, ProtoWriter dest)
		{
			ProtoWriter.State state = dest.DefaultState();
			WriteDateTimeImpl(ref state, value, includeKind: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDateTimeWithKind(ref ProtoWriter.State state, DateTime value)
		{
			WriteDateTimeImpl(ref state, value, includeKind: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void WriteDateTimeImpl(ref ProtoWriter.State state, DateTime value, bool includeKind)
		{
			WireType wireType = state.WireType;
			TimeSpan timeSpan;
			if ((uint)(wireType - 2) <= 1u)
			{
				if (value == DateTime.MaxValue)
				{
					timeSpan = TimeSpan.MaxValue;
					includeKind = false;
				}
				else if (value == DateTime.MinValue)
				{
					timeSpan = TimeSpan.MinValue;
					includeKind = false;
				}
				else
				{
					timeSpan = value - EpochOrigin[0];
				}
			}
			else
			{
				timeSpan = value - EpochOrigin[0];
			}
			WriteTimeSpanImpl(ref state, timeSpan, includeKind ? value.Kind : DateTimeKind.Unspecified);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static decimal ReadDecimal(ProtoReader reader)
		{
			ProtoReader.State state = reader.DefaultState();
			return ReadDecimal(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static decimal ReadDecimal(ref ProtoReader.State state)
		{
			return state.ReadMessage(SerializerFeatures.CategoryRepeated, 0m, SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe static decimal ReadDecimalString(ref ProtoReader.State state)
		{
			byte* ptr = stackalloc byte[32];
			Span<byte> span = state.ReadBytes(new Span<byte>(ptr, 32));
			if (!Utf8Parser.TryParse((ReadOnlySpan<byte>)span, out decimal value, out int bytesConsumed, '\0') || bytesConsumed != span.Length)
			{
				ThrowHelper.ThrowInvalidOperationException("Unable to parse decimal: '" + Encoding.UTF8.GetString(ptr, span.Length) + "'");
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDecimal(decimal value, ProtoWriter writer)
		{
			ProtoWriter.State state = writer.DefaultState();
			WriteDecimal(ref state, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDecimal(ref ProtoWriter.State state, decimal value)
		{
			state.WriteMessage(SerializerFeatures.OptionSkipRecursionCheck, value, SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDecimalString(ref ProtoWriter.State state, decimal value)
		{
			byte[] array = ArrayPool<byte>.Shared.Rent(32);
			try
			{
				if (!Utf8Formatter.TryFormat(value, array, out var bytesWritten))
				{
					ThrowHelper.ThrowInvalidOperationException($"Unable to format decimal: '{value}'");
				}
				state.WriteBytes(new ReadOnlyMemory<byte>(array, 0, bytesWritten));
			}
			finally
			{
				ArrayPool<byte>.Shared.Return(array);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteGuid(Guid value, ProtoWriter dest)
		{
			ProtoWriter.State state = dest.DefaultState();
			WriteGuid(ref state, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteGuid(ref ProtoWriter.State state, Guid value)
		{
			state.WriteMessage(SerializerFeatures.OptionSkipRecursionCheck, value, SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteGuidBytes(ref ProtoWriter.State state, Guid value)
		{
			GuidHelper.Write(ref state, in value, asBytes: true);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteGuidString(ref ProtoWriter.State state, Guid value)
		{
			GuidHelper.Write(ref state, in value, asBytes: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid ReadGuid(ProtoReader source)
		{
			ProtoReader.State state = source.DefaultState();
			return ReadGuid(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid ReadGuid(ref ProtoReader.State state)
		{
			return state.ReadMessage(SerializerFeatures.CategoryRepeated, default(Guid), SerializerCache<PrimaryTypeProvider>.InstanceField);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid ReadGuidBytes(ref ProtoReader.State state)
		{
			return GuidHelper.Read(ref state);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Guid ReadGuidString(ref ProtoReader.State state)
		{
			return GuidHelper.Read(ref state);
		}
	}
}
