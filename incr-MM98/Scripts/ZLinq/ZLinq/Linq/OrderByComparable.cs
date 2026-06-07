using System;
using System.Collections.Generic;

namespace ZLinq.Linq
{
	internal sealed class OrderByComparable<TSource, TKey> : IOrderByComparable<TSource>
	{
		private IComparer<TKey> comparer;

		public OrderByComparable(Func<TSource, TKey> keySelector, IComparer<TKey>? comparer, IOrderByComparable<TSource>? parent, bool descending)
		{
			_003CkeySelector_003EP = keySelector;
			_003Cparent_003EP = parent;
			_003Cdescending_003EP = descending;
			this.comparer = comparer ?? Comparer<TKey>.Default;
			base._002Ector();
		}

		public IOrderByComparer GetComparer(ReadOnlySpan<TSource> source, IOrderByComparer? childComparer)
		{
			OrderByComparer<TSource, TKey> orderByComparer = new OrderByComparer<TSource, TKey>(source, _003CkeySelector_003EP, comparer, childComparer, _003Cdescending_003EP);
			return _003Cparent_003EP?.GetComparer(source, orderByComparer) ?? orderByComparer;
		}
	}
}
