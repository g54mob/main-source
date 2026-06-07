using System.Collections;
using System.Collections.Generic;

namespace NGenerics.DataStructures.General
{
	public interface IBag<T> : ICollection<T>, IEnumerable<T>, IEnumerable, IEnumerable<KeyValuePair<T, int>>
	{
		int this[T item] { get; }

		void Add(T item, int amount);

		IBag<T> Subtract(IBag<T> bag);

		IBag<T> Intersection(IBag<T> bag);

		bool Remove(T item, int maximum);

		IBag<T> Union(IBag<T> bag);

		IEnumerator<KeyValuePair<T, int>> GetCountEnumerator();
	}
}
