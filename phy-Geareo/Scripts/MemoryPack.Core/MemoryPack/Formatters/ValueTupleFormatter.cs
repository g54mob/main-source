using System;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class ValueTupleFormatter<T1> : MemoryPackFormatter<ValueTuple<T1?>> where T1 : notnull
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ValueTuple<T1?> value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ValueTuple<T1?> value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2> : MemoryPackFormatter<(T1?, T2?)>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref (T1?, T2?) value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref (T1?, T2?) value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2, T3> : MemoryPackFormatter<(T1?, T2?, T3?)>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref (T1?, T2?, T3?) value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref (T1?, T2?, T3?) value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2, T3, T4> : MemoryPackFormatter<(T1?, T2?, T3?, T4?)>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref (T1?, T2?, T3?, T4?) value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref (T1?, T2?, T3?, T4?) value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2, T3, T4, T5> : MemoryPackFormatter<(T1?, T2?, T3?, T4?, T5?)>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref (T1?, T2?, T3?, T4?, T5?) value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref (T1?, T2?, T3?, T4?, T5?) value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2, T3, T4, T5, T6> : MemoryPackFormatter<(T1?, T2?, T3?, T4?, T5?, T6?)>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref (T1?, T2?, T3?, T4?, T5?, T6?) value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref (T1?, T2?, T3?, T4?, T5?, T6?) value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2, T3, T4, T5, T6, T7> : MemoryPackFormatter<(T1?, T2?, T3?, T4?, T5?, T6?, T7?)>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref (T1?, T2?, T3?, T4?, T5?, T6?, T7?) value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref (T1?, T2?, T3?, T4?, T5?, T6?, T7?) value)
		{
		}
	}
	[Preserve]
	public sealed class ValueTupleFormatter<T1, T2, T3, T4, T5, T6, T7, TRest> : MemoryPackFormatter<ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest>> where TRest : struct
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest> value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref ValueTuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest> value)
		{
		}
	}
}
