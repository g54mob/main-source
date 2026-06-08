using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MemoryPack
{
	[StructLayout((LayoutKind)3)]
	public ref struct MemoryPackWriter<TBufferWriter> where TBufferWriter : class, IBufferWriter<byte>
	{
		private const int DepthLimit = 1000;

		private TBufferWriter bufferWriter;

		private Span<byte> bufferReference;

		private int bufferLength;

		private int advancedCount;

		private int depth;

		private int writtenCount;

		private readonly bool serializeStringAsUtf8;

		private readonly MemoryPackWriterOptionalState optionalState;

		public int WrittenCount => 0;

		public int BufferLength => 0;

		public MemoryPackWriterOptionalState OptionalState => null;

		public MemoryPackSerializerOptions Options => null;

		public void WriteVarInt(byte x)
		{
		}

		public void WriteVarInt(sbyte x)
		{
		}

		public void WriteVarInt(ushort x)
		{
		}

		public void WriteVarInt(short x)
		{
		}

		public void WriteVarInt(uint x)
		{
		}

		public void WriteVarInt(int x)
		{
		}

		public void WriteVarInt(ulong x)
		{
		}

		public void WriteVarInt(long x)
		{
		}

		public MemoryPackWriter(ref TBufferWriter writer, MemoryPackWriterOptionalState optionalState)
		{
			bufferWriter = null;
			bufferReference = default(Span<byte>);
			bufferLength = 0;
			advancedCount = 0;
			depth = 0;
			writtenCount = 0;
			serializeStringAsUtf8 = false;
			this.optionalState = null;
		}

		public MemoryPackWriter(ref TBufferWriter writer, byte[] firstBufferOfWriter, MemoryPackWriterOptionalState optionalState)
		{
			bufferWriter = null;
			bufferReference = default(Span<byte>);
			bufferLength = 0;
			advancedCount = 0;
			depth = 0;
			writtenCount = 0;
			serializeStringAsUtf8 = false;
			this.optionalState = null;
		}

		public MemoryPackWriter(ref TBufferWriter writer, Span<byte> firstBufferOfWriter, MemoryPackWriterOptionalState optionalState)
		{
			bufferWriter = null;
			bufferReference = default(Span<byte>);
			bufferLength = 0;
			advancedCount = 0;
			depth = 0;
			writtenCount = 0;
			serializeStringAsUtf8 = false;
			this.optionalState = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref byte GetSpanReference(int sizeHint)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void RequestNewBuffer(int sizeHint)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Flush()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IMemoryPackFormatter GetFormatter(Type type)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public IMemoryPackFormatter<T> GetFormatter<T>() where T : notnull
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetStringWriteLength(string? value)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetUnmanageArrayWriteLength<T>(T[]? value) where T : struct
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteObjectHeader(byte memberCount)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteNullObjectHeader()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteObjectReferenceId(uint referenceId)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnionHeader(ushort tag)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteNullUnionHeader()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteCollectionHeader(int length)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteNullCollectionHeader()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteString(string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUtf16(string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUtf16(ReadOnlySpan<char> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUtf8(string? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUtf8(ReadOnlySpan<byte> utf8Value, int utf16Length = -1)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WritePackable<T>([ScopedRef] in T? value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue<T>([ScopedRef] in T? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValue(Type type, object? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteValueWithFormatter<TFormatter, T>(TFormatter formatter, [ScopedRef] in T? value) where TFormatter : notnull, IMemoryPackFormatter<T> where T : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteArray<T>(T?[]? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteSpan<T>([ScopedRef] Span<T?> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteSpan<T>([ScopedRef] ReadOnlySpan<T?> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WritePackableArray<T>(T?[]? value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WritePackableSpan<T>([ScopedRef] Span<T?> value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WritePackableSpan<T>([ScopedRef] ReadOnlySpan<T?> value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedArray<T>(T[]? value) where T : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedSpan<T>([ScopedRef] Span<T> value) where T : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedSpan<T>([ScopedRef] ReadOnlySpan<T> value) where T : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedArray<T>(T[]? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedSpan<T>([ScopedRef] Span<T> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedSpan<T>([ScopedRef] ReadOnlySpan<T> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteSpanWithoutLengthHeader<T>([ScopedRef] ReadOnlySpan<T?> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1>([ScopedRef] in T1 value1) where T1 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1>(byte propertyCount, [ScopedRef] in T1 value1) where T1 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2) where T1 : struct where T2 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2) where T1 : struct where T2 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3) where T1 : struct where T2 : struct where T3 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3) where T1 : struct where T2 : struct where T3 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4) where T1 : struct where T2 : struct where T3 : struct where T4 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4) where T1 : struct where T2 : struct where T3 : struct where T4 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14, [ScopedRef] in T15 value15) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void WriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14, [ScopedRef] in T15 value15) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1>([ScopedRef] in T1 value1) where T1 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1>(byte propertyCount, [ScopedRef] in T1 value1) where T1 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2) where T1 : notnull where T2 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2) where T1 : notnull where T2 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3) where T1 : notnull where T2 : notnull where T3 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3) where T1 : notnull where T2 : notnull where T3 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull where T14 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull where T14 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>([ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14, [ScopedRef] in T15 value15) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull where T14 : notnull where T15 : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousWriteUnmanagedWithObjectHeader<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(byte propertyCount, [ScopedRef] in T1 value1, [ScopedRef] in T2 value2, [ScopedRef] in T3 value3, [ScopedRef] in T4 value4, [ScopedRef] in T5 value5, [ScopedRef] in T6 value6, [ScopedRef] in T7 value7, [ScopedRef] in T8 value8, [ScopedRef] in T9 value9, [ScopedRef] in T10 value10, [ScopedRef] in T11 value11, [ScopedRef] in T12 value12, [ScopedRef] in T13 value13, [ScopedRef] in T14 value14, [ScopedRef] in T15 value15) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull where T14 : notnull where T15 : notnull
		{
		}
	}
}
