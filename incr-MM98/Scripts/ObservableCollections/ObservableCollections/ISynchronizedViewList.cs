using System;
using System.Collections;
using System.Collections.Generic;

namespace ObservableCollections
{
	public interface ISynchronizedViewList<out TView> : IReadOnlyList<TView>, IEnumerable<TView>, IEnumerable, IReadOnlyCollection<TView>, IDisposable
	{
	}
}
