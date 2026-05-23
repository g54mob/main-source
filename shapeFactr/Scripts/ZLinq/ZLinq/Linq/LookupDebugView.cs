using System.Diagnostics;
using System.Linq;

namespace ZLinq.Linq
{
	internal sealed class LookupDebugView<TKey, TElement> where TKey : notnull where TElement : notnull
	{
		private readonly ILookup<TKey, TElement> _lookup;

		private IGrouping<TKey, TElement>[]? _cachedGroupings;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public IGrouping<TKey, TElement>[] Groupings => null;

		public LookupDebugView(ILookup<TKey, TElement> lookup)
		{
		}
	}
}
