using System;
using System.Runtime.CompilerServices;
using MemoryPack.Internal;

namespace MemoryPack.Formatters
{
	[Preserve]
	public sealed class TupleFormatter<T1> : MemoryPackFormatter<Tuple<T1?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2> : MemoryPackFormatter<Tuple<T1?, T2?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2, T3> : MemoryPackFormatter<Tuple<T1?, T2?, T3?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?, T3?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?, T3?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2, T3, T4> : MemoryPackFormatter<Tuple<T1?, T2?, T3?, T4?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2, T3, T4, T5> : MemoryPackFormatter<Tuple<T1?, T2?, T3?, T4?, T5?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2, T3, T4, T5, T6> : MemoryPackFormatter<Tuple<T1?, T2?, T3?, T4?, T5?, T6?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?, T6?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?, T6?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2, T3, T4, T5, T6, T7> : MemoryPackFormatter<Tuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?>? value)
		{
		}
	}
	[Preserve]
	public sealed class TupleFormatter<T1, T2, T3, T4, T5, T6, T7, TRest> : MemoryPackFormatter<Tuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest>>
	{
		[Preserve]
		public override void Serialize<TBufferWriter>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest>? value)
		{
		}

		[Preserve]
		public override void Deserialize(ref MemoryPackReader reader, [ScopedRef] ref Tuple<T1?, T2?, T3?, T4?, T5?, T6?, T7?, TRest>? value)
		{
		}
	}
}
