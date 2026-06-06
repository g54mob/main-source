using System;
using System.ComponentModel;

namespace ZLinq.Linq
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IOrderByComparable<TSource>
	{
		IOrderByComparer GetComparer(ReadOnlySpan<TSource> source, IOrderByComparer? childComparer);
	}
}
