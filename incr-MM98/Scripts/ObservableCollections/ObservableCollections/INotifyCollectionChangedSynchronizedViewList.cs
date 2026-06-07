using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ObservableCollections
{
	public interface INotifyCollectionChangedSynchronizedViewList<TView> : IList<TView>, ICollection<TView>, IEnumerable<TView>, IEnumerable, IList, ICollection, ISynchronizedViewList<TView>, IReadOnlyList<TView>, IReadOnlyCollection<TView>, IDisposable, INotifyCollectionChanged, INotifyPropertyChanged
	{
	}
}
