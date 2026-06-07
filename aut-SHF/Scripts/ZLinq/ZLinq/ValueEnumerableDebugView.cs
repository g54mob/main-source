using System.Diagnostics;

namespace ZLinq
{
	internal ref struct ValueEnumerableDebugView<TEnumerator, T> where TEnumerator : struct, IValueEnumerator<T> where T : notnull
	{
		private readonly ValueEnumerable<TEnumerator, T> source;

		private T[]? items;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items => null;

		public ValueEnumerableDebugView(ValueEnumerable<TEnumerator, T> source)
		{
			this.source = default(ValueEnumerable<TEnumerator, T>);
			items = null;
		}
	}
}
