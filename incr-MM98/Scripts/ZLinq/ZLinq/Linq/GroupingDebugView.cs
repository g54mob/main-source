using System.Diagnostics;
using System.Linq;

namespace ZLinq.Linq
{
	internal sealed class GroupingDebugView<TKey, TElement>
	{
		private readonly Grouping<TKey, TElement> _grouping;

		private TElement[]? _cachedValues;

		public TKey Key => _grouping.Key;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public TElement[] Values => _cachedValues ?? (_cachedValues = _grouping.ToArray());

		public GroupingDebugView(Grouping<TKey, TElement> grouping)
		{
			_grouping = grouping;
		}
	}
}
