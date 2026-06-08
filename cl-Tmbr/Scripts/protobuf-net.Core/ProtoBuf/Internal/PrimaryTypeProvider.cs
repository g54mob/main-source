using System;
using System.Runtime.InteropServices;
using System.Text;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;
using ProtoBuf.WellKnownTypes;

namespace ProtoBuf.Internal
{
	internal class PrimaryTypeProvider : ISerializer<decimal>, ISerializer<decimal?>, ISerializer<Guid>, ISerializer<Guid?>, IMeasuringSerializer<string>, ISerializer<string>, IMeasuringSerializer<int>, ISerializer<int>, IMeasuringSerializer<long>, ISerializer<long>, IMeasuringSerializer<bool>, ISerializer<bool>, IMeasuringSerializer<float>, ISerializer<float>, IMeasuringSerializer<double>, ISerializer<double>, IMeasuringSerializer<byte[]>, ISerializer<byte[]>, IMeasuringSerializer<ArraySegment<byte>>, ISerializer<ArraySegment<byte>>, IMeasuringSerializer<Memory<byte>>, ISerializer<Memory<byte>>, IMeasuringSerializer<ReadOnlyMemory<byte>>, ISerializer<ReadOnlyMemory<byte>>, IMeasuringSerializer<byte>, ISerializer<byte>, IMeasuringSerializer<ushort>, ISerializer<ushort>, IMeasuringSerializer<uint>, ISerializer<uint>, IMeasuringSerializer<ulong>, ISerializer<ulong>, IMeasuringSerializer<sbyte>, ISerializer<sbyte>, IMeasuringSerializer<short>, ISerializer<short>, IMeasuringSerializer<char>, ISerializer<char>, IMeasuringSerializer<Uri>, ISerializer<Uri>, IMeasuringSerializer<Type>, ISerializer<Type>, IMeasuringSerializer<IntPtr>, ISerializer<IntPtr>, IMeasuringSerializer<UIntPtr>, ISerializer<UIntPtr>, IFactory<string>, IFactory<byte[]>, IMeasuringSerializer<int?>, ISerializer<int?>, IMeasuringSerializer<long?>, ISerializer<long?>, IMeasuringSerializer<bool?>, ISerializer<bool?>, IMeasuringSerializer<float?>, ISerializer<float?>, IMeasuringSerializer<double?>, ISerializer<double?>, IMeasuringSerializer<byte?>, ISerializer<byte?>, IMeasuringSerializer<ushort?>, ISerializer<ushort?>, IMeasuringSerializer<uint?>, ISerializer<uint?>, IMeasuringSerializer<ulong?>, ISerializer<ulong?>, IMeasuringSerializer<sbyte?>, ISerializer<sbyte?>, IMeasuringSerializer<short?>, ISerializer<short?>, IMeasuringSerializer<char?>, ISerializer<char?>, IMeasuringSerializer<IntPtr?>, ISerializer<IntPtr?>, IMeasuringSerializer<UIntPtr?>, ISerializer<UIntPtr?>, IValueChecker<string>, IValueChecker<int>, IValueChecker<long>, IValueChecker<bool>, IValueChecker<float>, IValueChecker<double>, IValueChecker<byte[]>, IValueChecker<byte>, IValueChecker<ushort>, IValueChecker<uint>, IValueChecker<ulong>, IValueChecker<sbyte>, IValueChecker<short>, IValueChecker<char>, IValueChecker<IntPtr>, IValueChecker<UIntPtr>, IValueChecker<Uri>, IValueChecker<Type>, IValueChecker<int?>, IValueChecker<long?>, IValueChecker<bool?>, IValueChecker<float?>, IValueChecker<double?>, IValueChecker<byte?>, IValueChecker<ushort?>, IValueChecker<uint?>, IValueChecker<ulong?>, IValueChecker<sbyte?>, IValueChecker<short?>, IValueChecker<char?>, IValueChecker<IntPtr?>, IValueChecker<UIntPtr?>, ISerializer<PrimaryTypeProvider.ScaledTicks>, ISerializer<TimeSpan>, ISerializer<TimeSpan?>, ISerializer<DateTime>, ISerializer<DateTime?>, ISerializer<Duration>, ISerializer<Duration?>, ISerializer<Empty>, ISerializer<Empty?>, ISerializer<Timestamp>, ISerializer<Timestamp?>
	{
		[StructLayout(LayoutKind.Explicit)]
		private readonly struct DecimalAccessor
		{
			[FieldOffset(0)]
			public readonly int Flags;

			[FieldOffset(4)]
			public readonly int Hi;

			[FieldOffset(8)]
			public readonly int Lo;

			[FieldOffset(12)]
			public readonly int Mid;

			[FieldOffset(0)]
			public readonly decimal Decimal;

			public DecimalAccessor(decimal value)
			{
				this = default(DecimalAccessor);
				Decimal = value;
			}
		}

		[StructLayout(LayoutKind.Explicit)]
		private readonly struct GuidAccessor
		{
			[FieldOffset(0)]
			public readonly Guid Guid;

			[FieldOffset(0)]
			public readonly ulong Low;

			[FieldOffset(8)]
			public readonly ulong High;

			public GuidAccessor(Guid value)
			{
				Low = (High = 0uL);
				Guid = value;
			}

			public GuidAccessor(ulong low, ulong high)
			{
				Guid = default(Guid);
				Low = low;
				High = high;
			}
		}

