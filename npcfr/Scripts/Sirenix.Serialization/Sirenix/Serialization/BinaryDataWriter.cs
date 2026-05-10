using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Sirenix.Serialization
{
	public class BinaryDataWriter : BaseDataWriter
	{
		private struct Struct256Bit
		{
			public decimal d1;

			public decimal d2;
		}

		[StructLayout((LayoutKind)2, Size = 8)]
		private struct SixtyFourBitValueToByteUnion
		{
			[FieldOffset(0)]
			public byte b0;

			[FieldOffset(1)]
			public byte b1;

			[FieldOffset(2)]
			public byte b2;

			[FieldOffset(3)]
			public byte b3;

			[FieldOffset(4)]
			public byte b4;

			[FieldOffset(5)]
			public byte b5;

			[FieldOffset(6)]
			public byte b6;

			[FieldOffset(7)]
			public byte b7;

			[FieldOffset(0)]
			public double doubleValue;

			[FieldOffset(0)]
			public ulong ulongValue;

			[FieldOffset(0)]
			public long longValue;
		}

		[StructLayout((LayoutKind)2, Size = 16)]
		private struct OneTwentyEightBitValueToByteUnion
		{
			[FieldOffset(0)]
			public byte b0;

			[FieldOffset(1)]
			public byte b1;

			[FieldOffset(2)]
			public byte b2;

			[FieldOffset(3)]
			public byte b3;

			[FieldOffset(4)]
			public byte b4;

			[FieldOffset(5)]
			public byte b5;

			[FieldOffset(6)]
			public byte b6;

			[FieldOffset(7)]
			public byte b7;

			[FieldOffset(8)]
			public byte b8;

			[FieldOffset(9)]
			public byte b9;

			[FieldOffset(10)]
			public byte b10;

			[FieldOffset(11)]
			public byte b11;

			[FieldOffset(12)]
			public byte b12;

			[FieldOffset(13)]
			public byte b13;

			[FieldOffset(14)]
			public byte b14;

			[FieldOffset(15)]
			public byte b15;

			[FieldOffset(0)]
			public Guid guidValue;

			[FieldOffset(0)]
			public decimal decimalValue;
		}

		private static readonly Dictionary<Type, Delegate> PrimitiveGetBytesMethods;

		private static readonly Dictionary<Type, int> PrimitiveSizes;

		private readonly byte[] small_buffer;

		private readonly byte[] buffer;

		private int bufferIndex;

		private readonly Dictionary<Type, int> types;

		public bool CompressStringsTo8BitWhenPossible;

		private static readonly Dictionary<Type, Action<BinaryDataWriter, object>> PrimitiveArrayWriters;

		public BinaryDataWriter()
			: base(null, null)
		{
		}

		public BinaryDataWriter(Stream stream, SerializationContext context)
			: base(null, null)
		{
		}

		public override void BeginArrayNode(long length)
		{
		}

		public override void BeginReferenceNode(string name, Type type, int id)
		{
		}

		public override void BeginStructNode(string name, Type type)
		{
		}

		public override void Dispose()
		{
		}

		public override void EndArrayNode()
		{
		}

		public override void EndNode(string name)
		{
		}

		private static void WritePrimitiveArray_byte(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_sbyte(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_bool(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_char(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_short(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_int(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_long(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_ushort(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_uint(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_ulong(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_decimal(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_float(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_double(BinaryDataWriter writer, object o)
		{
		}

		private static void WritePrimitiveArray_Guid(BinaryDataWriter writer, object o)
		{
		}

		public override void WritePrimitiveArray<T>(T[] array)
		{
		}

		public override void WriteBoolean(string name, bool value)
		{
		}

		public override void WriteByte(string name, byte value)
		{
		}

		public override void WriteChar(string name, char value)
		{
		}

		public override void WriteDecimal(string name, decimal value)
		{
		}

		public override void WriteDouble(string name, double value)
		{
		}

		public override void WriteGuid(string name, Guid value)
		{
		}

		public override void WriteExternalReference(string name, Guid guid)
		{
		}

		public override void WriteExternalReference(string name, int index)
		{
		}

		public override void WriteExternalReference(string name, string id)
		{
		}

		public override void WriteInt32(string name, int value)
		{
		}

		public override void WriteInt64(string name, long value)
		{
		}

		public override void WriteNull(string name)
		{
		}

		public override void WriteInternalReference(string name, int id)
		{
		}

		public override void WriteSByte(string name, sbyte value)
		{
		}

		public override void WriteInt16(string name, short value)
		{
		}

		public override void WriteSingle(string name, float value)
		{
		}

		public override void WriteString(string name, string value)
		{
		}

		public override void WriteUInt32(string name, uint value)
		{
		}

		public override void WriteUInt64(string name, ulong value)
		{
		}

		public override void WriteUInt16(string name, ushort value)
		{
		}

		public override void PrepareNewSerializationSession()
		{
		}

		public override string GetDataDump()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void WriteType(Type type)
		{
		}

		private void WriteStringFast(string value)
		{
		}

		public override void FlushToStream()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UNSAFE_WriteToBuffer_2_Char(char value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UNSAFE_WriteToBuffer_2_Int16(short value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UNSAFE_WriteToBuffer_2_UInt16(ushort value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UNSAFE_WriteToBuffer_4_Int32(int value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UNSAFE_WriteToBuffer_4_UInt32(uint value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void UNSAFE_WriteToBuffer_4_Float32(float value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UNSAFE_WriteToBuffer_8_Int64(long value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UNSAFE_WriteToBuffer_8_UInt64(ulong value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UNSAFE_WriteToBuffer_8_Float64(double value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UNSAFE_WriteToBuffer_16_Decimal(decimal value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void UNSAFE_WriteToBuffer_16_Guid(Guid value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void EnsureBufferSpace(int space)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private bool TryEnsureBufferSpace(int space)
		{
			return false;
		}
	}
}
