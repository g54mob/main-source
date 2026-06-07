using System.Diagnostics;

namespace ZLinq.Linq
{
	internal sealed class GroupingDebugView<TKey, TElement> where TKey : notnull where TElement : notnull
	{
		private readonly Grouping<TKey, TElement> _grouping;

		private TElement[]? _cachedValues;

		public TKey Key => default(TKey);

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public TElement[] Values => null;

		public GroupingDebugView(Grouping<TKey, TElement> grouping)
		{
		}
	}
}