		[StructLayout(LayoutKind.Auto)]
		[ProtoContract(Name = ".bcl.TimeSpan")]
		internal readonly struct ScaledTicks
		{
			internal const int FieldTimeSpanValue = 1;

			internal const int FieldTimeSpanScale = 2;

			internal const int FieldTimeSpanKind = 3;

			[ProtoMember(1, DataFormat = DataFormat.ZigZag, Name = "value")]
			public long Value { get; }

			[ProtoMember(2, Name = "scale")]
			public TimeSpanScale Scale { get; }

			[ProtoMember(3, Name = "kind")]
			public DateTimeKind Kind { get; }

			public ScaledTicks(long value, TimeSpanScale scale, DateTimeKind kind)
			{
				Value = value;
				Scale = scale;
				Kind = kind;
			}

			public static ScaledTicks Create(DateTime value, bool includeKind)
			{
				if (value == DateTime.MinValue)
				{
					return new ScaledTicks(-1L, TimeSpanScale.MinMax, DateTimeKind.Unspecified);
				}
				if (value == DateTime.MaxValue)
				{
					return new ScaledTicks(1L, TimeSpanScale.MinMax, DateTimeKind.Unspecified);
				}
				DateTimeKind dateTimeKind = (includeKind ? value.Kind : DateTimeKind.Unspecified);
				return new ScaledTicks(value - BclHelpers.EpochOrigin[(int)dateTimeKind], dateTimeKind);
			}

			public DateTime ToDateTime()
			{
				long value;
				switch (Scale)
				{
				case TimeSpanScale.Days:
					value = Value * 864000000000L;
					break;
				case TimeSpanScale.Hours:
					value = Value * 36000000000L;
					break;
				case TimeSpanScale.Minutes:
					value = Value * 600000000;
					break;
				case TimeSpanScale.Seconds:
					value = Value * 10000000;
					break;
				case TimeSpanScale.Milliseconds:
					value = Value * 10000;
					break;
				case TimeSpanScale.Ticks:
					value = Value;
					break;
				case TimeSpanScale.MinMax:
					switch (Value)
					{
					case 1L:
						return DateTime.MaxValue;
					case -1L:
						return DateTime.MinValue;
					default:
						ThrowHelper.ThrowProtoException("Unknown min/max value: " + Value);
						return default(DateTime);
					}
				default:
					ThrowHelper.ThrowProtoException("Unknown timescale: " + Scale);
					return default(DateTime);
				}
				return BclHelpers.EpochOrigin[(int)Kind].AddTicks(value);
			}

			internal ScaledTicks(TimeSpan timeSpan, DateTimeKind kind)
			{
				long num = timeSpan.Ticks;
				TimeSpanScale timeSpanScale;
				if (timeSpan == TimeSpan.MaxValue)
				{
					num = 1L;
					timeSpanScale = TimeSpanScale.MinMax;
				}
				else if (timeSpan == TimeSpan.MinValue)
				{
					num = -1L;
					timeSpanScale = TimeSpanScale.MinMax;
				}
				else if (num % 864000000000L == 0L)
				{
					timeSpanScale = TimeSpanScale.Days;
					num /= 864000000000L;
				}
				else if (num % 36000000000L == 0L)
				{
					timeSpanScale = TimeSpanScale.Hours;
					num /= 36000000000L;
				}
				else if (num % 600000000 == 0L)
				{
					timeSpanScale = TimeSpanScale.Minutes;
					num /= 600000000;
				}
				else if (num % 10000000 == 0L)
				{
					timeSpanScale = TimeSpanScale.Seconds;
					num /= 10000000;
				}
				else if (num % 10000 == 0L)
				{
					timeSpanScale = TimeSpanScale.Milliseconds;
					num /= 10000;
				}
				else
				{
					timeSpanScale = TimeSpanScale.Ticks;
				}
				Kind = kind;
				Value = num;
				Scale = timeSpanScale;
			}

			public TimeSpan ToTimeSpan()
			{
				switch (Scale)
				{
				case TimeSpanScale.Days:
					return TimeSpan.FromDays(Value);
				case TimeSpanScale.Hours:
					return TimeSpan.FromHours(Value);
				case TimeSpanScale.Minutes:
					return TimeSpan.FromMinutes(Value);
				case TimeSpanScale.Seconds:
					return TimeSpan.FromSeconds(Value);
				case TimeSpanScale.Milliseconds:
					return TimeSpan.FromMilliseconds(Value);
				case TimeSpanScale.Ticks:
					return TimeSpan.FromTicks(Value);
				case TimeSpanScale.MinMax:
					switch (Value)
					{
					case 1L:
						return TimeSpan.MaxValue;
					case -1L:
						return TimeSpan.MinValue;
					default:
						ThrowHelper.ThrowProtoException("Unknown min/max value: " + Value);
						return default(TimeSpan);
					}
				default:
					ThrowHelper.ThrowProtoException("Unknown timescale: " + Scale);
					return default(TimeSpan);
				}
			}
		}

		private const int FieldDecimalLow = 1;

		private const int FieldDecimalHigh = 2;

		private const int FieldDecimalSignScale = 3;

		private static readonly bool s_decimalOptimized = VerifyDecimalLayout();

		private static readonly bool s_guidOptimized = VerifyGuidLayout();

		private const int FieldGuidLow = 1;

		private const int FieldGuidHigh = 2;

		SerializerFeatures ISerializer<decimal>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		SerializerFeatures ISerializer<decimal?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		internal static bool DecimalOptimized => s_decimalOptimized;

		SerializerFeatures ISerializer<Guid>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		SerializerFeatures ISerializer<Guid?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		internal static bool GuidOptimized => s_guidOptimized;

		SerializerFeatures ISerializer<string>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<int>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<byte[]>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<ArraySegment<byte>>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<Memory<byte>>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<ReadOnlyMemory<byte>>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<byte>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<ushort>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<uint>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<ulong>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<long>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<bool>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<float>.Features => SerializerFeatures.WireTypeFixed32 | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<double>.Features => SerializerFeatures.WireTypeFixed64 | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<sbyte>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<short>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<Uri>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<char>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<int?>.Features => ((ISerializer<int>)this).Features;

		SerializerFeatures ISerializer<short?>.Features => ((ISerializer<short>)this).Features;

		SerializerFeatures ISerializer<long?>.Features => ((ISerializer<long>)this).Features;

		SerializerFeatures ISerializer<sbyte?>.Features => ((ISerializer<sbyte>)this).Features;

		SerializerFeatures ISerializer<uint?>.Features => ((ISerializer<uint>)this).Features;

		SerializerFeatures ISerializer<ushort?>.Features => ((ISerializer<ushort>)this).Features;

		SerializerFeatures ISerializer<ulong?>.Features => ((ISerializer<ulong>)this).Features;

		SerializerFeatures ISerializer<byte?>.Features => ((ISerializer<byte>)this).Features;

		SerializerFeatures ISerializer<char?>.Features => ((ISerializer<char>)this).Features;

		SerializerFeatures ISerializer<bool?>.Features => ((ISerializer<bool>)this).Features;

		SerializerFeatures ISerializer<float?>.Features => ((ISerializer<float>)this).Features;

		SerializerFeatures ISerializer<double?>.Features => ((ISerializer<double>)this).Features;

		SerializerFeatures ISerializer<Type>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<IntPtr>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<UIntPtr>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<IntPtr?>.Features => ((ISerializer<IntPtr>)this).Features;

		SerializerFeatures ISerializer<UIntPtr?>.Features => ((ISerializer<UIntPtr>)this).Features;

		SerializerFeatures ISerializer<DateTime>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		SerializerFeatures ISerializer<DateTime?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		SerializerFeatures ISerializer<TimeSpan>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		SerializerFeatures ISerializer<TimeSpan?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessageWrappedAtRoot;

