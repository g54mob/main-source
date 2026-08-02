using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace MemoryPack.Formatters
{
	internal static class _003CInterfaceCollectionFormatters_003EF478309AC02E0CD98622198B385B6F053DFAAF2230226997191D7F9B18EAA1A30__InterfaceCollectionFormatterUtils
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TrySerializeOptimized<TBufferWriter, TCollection, TElement>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef][NotNullWhen(false)] ref TCollection? value) where TBufferWriter : class, IBufferWriter<byte> where TCollection : notnull, IEnumerable<TElement> where TElement : notnull
		{
			return false;
		}

		public static void SerializeCollection<TBufferWriter, TCollection, TElement>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref TCollection? value) where TBufferWriter : class, IBufferWriter<byte> where TCollection : notnull, ICollection<TElement> where TElement : notnull
		{
		}

		public static void SerializeReadOnlyCollection<TBufferWriter, TCollection, TElement>(ref MemoryPackWriter<TBufferWriter> writer, [ScopedRef] ref TCollection? value) where TBufferWriter : class, IBufferWriter<byte> where TCollection : notnull, IReadOnlyCollection<TElement> where TElement : notnull
		{
		}

		public static List<T?>? ReadList<T>(ref MemoryPackReader reader)
		{
			return null;
		}
	}
}
