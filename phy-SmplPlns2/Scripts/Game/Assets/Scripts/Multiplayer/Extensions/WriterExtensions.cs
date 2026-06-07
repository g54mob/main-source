using System;
using System.Runtime.CompilerServices;
using FishNet.CodeGenerating;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public static class WriterExtensions
	{
		public static PooledWriterDisposableWrapper AsDisposable(this PooledWriter writer)
		{
			return new PooledWriterDisposableWrapper(writer);
		}

		[NotSerializer]
		public static void WriteBitArray(this Writer writer, BitArray bits)
		{
			writer.WriteUInt8Unpacked(bits.Data);
		}

		[NotSerializer]
		public unsafe static void WriteEnum<T>(this Writer writer, T value) where T : unmanaged, Enum
		{
			Type underlyingType = EnumUtility<T>.UnderlyingType;
			if (underlyingType == typeof(byte))
			{
				writer.WriteUInt8Unpacked(*(byte*)(&value));
				return;
			}
			if (underlyingType == typeof(short))
			{
				writer.WriteInt16(*(short*)(&value));
				return;
			}
			if (underlyingType == typeof(int))
			{
				writer.WriteInt32(*(int*)(&value));
				return;
			}
			if (underlyingType == typeof(long))
			{
				writer.WriteInt64(*(long*)(&value));
				return;
			}
			if (underlyingType == typeof(ushort))
			{
				writer.WriteUInt16(*(ushort*)(&value));
				return;
			}
			if (underlyingType == typeof(uint))
			{
				writer.WriteUInt32(*(uint*)(&value));
				return;
			}
			if (underlyingType == typeof(ulong))
			{
				writer.WriteUInt64(*(ulong*)(&value));
				return;
			}
			throw new NotSupportedException("Unable to write enum '" + typeof(T).FullName + "' to Writer. Unsupported underlying type '" + underlyingType.FullName + "'.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static void WriteFloatAsByte(this Writer writer, float value, float min = 0f, float max = 1f)
		{
			byte value2 = (byte)(Mathf.InverseLerp(min, max, value) * 255f);
			writer.WriteUInt8Unpacked(value2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static void WriteFloatAsShort(this Writer writer, float value, float min = 0f, float max = 1f)
		{
			ushort value2 = (ushort)(Mathf.InverseLerp(min, max, value) * 65535f);
			writer.WriteUInt16Unpacked(value2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static void WriteNullableInt32(this Writer writer, int? value, AutoPackType packType = AutoPackType.Packed)
		{
			writer.WriteBoolean(value.HasValue);
			if (value.HasValue)
			{
				if (packType == AutoPackType.Packed)
				{
					writer.WriteSignedPackedWhole(value.Value);
				}
				else
				{
					writer.WriteInt32Unpacked(value.Value);
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static void WriteNullableVector3(this Writer writer, Vector3? value)
		{
			writer.WriteBoolean(value.HasValue);
			if (value.HasValue)
			{
				writer.WriteVector3(value.Value);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static void WriteVector3Short(this Writer writer, Vector3 value, int decimalPlaces = 2)
		{
			decimalPlaces = Mathf.Clamp(decimalPlaces, 0, 5);
			float num = Mathf.Pow(10f, decimalPlaces);
			writer.WriteInt16((short)Mathf.RoundToInt(value.x * num));
			writer.WriteInt16((short)Mathf.RoundToInt(value.y * num));
			writer.WriteInt16((short)Mathf.RoundToInt(value.z * num));
		}
	}
}
