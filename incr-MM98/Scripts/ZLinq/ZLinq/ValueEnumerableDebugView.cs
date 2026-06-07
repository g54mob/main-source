using System.Diagnostics;

namespace ZLinq
{
	internal ref struct ValueEnumerableDebugView<TEnumerator, T> where TEnumerator : struct, IValueEnumerator<T>
	{
		private readonly ValueEnumerable<TEnumerator, T> source;

		private T[]? items;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items
		{
			get
			{
				if (items == null)
				{
					items = source.Take(100000).ToArray();
				}
				return items;
			}
		}

		public ValueEnumerableDebugView(ValueEnumerable<TEnumerator, T> source)
		{
			items = null;
			this.source = source;
		}
	}
}
