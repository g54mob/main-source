using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
	internal static class CollectionsMarshal
	{
		private class ListDummy<T>
		{
			public T[] Items;

			private int size;

			private int version;
		}

		internal static Span<T> AsSpan<T>(List<T> list)
		{
			return Unsafe.As<ListDummy<T>>(list).Items.AsSpan(0, list.Count);
		}
	}
}
