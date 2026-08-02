using System;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace MemoryPack
{
	[StructLayout((LayoutKind)3)]
	public ref struct MemoryPackReader
	{
		private ReadOnlySequence<byte> bufferSource;

		private readonly long totalLength;

		private ReadOnlySpan<byte> bufferReference;

		private int bufferLength;

		private byte[]? rentBuffer;

		private int advancedCount;

		private int consumed;

		private readonly MemoryPackReaderOptionalState optionalState;

		public int Consumed => 0;

		public long Remaining => 0L;

		public MemoryPackReaderOptionalState OptionalState => null;

		public MemoryPackSerializerOptions Options => null;

		public MemoryPackReader(in ReadOnlySequence<byte> sequence, MemoryPackReaderOptionalState optionalState)
		{
			bufferSource = default(ReadOnlySequence<byte>);
			totalLength = 0L;
			bufferReference = default(ReadOnlySpan<byte>);
			bufferLength = 0;
			rentBuffer = null;
			advancedCount = 0;
			consumed = 0;
			this.optionalState = null;
		}

		public MemoryPackReader(ReadOnlySpan<byte> buffer, MemoryPackReaderOptionalState optionalState)
		{
			bufferSource = default(ReadOnlySequence<byte>);
			totalLength = 0L;
			bufferReference = default(ReadOnlySpan<byte>);
			bufferLength = 0;
			rentBuffer = null;
			advancedCount = 0;
			consumed = 0;
			this.optionalState = null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ref byte GetSpanReference(int sizeHint)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private ref byte GetNextSpan(int sizeHint)
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Advance(int count)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private bool TryAdvanceSequence(int count)
		{
			return false;
		}

		public void GetRemainingSource(out ReadOnlySpan<byte> singleSource, out ReadOnlySequence<byte> remainingSource)
		{
			singleSource = default(ReadOnlySpan<byte>);
			remainingSource = default(ReadOnlySequence<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Dispose()
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
		public bool TryReadObjectHeader(out byte memberCount)
		{
			memberCount = default(byte);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryReadUnionHeader(out ushort tag)
		{
			tag = default(ushort);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryReadCollectionHeader(out int length)
		{
			length = default(int);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool PeekIsNull()
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPeekObjectHeader(out byte memberCount)
		{
			memberCount = default(byte);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPeekUnionHeader(out ushort tag)
		{
			tag = default(ushort);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPeekCollectionHeader(out int length)
		{
			length = default(int);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool DangerousTryReadCollectionHeader(out int length)
		{
			length = default(int);
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string? ReadString()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string ReadUtf16(int length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private string ReadUtf8(int utf8Length)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T1 ReadUnmanaged<T1>() where T1 : struct
		{
			return default(T1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadPackable<T>([ScopedRef] ref T? value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T ReadPackable<T>() where T : IMemoryPackable<T>
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue<T>([ScopedRef] ref T? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T? ReadValue<T>()
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValue(Type type, ref object? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public object ReadValue(Type type)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadValueWithFormatter<TFormatter, T>(TFormatter formatter, [ScopedRef] ref T? value) where TFormatter : notnull, IMemoryPackFormatter<T> where T : notnull
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T ReadValueWithFormatter<TFormatter, T>(TFormatter formatter) where TFormatter : notnull, IMemoryPackFormatter<T> where T : notnull
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T?[]? ReadArray<T>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadArray<T>([ScopedRef] ref T?[]? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadSpan<T>([ScopedRef] ref Span<T?> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T[] ReadPackableArray<T>() where T : IMemoryPackable<T>
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadPackableArray<T>([ScopedRef] ref T?[]? value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadPackableSpan<T>([ScopedRef] ref Span<T?> value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T[] ReadUnmanagedArray<T>() where T : struct
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanagedArray<T>([ScopedRef] ref T[]? value) where T : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanagedSpan<T>([ScopedRef] ref Span<T> value) where T : struct
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public T?[]? DangerousReadUnmanagedArray<T>()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanagedArray<T>([ScopedRef] ref T[]? value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanagedSpan<T>([ScopedRef] ref Span<T> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadSpanWithoutReadLengthHeader<T>(int length, [ScopedRef] ref Span<T?> value)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadPackableSpanWithoutReadLengthHeader<T>(int length, [ScopedRef] ref Span<T?> value) where T : IMemoryPackable<T>
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanagedSpanView<T>(out bool isNull, out ReadOnlySpan<byte> view)
		{
			isNull = default(bool);
			view = default(ReadOnlySpan<byte>);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1>(out T1 value1) where T1 : struct
		{
			value1 = default(T1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2>(out T1 value1, out T2 value2) where T1 : struct where T2 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3>(out T1 value1, out T2 value2, out T3 value3) where T1 : struct where T2 : struct where T3 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4>(out T1 value1, out T2 value2, out T3 value3, out T4 value4) where T1 : struct where T2 : struct where T3 : struct where T4 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12, out T13 value13) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
			value13 = default(T13);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12, out T13 value13, out T14 value14) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
			value13 = default(T13);
			value14 = default(T14);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12, out T13 value13, out T14 value14, out T15 value15) where T1 : struct where T2 : struct where T3 : struct where T4 : struct where T5 : struct where T6 : struct where T7 : struct where T8 : struct where T9 : struct where T10 : struct where T11 : struct where T12 : struct where T13 : struct where T14 : struct where T15 : struct
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
			value13 = default(T13);
			value14 = default(T14);
			value15 = default(T15);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1>(out T1 value1) where T1 : notnull
		{
			value1 = default(T1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2>(out T1 value1, out T2 value2) where T1 : notnull where T2 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3>(out T1 value1, out T2 value2, out T3 value3) where T1 : notnull where T2 : notnull where T3 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4>(out T1 value1, out T2 value2, out T3 value3, out T4 value4) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12, out T13 value13) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
			value13 = default(T13);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12, out T13 value13, out T14 value14) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull where T14 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
			value13 = default(T13);
			value14 = default(T14);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void DangerousReadUnmanaged<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(out T1 value1, out T2 value2, out T3 value3, out T4 value4, out T5 value5, out T6 value6, out T7 value7, out T8 value8, out T9 value9, out T10 value10, out T11 value11, out T12 value12, out T13 value13, out T14 value14, out T15 value15) where T1 : notnull where T2 : notnull where T3 : notnull where T4 : notnull where T5 : notnull where T6 : notnull where T7 : notnull where T8 : notnull where T9 : notnull where T10 : notnull where T11 : notnull where T12 : notnull where T13 : notnull where T14 : notnull where T15 : notnull
		{
			value1 = default(T1);
			value2 = default(T2);
			value3 = default(T3);
			value4 = default(T4);
			value5 = default(T5);
			value6 = default(T6);
			value7 = default(T7);
			value8 = default(T8);
			value9 = default(T9);
			value10 = default(T10);
			value11 = default(T11);
			value12 = default(T12);
			value13 = default(T13);
			value14 = default(T14);
			value15 = default(T15);
		}

		public byte ReadVarIntByte()
		{
			return 0;
		}

		public sbyte ReadVarIntSByte()
		{
			return 0;
		}

		public ushort ReadVarIntUInt16()
		{
			return 0;
		}

		public short ReadVarIntInt16()
		{
			return 0;
		}

		public uint ReadVarIntUInt32()
		{
			return 0u;
		}

		public int ReadVarIntInt32()
		{
			return 0;
		}

		public ulong ReadVarIntUInt64()
		{
			return 0uL;
		}

		public long ReadVarIntInt64()
		{
			return 0L;
		}
	}
}
