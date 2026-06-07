using System.Collections;
using System.Collections.Generic;

namespace ObservableCollections
{
	public interface IReadOnlyObservableList<T> : IReadOnlyList<T>, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T>, IObservableCollection<T>
	{
	}
}
