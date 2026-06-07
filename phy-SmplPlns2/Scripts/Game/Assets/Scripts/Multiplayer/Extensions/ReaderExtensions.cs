using System;
using System.Runtime.CompilerServices;
using FishNet.CodeGenerating;
using FishNet.Serializing;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.Extensions
{
	public static class ReaderExtensions
	{
		public static PooledReaderDisposableWrapper AsDisposable(this PooledReader reader)
		{
			return new PooledReaderDisposableWrapper(reader);
		}

		[NotSerializer]
		public static BitArray ReadBitArray(this Reader reader)
		{
			return new BitArray(reader.ReadUInt8Unpacked());
		}

		[NotSerializer]
		public unsafe static T ReadEnum<T>(this Reader reader) where T : unmanaged, Enum
		{
			Type underlyingType = EnumUtility<T>.UnderlyingType;
			if (underlyingType == typeof(byte))
			{
				byte b = reader.ReadUInt8Unpacked();
				return *(T*)(&b);
			}
			if (underlyingType == typeof(short))
			{
				short num = reader.ReadInt16();
				return *(T*)(&num);
			}
			if (underlyingType == typeof(int))
			{
				int num2 = reader.ReadInt32();
				return *(T*)(&num2);
			}
			if (underlyingType == typeof(long))
			{
				long num3 = reader.ReadInt64();
				return *(T*)(&num3);
			}
			if (underlyingType == typeof(ushort))
			{
				ushort num4 = reader.ReadUInt16();
				return *(T*)(&num4);
			}
			if (underlyingType == typeof(uint))
			{
				uint num5 = reader.ReadUInt32();
				return *(T*)(&num5);
			}
			if (underlyingType == typeof(ulong))
			{
				ulong num6 = reader.ReadUInt64();
				return *(T*)(&num6);
			}
			throw new NotSupportedException("Unable to read enum '" + typeof(T).FullName + "' from Reader. Unsupported underlying type '" + underlyingType.FullName + "'.");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static float ReadFloatAsByte(this Reader reader, float min = 0f, float max = 1f)
		{
			float t = (float)(int)reader.ReadUInt8Unpacked() / 255f;
			return Mathf.Lerp(min, max, t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static float ReadFloatAsShort(this Reader reader, float min = 0f, float max = 1f)
		{
			float t = (float)(int)reader.ReadUInt16Unpacked() / 65535f;
			return Mathf.Lerp(min, max, t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static int? ReadNullableInt32(this Reader reader, AutoPackType packType = AutoPackType.Packed)
		{
			if (reader.ReadBoolean())
			{
				return (packType == AutoPackType.Packed) ? reader.ReadInt32() : reader.ReadInt32Unpacked();
			}
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static Vector3? ReadNullableVector3(this Reader reader)
		{
			if (!reader.ReadBoolean())
			{
				return null;
			}
			return reader.ReadVector3();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[NotSerializer]
		public static Vector3 ReadVector3Short(this Reader reader, int decimalPlaces = 2)
		{
			decimalPlaces = Mathf.Clamp(decimalPlaces, 0, 5);
			float num = Mathf.Pow(10f, decimalPlaces);
			return new Vector3((float)reader.ReadInt16() / num, (float)reader.ReadInt16() / num, (float)reader.ReadInt16() / num);
		}
	}
}