		SerializerFeatures ISerializer<ScaledTicks>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		SerializerFeatures ISerializer<Duration>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		SerializerFeatures ISerializer<Duration?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		SerializerFeatures ISerializer<Empty>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		SerializerFeatures ISerializer<Empty?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		SerializerFeatures ISerializer<Timestamp>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		SerializerFeatures ISerializer<Timestamp?>.Features => SerializerFeatures.WireTypeString | SerializerFeatures.CategoryMessage;

		decimal? ISerializer<decimal?>.Read(ref ProtoReader.State state, decimal? value)
		{
			return ((ISerializer<decimal>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<decimal?>.Write(ref ProtoWriter.State state, decimal? value)
		{
			((ISerializer<decimal>)this).Write(ref state, value.Value);
		}

		decimal ISerializer<decimal>.Read(ref ProtoReader.State state, decimal value)
		{
			ulong num = 0uL;
			uint num2 = 0u;
			uint num3 = 0u;
			int num4;
			while ((num4 = state.ReadFieldHeader()) > 0)
			{
				switch (num4)
				{
				case 1:
					num = state.ReadUInt64();
					break;
				case 2:
					num2 = state.ReadUInt32();
					break;
				case 3:
					num3 = state.ReadUInt32();
					break;
				default:
					state.SkipField();
					break;
				}
			}
			int lo = (int)(num & 0xFFFFFFFFu);
			int mid = (int)((num >> 32) & 0xFFFFFFFFu);
			int hi = (int)num2;
			bool isNegative = (num3 & 1) == 1;
			byte scale = (byte)((num3 & 0x1FE) >> 1);
			return new decimal(lo, mid, hi, isNegative, scale);
		}

		void ISerializer<decimal>.Write(ref ProtoWriter.State state, decimal value)
		{
			ulong num3;
			uint num4;
			uint num5;
			if (s_decimalOptimized)
			{
				DecimalAccessor decimalAccessor = new DecimalAccessor(value);
				ulong num = (ulong)((long)decimalAccessor.Mid << 32);
				ulong num2 = (ulong)(decimalAccessor.Lo & 0xFFFFFFFFu);
				num3 = num | num2;
				num4 = (uint)decimalAccessor.Hi;
				num5 = (uint)(((decimalAccessor.Flags >> 15) & 0x1FE) | ((decimalAccessor.Flags >> 31) & 1));
			}
			else
			{
				int[] bits = decimal.GetBits(value);
				ulong num6 = (ulong)((long)bits[1] << 32);
				ulong num7 = (ulong)(bits[0] & 0xFFFFFFFFu);
				num3 = num6 | num7;
				num4 = (uint)bits[2];
				num5 = (uint)(((bits[3] >> 15) & 0x1FE) | ((bits[3] >> 31) & 1));
			}
			if (num3 != 0L)
			{
				state.WriteFieldHeader(1, WireType.Variant);
				state.WriteUInt64(num3);
			}
			if (num4 != 0)
			{
				state.WriteFieldHeader(2, WireType.Variant);
				state.WriteUInt32(num4);
			}
			if (num5 != 0)
			{
				state.WriteFieldHeader(3, WireType.Variant);
				state.WriteUInt32(num5);
			}
		}

		private static bool VerifyDecimalLayout()
		{
			try
			{
				decimal num = 1.0000000000000000000000000000m;
				DecimalAccessor decimalAccessor = new DecimalAccessor(num);
				if ((decimalAccessor.Lo == 268435456) & (decimalAccessor.Mid == 1042612833) & (decimalAccessor.Hi == 542101086) & (decimalAccessor.Flags == 1835008))
				{
					int[] bits = decimal.GetBits(num);
					if (bits.Length == 4)
					{
						return (decimalAccessor.Lo == bits[0]) & (decimalAccessor.Mid == bits[1]) & (decimalAccessor.Hi == bits[2]) & (decimalAccessor.Flags == bits[3]);
					}
				}
			}
			catch
			{
			}
			return false;
		}

		Guid? ISerializer<Guid?>.Read(ref ProtoReader.State state, Guid? value)
		{
			return ((ISerializer<Guid>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<Guid?>.Write(ref ProtoWriter.State state, Guid? value)
		{
			((ISerializer<Guid>)this).Write(ref state, value.Value);
		}

		Guid ISerializer<Guid>.Read(ref ProtoReader.State state, Guid value)
		{
			ulong num = 0uL;
			ulong num2 = 0uL;
			int num3;
			while ((num3 = state.ReadFieldHeader()) > 0)
			{
				switch (num3)
				{
				case 1:
					num = state.ReadUInt64();
					break;
				case 2:
					num2 = state.ReadUInt64();
					break;
				default:
					state.SkipField();
					break;
				}
			}
			if (num == 0 && num2 == 0)
			{
				return default(Guid);
			}
			if (s_guidOptimized)
			{
				return new GuidAccessor(num, num2).Guid;
			}
			uint num4 = (uint)(num >> 32);
			uint a = (uint)num;
			uint num5 = (uint)(num2 >> 32);
			uint num6 = (uint)num2;
			return new Guid((int)a, (short)num4, (short)(num4 >> 16), (byte)num6, (byte)(num6 >> 8), (byte)(num6 >> 16), (byte)(num6 >> 24), (byte)num5, (byte)(num5 >> 8), (byte)(num5 >> 16), (byte)(num5 >> 24));
		}

		void ISerializer<Guid>.Write(ref ProtoWriter.State state, Guid value)
		{
			if (!(value == Guid.Empty))
			{
				if (s_guidOptimized)
				{
					GuidAccessor guidAccessor = new GuidAccessor(value);
					state.WriteFieldHeader(1, WireType.Fixed64);
					state.WriteUInt64(guidAccessor.Low);
					state.WriteFieldHeader(2, WireType.Fixed64);
					state.WriteUInt64(guidAccessor.High);
				}
				else
				{
					byte[] array = value.ToByteArray();
					state.WriteFieldHeader(1, WireType.Fixed64);
					state.WriteBytes(new ReadOnlyMemory<byte>(array, 0, 8));
					state.WriteFieldHeader(2, WireType.Fixed64);
					state.WriteBytes(new ReadOnlyMemory<byte>(array, 8, 8));
				}
			}
		}

		private static bool VerifyGuidLayout()
		{
			try
			{
				if (!Guid.TryParse("12345678-2345-3456-4567-56789a6789ab", out var result))
				{
					return false;
				}
				GuidAccessor guidAccessor = new GuidAccessor(result);
				ulong low = guidAccessor.Low;
				ulong high = guidAccessor.High;
				if (low != 3771240517534504568L || high != 12360524565436589893uL)
				{
					return false;
				}
				byte[] array = result.ToByteArray();
				for (int i = 0; i < 8; i++)
				{
					if (array[i] != (byte)(low >> 8 * i))
					{
						return false;
					}
				}
				for (int j = 0; j < 8; j++)
				{
					if (array[j + 8] != (byte)(high >> 8 * j))
					{
						return false;
					}
				}
				return true;
			}
			catch
			{
			}
			return false;
		}

		string ISerializer<string>.Read(ref ProtoReader.State state, string value)
		{
			return state.ReadString();
		}

		void ISerializer<string>.Write(ref ProtoWriter.State state, string value)
		{
			state.WriteString(value);
		}

		int IMeasuringSerializer<string>.Measure(ISerializationContext context, WireType wireType, string value)
		{
			if (wireType == WireType.String)
			{
				return ProtoWriter.UTF8.GetByteCount(value);
			}
			return -1;
		}

		int ISerializer<int>.Read(ref ProtoReader.State state, int value)
		{
			return state.ReadInt32();
		}

		void ISerializer<int>.Write(ref ProtoWriter.State state, int value)
		{
			state.WriteInt32(value);
		}

		int IMeasuringSerializer<int>.Measure(ISerializationContext context, WireType wireType, int value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureInt32(value), 
				WireType.SignedVariant => ProtoWriter.MeasureUInt32(ProtoWriter.Zig(value)), 
				_ => -1, 
			};
		}

		byte[] ISerializer<byte[]>.Read(ref ProtoReader.State state, byte[] value)
		{
			return state.AppendBytes(value);
		}

		void ISerializer<byte[]>.Write(ref ProtoWriter.State state, byte[] value)
		{
			state.WriteBytes(value);
		}

		int IMeasuringSerializer<byte[]>.Measure(ISerializationContext context, WireType wireType, byte[] value)
		{
			if (wireType == WireType.String)
			{
				return value.Length;
			}
			return -1;
		}

		ArraySegment<byte> ISerializer<ArraySegment<byte>>.Read(ref ProtoReader.State state, ArraySegment<byte> value)
		{
			return state.AppendBytes(value);
		}

		void ISerializer<ArraySegment<byte>>.Write(ref ProtoWriter.State state, ArraySegment<byte> value)
		{
			state.WriteBytes(value);
		}

		int IMeasuringSerializer<ArraySegment<byte>>.Measure(ISerializationContext context, WireType wireType, ArraySegment<byte> value)
		{
			if (wireType == WireType.String)
			{
				return value.Count;
			}
			return -1;
		}

		Memory<byte> ISerializer<Memory<byte>>.Read(ref ProtoReader.State state, Memory<byte> value)
		{
			return state.AppendBytes(value);
		}

		void ISerializer<Memory<byte>>.Write(ref ProtoWriter.State state, Memory<byte> value)
		{
			state.WriteBytes(value);
		}

		int IMeasuringSerializer<Memory<byte>>.Measure(ISerializationContext context, WireType wireType, Memory<byte> value)
		{
			if (wireType == WireType.String)
			{
				return value.Length;
			}
			return -1;
		}

		ReadOnlyMemory<byte> ISerializer<ReadOnlyMemory<byte>>.Read(ref ProtoReader.State state, ReadOnlyMemory<byte> value)
		{
			return state.AppendBytes(value);
		}

		void ISerializer<ReadOnlyMemory<byte>>.Write(ref ProtoWriter.State state, ReadOnlyMemory<byte> value)
		{
			state.WriteBytes(value);
		}

		int IMeasuringSerializer<ReadOnlyMemory<byte>>.Measure(ISerializationContext context, WireType wireType, ReadOnlyMemory<byte> value)
		{
			if (wireType == WireType.String)
			{
				return value.Length;
			}
			return -1;
		}

		byte ISerializer<byte>.Read(ref ProtoReader.State state, byte value)
		{
			return state.ReadByte();
		}

		void ISerializer<byte>.Write(ref ProtoWriter.State state, byte value)
		{
			state.WriteByte(value);
		}

		int IMeasuringSerializer<byte>.Measure(ISerializationContext context, WireType wireType, byte value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureUInt32(value), 
				_ => -1, 
			};
		}

		ushort ISerializer<ushort>.Read(ref ProtoReader.State state, ushort value)
		{
			return state.ReadUInt16();
		}

		void ISerializer<ushort>.Write(ref ProtoWriter.State state, ushort value)
		{
			state.WriteUInt16(value);
		}

		int IMeasuringSerializer<ushort>.Measure(ISerializationContext context, WireType wireType, ushort value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureUInt32(value), 
				_ => -1, 
			};
		}

		uint ISerializer<uint>.Read(ref ProtoReader.State state, uint value)
		{
			return state.ReadUInt32();
		}

		void ISerializer<uint>.Write(ref ProtoWriter.State state, uint value)
		{
			state.WriteUInt32(value);
		}

		int IMeasuringSerializer<uint>.Measure(ISerializationContext context, WireType wireType, uint value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureUInt32(value), 
				_ => -1, 
			};
		}

		ulong ISerializer<ulong>.Read(ref ProtoReader.State state, ulong value)
		{
			return state.ReadUInt64();
		}

		void ISerializer<ulong>.Write(ref ProtoWriter.State state, ulong value)
		{
			state.WriteUInt64(value);
		}

		int IMeasuringSerializer<ulong>.Measure(ISerializationContext context, WireType wireType, ulong value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureUInt64(value), 
				_ => -1, 
			};
		}

		long ISerializer<long>.Read(ref ProtoReader.State state, long value)
		{
			return state.ReadInt64();
		}

		void ISerializer<long>.Write(ref ProtoWriter.State state, long value)
		{
			state.WriteInt64(value);
		}

		int IMeasuringSerializer<long>.Measure(ISerializationContext context, WireType wireType, long value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureUInt64((ulong)value), 
				WireType.SignedVariant => ProtoWriter.MeasureUInt64(ProtoWriter.Zig(value)), 
				_ => -1, 
			};
		}

