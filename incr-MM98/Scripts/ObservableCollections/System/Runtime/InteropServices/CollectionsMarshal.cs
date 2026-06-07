using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
	internal static class CollectionsMarshal
	{
		internal sealed class ListView<T>
		{
			public T[] _items;

			public int _size;

			public int _version;
		}

		public static Span<T> AsSpan<T>(List<T>? list)
		{
			if (list == null)
			{
				return default(Span<T>);
			}
			ref ListView<T> reference = ref Unsafe.As<List<T>, ListView<T>>(ref list);
			return reference._items.AsSpan(0, reference._size);
		}
	}
}
