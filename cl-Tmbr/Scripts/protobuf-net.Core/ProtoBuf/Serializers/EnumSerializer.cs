using System;
using System.Runtime.CompilerServices;
using ProtoBuf.Internal;

namespace ProtoBuf.Serializers
{
	public static class EnumSerializer
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateSByte<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerSByte<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateInt16<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerInt16<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateInt32<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerInt32<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateInt64<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerInt64<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateByte<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerByte<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateUInt16<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerUInt16<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateUInt32<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerUInt32<T>>.InstanceField;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static EnumSerializer<T> CreateUInt64<T>() where T : unmanaged
		{
			return SerializerCache<EnumSerializerUInt64<T>>.InstanceField;
		}
	}
	public abstract class EnumSerializer<TEnum> : ISerializer<TEnum>, ISerializer<TEnum?> where TEnum : unmanaged
	{
		SerializerFeatures ISerializer<TEnum>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		SerializerFeatures ISerializer<TEnum?>.Features => SerializerFeatures.WireTypeVarint | SerializerFeatures.CategoryScalar;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		TEnum? ISerializer<TEnum?>.Read(ref ProtoReader.State state, TEnum? value)
		{
			return Read(ref state, default(TEnum));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		void ISerializer<TEnum?>.Write(ref ProtoWriter.State state, TEnum? value)
		{
			Write(ref state, value.Value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public abstract TEnum Read(ref ProtoReader.State state, TEnum value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public abstract void Write(ref ProtoWriter.State state, TEnum value);

		private protected EnumSerializer()
		{
		}
	}
	internal abstract class EnumSerializer<TEnum, TRaw> : EnumSerializer<TEnum>, IMeasuringSerializer<TEnum>, ISerializer<TEnum>, IMeasuringSerializer<TEnum?>, ISerializer<TEnum?> where TEnum : unmanaged where TRaw : unmanaged
	{
		private protected const int NegLength = 10;

		private protected unsafe EnumSerializer()
		{
			Type typeFromHandle = typeof(TEnum);
			if (sizeof(TEnum) != sizeof(TRaw) || !typeFromHandle.IsEnum || Enum.GetUnderlyingType(typeFromHandle) != typeof(TRaw))
			{
				ThrowHelper.ThrowInvalidOperationException(typeof(TEnum).NormalizeName() + " is not a valid enum for " + typeof(TRaw).NormalizeName());
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected abstract TRaw Read(ref ProtoReader.State state);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		protected abstract void Write(ref ProtoWriter.State state, TRaw value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public abstract int MeasureVarint(TRaw value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public virtual int MeasureSignedVarint(TRaw value)
		{
			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe override TEnum Read(ref ProtoReader.State state, TEnum value)
		{
			TRaw val = Read(ref state);
			return *(TEnum*)(&val);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe override void Write(ref ProtoWriter.State state, TEnum value)
		{
			Write(ref state, *(TRaw*)(&value));
		}

		public unsafe int Measure(ISerializationContext context, WireType wireType, TEnum value)
		{
			return wireType switch
			{
				WireType.Fixed32 => 4, 
				WireType.Fixed64 => 8, 
				WireType.Variant => MeasureVarint(*(TRaw*)(&value)), 
				WireType.SignedVariant => MeasureSignedVarint(*(TRaw*)(&value)), 
				_ => -1, 
			};
		}

		int IMeasuringSerializer<TEnum?>.Measure(ISerializationContext context, WireType wireType, TEnum? value)
		{
			return Measure(context, wireType, value.Value);
		}
	}
}