		bool ISerializer<bool>.Read(ref ProtoReader.State state, bool value)
		{
			return state.ReadBoolean();
		}

		void ISerializer<bool>.Write(ref ProtoWriter.State state, bool value)
		{
			state.WriteBoolean(value);
		}

		int IMeasuringSerializer<bool>.Measure(ISerializationContext context, WireType wireType, bool value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => 1, 
				_ => -1, 
			};
		}

		float ISerializer<float>.Read(ref ProtoReader.State state, float value)
		{
			return state.ReadSingle();
		}

		void ISerializer<float>.Write(ref ProtoWriter.State state, float value)
		{
			state.WriteSingle(value);
		}

		int IMeasuringSerializer<float>.Measure(ISerializationContext context, WireType wireType, float value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				_ => -1, 
			};
		}

		double ISerializer<double>.Read(ref ProtoReader.State state, double value)
		{
			return state.ReadDouble();
		}

		void ISerializer<double>.Write(ref ProtoWriter.State state, double value)
		{
			state.WriteDouble(value);
		}

		int IMeasuringSerializer<double>.Measure(ISerializationContext context, WireType wireType, double value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				_ => -1, 
			};
		}

		sbyte ISerializer<sbyte>.Read(ref ProtoReader.State state, sbyte value)
		{
			return state.ReadSByte();
		}

		void ISerializer<sbyte>.Write(ref ProtoWriter.State state, sbyte value)
		{
			state.WriteSByte(value);
		}

		int IMeasuringSerializer<sbyte>.Measure(ISerializationContext context, WireType wireType, sbyte value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureInt32(value), 
				WireType.SignedVariant => ProtoWriter.MeasureUInt32(ProtoWriter.Zig(value)), 
				_ => -1, 
			};
		}

		short ISerializer<short>.Read(ref ProtoReader.State state, short value)
		{
			return state.ReadInt16();
		}

		void ISerializer<short>.Write(ref ProtoWriter.State state, short value)
		{
			state.WriteInt16(value);
		}

		int IMeasuringSerializer<short>.Measure(ISerializationContext context, WireType wireType, short value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureInt32(value), 
				WireType.SignedVariant => ProtoWriter.MeasureUInt32(ProtoWriter.Zig(value)), 
				_ => -1, 
			};
		}

		Uri ISerializer<Uri>.Read(ref ProtoReader.State state, Uri value)
		{
			string text = state.ReadString();
			if (!string.IsNullOrEmpty(text))
			{
				return new Uri(text, UriKind.RelativeOrAbsolute);
			}
			return null;
		}

		void ISerializer<Uri>.Write(ref ProtoWriter.State state, Uri value)
		{
			state.WriteString(value.OriginalString);
		}

		int IMeasuringSerializer<Uri>.Measure(ISerializationContext context, WireType wireType, Uri value)
		{
			if (wireType == WireType.String)
			{
				return ProtoWriter.UTF8.GetByteCount(value.OriginalString);
			}
			return -1;
		}

		char ISerializer<char>.Read(ref ProtoReader.State state, char value)
		{
			return (char)state.ReadUInt16();
		}

		void ISerializer<char>.Write(ref ProtoWriter.State state, char value)
		{
			state.WriteUInt16(value);
		}

		int IMeasuringSerializer<char>.Measure(ISerializationContext context, WireType wireType, char value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => ProtoWriter.MeasureUInt32(value), 
				_ => -1, 
			};
		}

		string IFactory<string>.Create(ISerializationContext context)
		{
			return "";
		}

		byte[] IFactory<byte[]>.Create(ISerializationContext context)
		{
			return Array.Empty<byte>();
		}

		void ISerializer<int?>.Write(ref ProtoWriter.State state, int? value)
		{
			((ISerializer<int>)this).Write(ref state, value.Value);
		}

		int? ISerializer<int?>.Read(ref ProtoReader.State state, int? value)
		{
			return ((ISerializer<int>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<short?>.Write(ref ProtoWriter.State state, short? value)
		{
			((ISerializer<short>)this).Write(ref state, value.Value);
		}

		short? ISerializer<short?>.Read(ref ProtoReader.State state, short? value)
		{
			return ((ISerializer<short>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<long?>.Write(ref ProtoWriter.State state, long? value)
		{
			((ISerializer<long>)this).Write(ref state, value.Value);
		}

		long? ISerializer<long?>.Read(ref ProtoReader.State state, long? value)
		{
			return ((ISerializer<long>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<sbyte?>.Write(ref ProtoWriter.State state, sbyte? value)
		{
			((ISerializer<sbyte>)this).Write(ref state, value.Value);
		}

		sbyte? ISerializer<sbyte?>.Read(ref ProtoReader.State state, sbyte? value)
		{
			return ((ISerializer<sbyte>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<uint?>.Write(ref ProtoWriter.State state, uint? value)
		{
			((ISerializer<uint>)this).Write(ref state, value.Value);
		}

		uint? ISerializer<uint?>.Read(ref ProtoReader.State state, uint? value)
		{
			return ((ISerializer<uint>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<ushort?>.Write(ref ProtoWriter.State state, ushort? value)
		{
			((ISerializer<ushort>)this).Write(ref state, value.Value);
		}

		ushort? ISerializer<ushort?>.Read(ref ProtoReader.State state, ushort? value)
		{
			return ((ISerializer<ushort>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<ulong?>.Write(ref ProtoWriter.State state, ulong? value)
		{
			((ISerializer<ulong>)this).Write(ref state, value.Value);
		}

		ulong? ISerializer<ulong?>.Read(ref ProtoReader.State state, ulong? value)
		{
			return ((ISerializer<ulong>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<byte?>.Write(ref ProtoWriter.State state, byte? value)
		{
			((ISerializer<byte>)this).Write(ref state, value.Value);
		}

		byte? ISerializer<byte?>.Read(ref ProtoReader.State state, byte? value)
		{
			return ((ISerializer<byte>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<char?>.Write(ref ProtoWriter.State state, char? value)
		{
			((ISerializer<char>)this).Write(ref state, value.Value);
		}

		char? ISerializer<char?>.Read(ref ProtoReader.State state, char? value)
		{
			return ((ISerializer<char>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<bool?>.Write(ref ProtoWriter.State state, bool? value)
		{
			((ISerializer<bool>)this).Write(ref state, value.Value);
		}

		bool? ISerializer<bool?>.Read(ref ProtoReader.State state, bool? value)
		{
			return ((ISerializer<bool>)this).Read(ref state, value == true);
		}

		void ISerializer<float?>.Write(ref ProtoWriter.State state, float? value)
		{
			((ISerializer<float>)this).Write(ref state, value.Value);
		}

		float? ISerializer<float?>.Read(ref ProtoReader.State state, float? value)
		{
			return ((ISerializer<float>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<double?>.Write(ref ProtoWriter.State state, double? value)
		{
			((ISerializer<double>)this).Write(ref state, value.Value);
		}

		double? ISerializer<double?>.Read(ref ProtoReader.State state, double? value)
		{
			return ((ISerializer<double>)this).Read(ref state, value.GetValueOrDefault());
		}

		Type ISerializer<Type>.Read(ref ProtoReader.State state, Type value)
		{
			return state.ReadType();
		}

		void ISerializer<Type>.Write(ref ProtoWriter.State state, Type value)
		{
			state.WriteType(value);
		}

		int IMeasuringSerializer<Type>.Measure(ISerializationContext context, WireType wireType, Type value)
		{
			if (wireType == WireType.String)
			{
				return Encoding.UTF8.GetByteCount(TypeModel.SerializeType(context?.Model, value));
			}
			return -1;
		}

		bool IValueChecker<string>.HasNonTrivialValue(string value)
		{
			return value != null;
		}

		bool IValueChecker<Uri>.HasNonTrivialValue(Uri value)
		{
			return value?.OriginalString != null;
		}

		bool IValueChecker<Type>.HasNonTrivialValue(Type value)
		{
			return (object)value != null;
		}

		bool IValueChecker<byte[]>.HasNonTrivialValue(byte[] value)
		{
			return value != null;
		}

		bool IValueChecker<sbyte>.HasNonTrivialValue(sbyte value)
		{
			return value != 0;
		}

		bool IValueChecker<short>.HasNonTrivialValue(short value)
		{
			return value != 0;
		}

		bool IValueChecker<int>.HasNonTrivialValue(int value)
		{
			return value != 0;
		}

		bool IValueChecker<long>.HasNonTrivialValue(long value)
		{
			return value != 0;
		}

		bool IValueChecker<byte>.HasNonTrivialValue(byte value)
		{
			return value != 0;
		}

		bool IValueChecker<ushort>.HasNonTrivialValue(ushort value)
		{
			return value != 0;
		}

		bool IValueChecker<uint>.HasNonTrivialValue(uint value)
		{
			return value != 0;
		}

		bool IValueChecker<ulong>.HasNonTrivialValue(ulong value)
		{
			return value != 0;
		}

		bool IValueChecker<char>.HasNonTrivialValue(char value)
		{
			return value != '\0';
		}

		bool IValueChecker<bool>.HasNonTrivialValue(bool value)
		{
			return value;
		}

		bool IValueChecker<float>.HasNonTrivialValue(float value)
		{
			return value != 0f;
		}

		bool IValueChecker<double>.HasNonTrivialValue(double value)
		{
			return value != 0.0;
		}

		bool IValueChecker<sbyte>.IsNull(sbyte value)
		{
			return false;
		}

		bool IValueChecker<short>.IsNull(short value)
		{
			return false;
		}

		bool IValueChecker<int>.IsNull(int value)
		{
			return false;
		}

		bool IValueChecker<long>.IsNull(long value)
		{
			return false;
		}

		bool IValueChecker<byte>.IsNull(byte value)
		{
			return false;
		}

		bool IValueChecker<ushort>.IsNull(ushort value)
		{
			return false;
		}

		bool IValueChecker<uint>.IsNull(uint value)
		{
			return false;
		}

		bool IValueChecker<ulong>.IsNull(ulong value)
		{
			return false;
		}

		bool IValueChecker<char>.IsNull(char value)
		{
			return false;
		}

		bool IValueChecker<bool>.IsNull(bool value)
		{
			return false;
		}

		bool IValueChecker<float>.IsNull(float value)
		{
			return false;
		}

		bool IValueChecker<double>.IsNull(double value)
		{
			return false;
		}

		bool IValueChecker<string>.IsNull(string value)
		{
			return value == null;
		}

		bool IValueChecker<byte[]>.IsNull(byte[] value)
		{
			return value == null;
		}

		bool IValueChecker<Uri>.IsNull(Uri value)
		{
			return (object)value == null;
		}

		bool IValueChecker<Type>.IsNull(Type value)
		{
			return (object)value == null;
		}

		bool IValueChecker<int?>.HasNonTrivialValue(int? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<int?>.IsNull(int? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<uint?>.HasNonTrivialValue(uint? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<uint?>.IsNull(uint? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<short?>.HasNonTrivialValue(short? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<short?>.IsNull(short? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<ushort?>.HasNonTrivialValue(ushort? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<ushort?>.IsNull(ushort? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<long?>.HasNonTrivialValue(long? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<long?>.IsNull(long? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<ulong?>.HasNonTrivialValue(ulong? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<ulong?>.IsNull(ulong? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<float?>.HasNonTrivialValue(float? value)
		{
			return value.GetValueOrDefault() != 0f;
		}

		bool IValueChecker<float?>.IsNull(float? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<double?>.HasNonTrivialValue(double? value)
		{
			return value.GetValueOrDefault() != 0.0;
		}

		bool IValueChecker<double?>.IsNull(double? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<byte?>.HasNonTrivialValue(byte? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<byte?>.IsNull(byte? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<sbyte?>.HasNonTrivialValue(sbyte? value)
		{
			return value.GetValueOrDefault() != 0;
		}

		bool IValueChecker<sbyte?>.IsNull(sbyte? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<bool?>.HasNonTrivialValue(bool? value)
		{
			return value == true;
		}

		bool IValueChecker<bool?>.IsNull(bool? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<char?>.HasNonTrivialValue(char? value)
		{
			return value.GetValueOrDefault() != '\0';
		}

		bool IValueChecker<char?>.IsNull(char? value)
		{
			return !value.HasValue;
		}

		int IMeasuringSerializer<int?>.Measure(ISerializationContext context, WireType wireType, int? value)
		{
			return ((IMeasuringSerializer<int>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<long?>.Measure(ISerializationContext context, WireType wireType, long? value)
		{
			return ((IMeasuringSerializer<long>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<float?>.Measure(ISerializationContext context, WireType wireType, float? value)
		{
			return ((IMeasuringSerializer<float>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<double?>.Measure(ISerializationContext context, WireType wireType, double? value)
		{
			return ((IMeasuringSerializer<double>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<byte?>.Measure(ISerializationContext context, WireType wireType, byte? value)
		{
			return ((IMeasuringSerializer<byte>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<ushort?>.Measure(ISerializationContext context, WireType wireType, ushort? value)
		{
			return ((IMeasuringSerializer<ushort>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<uint?>.Measure(ISerializationContext context, WireType wireType, uint? value)
		{
			return ((IMeasuringSerializer<uint>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<ulong?>.Measure(ISerializationContext context, WireType wireType, ulong? value)
		{
			return ((IMeasuringSerializer<ulong>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<sbyte?>.Measure(ISerializationContext context, WireType wireType, sbyte? value)
		{
			return ((IMeasuringSerializer<sbyte>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<short?>.Measure(ISerializationContext context, WireType wireType, short? value)
		{
			return ((IMeasuringSerializer<short>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<char?>.Measure(ISerializationContext context, WireType wireType, char? value)
		{
			return ((IMeasuringSerializer<char>)this).Measure(context, wireType, value.Value);
		}

		int IMeasuringSerializer<bool?>.Measure(ISerializationContext context, WireType wireType, bool? value)
		{
			return ((IMeasuringSerializer<bool>)this).Measure(context, wireType, value.Value);
		}

		void ISerializer<IntPtr?>.Write(ref ProtoWriter.State state, IntPtr? value)
		{
			((ISerializer<IntPtr>)this).Write(ref state, value.Value);
		}

		IntPtr? ISerializer<IntPtr?>.Read(ref ProtoReader.State state, IntPtr? value)
		{
			return ((ISerializer<IntPtr>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<UIntPtr?>.Write(ref ProtoWriter.State state, UIntPtr? value)
		{
			((ISerializer<UIntPtr>)this).Write(ref state, value.Value);
		}

		UIntPtr? ISerializer<UIntPtr?>.Read(ref ProtoReader.State state, UIntPtr? value)
		{
			return ((ISerializer<UIntPtr>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<IntPtr>.Write(ref ProtoWriter.State state, IntPtr value)
		{
			state.WriteIntPtr(value);
		}

		IntPtr ISerializer<IntPtr>.Read(ref ProtoReader.State state, IntPtr value)
		{
			return state.ReadIntPtr();
		}

		void ISerializer<UIntPtr>.Write(ref ProtoWriter.State state, UIntPtr value)
		{
			state.WriteUIntPtr(value);
		}

		UIntPtr ISerializer<UIntPtr>.Read(ref ProtoReader.State state, UIntPtr value)
		{
			return state.ReadUIntPtr();
		}

		int IMeasuringSerializer<IntPtr>.Measure(ISerializationContext context, WireType wireType, IntPtr value)
		{
			return ((IMeasuringSerializer<long>)this).Measure(context, wireType, value.ToInt64());
		}

		int IMeasuringSerializer<UIntPtr>.Measure(ISerializationContext context, WireType wireType, UIntPtr value)
		{
			return ((IMeasuringSerializer<ulong>)this).Measure(context, wireType, value.ToUInt64());
		}

		int IMeasuringSerializer<IntPtr?>.Measure(ISerializationContext context, WireType wireType, IntPtr? value)
		{
			return ((IMeasuringSerializer<long>)this).Measure(context, wireType, value.Value.ToInt64());
		}

		int IMeasuringSerializer<UIntPtr?>.Measure(ISerializationContext context, WireType wireType, UIntPtr? value)
		{
			return ((IMeasuringSerializer<ulong>)this).Measure(context, wireType, value.Value.ToUInt64());
		}

		bool IValueChecker<IntPtr>.HasNonTrivialValue(IntPtr value)
		{
			return value != IntPtr.Zero;
		}

		bool IValueChecker<IntPtr>.IsNull(IntPtr value)
		{
			return false;
		}

		bool IValueChecker<UIntPtr>.HasNonTrivialValue(UIntPtr value)
		{
			return value != UIntPtr.Zero;
		}

		bool IValueChecker<UIntPtr>.IsNull(UIntPtr value)
		{
			return false;
		}

		bool IValueChecker<IntPtr?>.HasNonTrivialValue(IntPtr? value)
		{
			return value.GetValueOrDefault() != IntPtr.Zero;
		}

		bool IValueChecker<IntPtr?>.IsNull(IntPtr? value)
		{
			return !value.HasValue;
		}

		bool IValueChecker<UIntPtr?>.HasNonTrivialValue(UIntPtr? value)
		{
			return value.GetValueOrDefault() != UIntPtr.Zero;
		}

		bool IValueChecker<UIntPtr?>.IsNull(UIntPtr? value)
		{
			return !value.HasValue;
		}

		TimeSpan? ISerializer<TimeSpan?>.Read(ref ProtoReader.State state, TimeSpan? value)
		{
			return ((ISerializer<TimeSpan>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<TimeSpan?>.Write(ref ProtoWriter.State state, TimeSpan? value)
		{
			((ISerializer<TimeSpan>)this).Write(ref state, value.Value);
		}

		DateTime? ISerializer<DateTime?>.Read(ref ProtoReader.State state, DateTime? value)
		{
			return ((ISerializer<DateTime>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<DateTime?>.Write(ref ProtoWriter.State state, DateTime? value)
		{
			((ISerializer<DateTime>)this).Write(ref state, value.Value);
		}

		TimeSpan ISerializer<TimeSpan>.Read(ref ProtoReader.State state, TimeSpan value)
		{
			return ((ISerializer<ScaledTicks>)this).Read(ref state, default(ScaledTicks)).ToTimeSpan();
		}

		void ISerializer<TimeSpan>.Write(ref ProtoWriter.State state, TimeSpan value)
		{
			((ISerializer<ScaledTicks>)this).Write(ref state, new ScaledTicks(value, DateTimeKind.Unspecified));
		}

		DateTime ISerializer<DateTime>.Read(ref ProtoReader.State state, DateTime value)
		{
			return ((ISerializer<ScaledTicks>)this).Read(ref state, default(ScaledTicks)).ToDateTime();
		}

		void ISerializer<DateTime>.Write(ref ProtoWriter.State state, DateTime value)
		{
			bool includeKind = state.Model.HasOption(TypeModel.TypeModelOptions.IncludeDateTimeKind);
			((ISerializer<ScaledTicks>)this).Write(ref state, ScaledTicks.Create(value, includeKind));
		}

		void ISerializer<ScaledTicks>.Write(ref ProtoWriter.State state, ScaledTicks value)
		{
			if (value.Value != 0L)
			{
				state.WriteFieldHeader(1, WireType.SignedVariant);
				state.WriteInt64(value.Value);
			}
			if (value.Scale != TimeSpanScale.Days)
			{
				state.WriteFieldHeader(2, WireType.Variant);
				state.WriteInt32((int)value.Scale);
			}
			if (value.Kind != DateTimeKind.Unspecified)
			{
				state.WriteFieldHeader(3, WireType.Variant);
				state.WriteInt32((int)value.Kind);
			}
		}

		ScaledTicks ISerializer<ScaledTicks>.Read(ref ProtoReader.State state, ScaledTicks _)
		{
			TimeSpanScale scale = TimeSpanScale.Days;
			long value = 0L;
			DateTimeKind dateTimeKind = DateTimeKind.Unspecified;
			int num;
			while ((num = state.ReadFieldHeader()) > 0)
			{
				switch (num)
				{
				case 2:
					scale = (TimeSpanScale)state.ReadInt32();
					break;
				case 1:
					state.Assert(WireType.SignedVariant);
					value = state.ReadInt64();
					break;
				case 3:
					dateTimeKind = (DateTimeKind)state.ReadInt32();
					if ((uint)dateTimeKind > 2u)
					{
						ThrowHelper.ThrowProtoException("Invalid date/time kind: " + dateTimeKind);
					}
					break;
				default:
					state.SkipField();
					break;
				}
			}
			return new ScaledTicks(value, scale, dateTimeKind);
		}

		Duration? ISerializer<Duration?>.Read(ref ProtoReader.State state, Duration? value)
		{
			return ((ISerializer<Duration>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<Duration?>.Write(ref ProtoWriter.State state, Duration? value)
		{
			((ISerializer<Duration>)this).Write(ref state, value.Value);
		}

		Duration ISerializer<Duration>.Read(ref ProtoReader.State state, Duration value)
		{
			return ReadDuration(ref state, value);
		}

		internal static Duration ReadDuration(ref ProtoReader.State state, Duration value)
		{
			if (state.WireType == WireType.String && state.RemainingInCurrent >= 20 && TryReadDurationFast(ref state, ref value))
			{
				return value;
			}
			return ReadDurationFallback(ref state, value);
		}

		private static bool TryReadDurationFast(ref ProtoReader.State state, ref Duration value)
		{
			int offsetInCurrent = state.OffsetInCurrent;
			ReadOnlySpan<byte> span = state.Span;
			uint value2;
			int num = state.ParseVarintUInt32(span, offsetInCurrent, out value2);
			offsetInCurrent += num;
			if (value2 == 0)
			{
				return true;
			}
			if (num + value2 > state.RemainingInCurrent)
			{
				return false;
			}
			if (span[offsetInCurrent] != 8)
			{
				return false;
			}
			ulong value3;
			int num2 = 1 + ProtoReader.State.TryParseUInt64Varint(span, 1 + offsetInCurrent, out value3);
			int nanoseconds = value.Nanoseconds;
			if (num2 < value2)
			{
				if (span[num2++ + offsetInCurrent] != 16)
				{
					return false;
				}
				num2 += ProtoReader.State.TryParseUInt64Varint(span, num2 + offsetInCurrent, out var value4);
				nanoseconds = (int)value4;
			}
			if (num2 != value2)
			{
				return false;
			}
			state.Skip(num + (int)value2);
			state.Advance(num + value2);
			value = new Duration((long)value3, nanoseconds);
			return true;
		}

		private static Duration ReadDurationFallback(ref ProtoReader.State state, Duration value)
		{
			long seconds = value.Seconds;
			int nanoseconds = value.Nanoseconds;
			int num;
			while ((num = state.ReadFieldHeader()) > 0)
			{
				switch (num)
				{
				case 1:
					seconds = state.ReadInt64();
					break;
				case 2:
					nanoseconds = state.ReadInt32();
					break;
				default:
					state.SkipField();
					break;
				}
			}
			return new Duration(seconds, nanoseconds);
		}

		void ISerializer<Duration>.Write(ref ProtoWriter.State state, Duration value)
		{
			WriteSecondsNanos(ref state, value.Seconds, value.Nanoseconds, isTimestamp: false);
		}

		internal static void WriteDuration(ref ProtoWriter.State state, Duration value)
		{
			WriteSecondsNanos(ref state, value.Seconds, value.Nanoseconds, isTimestamp: false);
		}

		internal static long ToDurationSeconds(long ticks, out int nanos, bool isTimestamp)
		{
			nanos = (int)(ticks % 10000000 * 1000000 / 10000);
			long seconds = ticks / 10000000;
			NormalizeSecondsNanoseconds(ref seconds, ref nanos, isTimestamp);
			return seconds;
		}

		internal static long ToTicks(long seconds, int nanos)
		{
			checked
			{
				return seconds * 10000000 + unchecked(checked(unchecked((long)nanos) * 10000L) / 1000000);
			}
		}

		internal static void NormalizeSecondsNanoseconds(ref long seconds, ref int nanos, bool isTimestamp)
		{
			seconds += nanos / 1000000000;
			nanos %= 1000000000;
			if (isTimestamp)
			{
				if (nanos < 0)
				{
					seconds--;
					nanos += 1000000000;
				}
				return;
			}
			if (nanos < 0 && seconds >= 0)
			{
				seconds--;
				nanos += 1000000000;
			}
			if (nanos > 0 && seconds < 0)
			{
				nanos -= 1000000000;
				seconds++;
			}
		}

		private static void WriteSecondsNanos(ref ProtoWriter.State state, long seconds, int nanos, bool isTimestamp)
		{
			NormalizeSecondsNanoseconds(ref seconds, ref nanos, isTimestamp);
			if (seconds != 0L)
			{
				state.WriteFieldHeader(1, WireType.Variant);
				state.WriteInt64(seconds);
			}
			if (nanos != 0)
			{
				state.WriteFieldHeader(2, WireType.Variant);
				state.WriteInt32(nanos);
			}
		}

		Empty ISerializer<Empty>.Read(ref ProtoReader.State state, Empty value)
		{
			state.SkipAllFields();
			return value;
		}

		void ISerializer<Empty>.Write(ref ProtoWriter.State state, Empty value)
		{
		}

		Empty? ISerializer<Empty?>.Read(ref ProtoReader.State state, Empty? value)
		{
			return ((ISerializer<Empty>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<Empty?>.Write(ref ProtoWriter.State state, Empty? value)
		{
			((ISerializer<Empty>)this).Write(ref state, value.Value);
		}

		Timestamp ISerializer<Timestamp>.Read(ref ProtoReader.State state, Timestamp value)
		{
			Duration value2 = new Duration(value.Seconds, value.Nanoseconds);
			value2 = ReadDuration(ref state, value2);
			return new Timestamp(value2.Seconds, value2.Nanoseconds);
		}

		internal static Timestamp ReadTimestamp(ref ProtoReader.State state, Timestamp value)
		{
			Duration value2 = new Duration(value.Seconds, value.Nanoseconds);
			value2 = ReadDuration(ref state, value2);
			return new Timestamp(value2.Seconds, value2.Nanoseconds);
		}

		void ISerializer<Timestamp>.Write(ref ProtoWriter.State state, Timestamp value)
		{
			WriteSecondsNanos(ref state, value.Seconds, value.Nanoseconds, isTimestamp: true);
		}

		internal static void WriteTimestamp(ref ProtoWriter.State state, Timestamp value)
		{
			WriteSecondsNanos(ref state, value.Seconds, value.Nanoseconds, isTimestamp: true);
		}

		Timestamp? ISerializer<Timestamp?>.Read(ref ProtoReader.State state, Timestamp? value)
		{
			return ((ISerializer<Timestamp>)this).Read(ref state, value.GetValueOrDefault());
		}

		void ISerializer<Timestamp?>.Write(ref ProtoWriter.State state, Timestamp? value)
		{
			((ISerializer<Timestamp>)this).Write(ref state, value.Value);
		}
	}
}
