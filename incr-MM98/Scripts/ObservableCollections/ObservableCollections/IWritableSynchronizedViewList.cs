using System;
using System.Collections;
using System.Collections.Generic;

namespace ObservableCollections
{
	public interface IWritableSynchronizedViewList<TView> : ISynchronizedViewList<TView>, IReadOnlyList<TView>, IEnumerable<TView>, IEnumerable, IReadOnlyCollection<TView>, IDisposable
	{
		new TView this[int index] { get; set; }
	}
}
