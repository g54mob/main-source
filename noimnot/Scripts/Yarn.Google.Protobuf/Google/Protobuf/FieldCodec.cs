using System;
using System.Collections.Generic;

namespace Google.Protobuf
{
	public static class FieldCodec
	{
		private static class WrapperCodecs
		{
			private static readonly Dictionary<Type, object> Codecs;

			private static readonly Dictionary<Type, object> Readers;

			internal static FieldCodec<T> GetCodec<T>()
			{
				return null;
			}

			internal static ValueReader<T?> GetReader<T>() where T : struct
			{
				return null;
			}

			internal static T Read<T>(ref ParseContext ctx, FieldCodec<T> codec)
			{
				return default(T);
			}

			internal static void Write<T>(ref WriteContext ctx, T value, FieldCodec<T> codec)
			{
			}

			internal static int CalculateSize<T>(T value, FieldCodec<T> codec)
			{
				return 0;
			}
		}

		public static FieldCodec<string> ForString(uint tag)
		{
			return null;
		}

		public static FieldCodec<ByteString> ForBytes(uint tag)
		{
			return null;
		}

		public static FieldCodec<bool> ForBool(uint tag)
		{
			return null;
		}

		public static FieldCodec<int> ForInt32(uint tag)
		{
			return null;
		}

		public static FieldCodec<int> ForSInt32(uint tag)
		{
			return null;
		}

		public static FieldCodec<uint> ForFixed32(uint tag)
		{
			return null;
		}

		public static FieldCodec<int> ForSFixed32(uint tag)
		{
			return null;
		}

		public static FieldCodec<uint> ForUInt32(uint tag)
		{
			return null;
		}

		public static FieldCodec<long> ForInt64(uint tag)
		{
			return null;
		}

		public static FieldCodec<long> ForSInt64(uint tag)
		{
			return null;
		}

		public static FieldCodec<ulong> ForFixed64(uint tag)
		{
			return null;
		}

		public static FieldCodec<long> ForSFixed64(uint tag)
		{
			return null;
		}

		public static FieldCodec<ulong> ForUInt64(uint tag)
		{
			return null;
		}

		public static FieldCodec<float> ForFloat(uint tag)
		{
			return null;
		}

		public static FieldCodec<double> ForDouble(uint tag)
		{
			return null;
		}

		public static FieldCodec<T> ForEnum<T>(uint tag, Func<T, int> toInt32, Func<int, T> fromInt32)
		{
			return null;
		}

		public static FieldCodec<string> ForString(uint tag, string defaultValue)
		{
			return null;
		}

		public static FieldCodec<ByteString> ForBytes(uint tag, ByteString defaultValue)
		{
			return null;
		}

		public static FieldCodec<bool> ForBool(uint tag, bool defaultValue)
		{
			return null;
		}

		public static FieldCodec<int> ForInt32(uint tag, int defaultValue)
		{
			return null;
		}

		public static FieldCodec<int> ForSInt32(uint tag, int defaultValue)
		{
			return null;
		}

		public static FieldCodec<uint> ForFixed32(uint tag, uint defaultValue)
		{
			return null;
		}

		public static FieldCodec<int> ForSFixed32(uint tag, int defaultValue)
		{
			return null;
		}

		public static FieldCodec<uint> ForUInt32(uint tag, uint defaultValue)
		{
			return null;
		}

		public static FieldCodec<long> ForInt64(uint tag, long defaultValue)
		{
			return null;
		}

		public static FieldCodec<long> ForSInt64(uint tag, long defaultValue)
		{
			return null;
		}

		public static FieldCodec<ulong> ForFixed64(uint tag, ulong defaultValue)
		{
			return null;
		}

		public static FieldCodec<long> ForSFixed64(uint tag, long defaultValue)
		{
			return null;
		}

		public static FieldCodec<ulong> ForUInt64(uint tag, ulong defaultValue)
		{
			return null;
		}

		public static FieldCodec<float> ForFloat(uint tag, float defaultValue)
		{
			return null;
		}

		public static FieldCodec<double> ForDouble(uint tag, double defaultValue)
		{
			return null;
		}

		public static FieldCodec<T> ForEnum<T>(uint tag, Func<T, int> toInt32, Func<int, T> fromInt32, T defaultValue)
		{
			return null;
		}

		public static FieldCodec<T> ForMessage<T>(uint tag, MessageParser<T> parser) where T : class, IMessage<T>
		{
			return null;
		}

		public static FieldCodec<T> ForGroup<T>(uint startTag, uint endTag, MessageParser<T> parser) where T : class, IMessage<T>
		{
			return null;
		}

		public static FieldCodec<T> ForClassWrapper<T>(uint tag) where T : class
		{
			return null;
		}

		public static FieldCodec<T?> ForStructWrapper<T>(uint tag) where T : struct
		{
			return null;
		}
	}
	public sealed class FieldCodec<T>
	{
		internal delegate void InputMerger(ref ParseContext ctx, ref T value);

		internal delegate bool ValuesMerger(ref T value, T other);

		private static readonly EqualityComparer<T> EqualityComparer;

		private static readonly T DefaultDefault;

		private static readonly bool TypeSupportsPacking;

		private readonly int tagSize;

		internal bool PackedRepeatedField { get; }

		internal ValueWriter<T> ValueWriter { get; }

		internal Func<T, int> ValueSizeCalculator { get; }

		internal ValueReader<T> ValueReader { get; }

		internal InputMerger ValueMerger { get; }

		internal ValuesMerger FieldMerger { get; }

		internal int FixedSize { get; }

		internal uint Tag { get; }

		internal uint EndTag { get; }

		internal T DefaultValue { get; }

		static FieldCodec()
		{
		}

		internal static bool IsPackedRepeatedField(uint tag)
		{
			return false;
		}

		internal FieldCodec(ValueReader<T> reader, ValueWriter<T> writer, int fixedSize, uint tag, T defaultValue)
		{
		}

		internal FieldCodec(ValueReader<T> reader, ValueWriter<T> writer, Func<T, int> sizeCalculator, uint tag, T defaultValue)
		{
		}

		internal FieldCodec(ValueReader<T> reader, ValueWriter<T> writer, InputMerger inputMerger, ValuesMerger valuesMerger, Func<T, int> sizeCalculator, uint tag, uint endTag = 0u)
		{
		}

		internal FieldCodec(ValueReader<T> reader, ValueWriter<T> writer, InputMerger inputMerger, ValuesMerger valuesMerger, Func<T, int> sizeCalculator, uint tag, uint endTag, T defaultValue)
		{
		}

		public void WriteTagAndValue(CodedOutputStream output, T value)
		{
		}

		public void WriteTagAndValue(ref WriteContext ctx, T value)
		{
		}

		public T Read(CodedInputStream input)
		{
			return default(T);
		}

		public T Read(ref ParseContext ctx)
		{
			return default(T);
		}

		public int CalculateSizeWithTag(T value)
		{
			return 0;
		}

		internal int CalculateUnconditionalSizeWithTag(T value)
		{
			return 0;
		}

		private bool IsDefault(T value)
		{
			return false;
		}
	}
}
