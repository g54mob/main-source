using System.Diagnostics;
using System.Linq;

namespace ZLinq.Linq
{
	internal sealed class LookupDebugView<TKey, TElement>
	{
		private readonly ILookup<TKey, TElement> _lookup;

		private IGrouping<TKey, TElement>[]? _cachedGroupings;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public IGrouping<TKey, TElement>[] Groupings => _cachedGroupings ?? (_cachedGroupings = _lookup.ToArray());

		public LookupDebugView(ILookup<TKey, TElement> lookup)
		{
			_lookup = lookup;
		}
	}
}
