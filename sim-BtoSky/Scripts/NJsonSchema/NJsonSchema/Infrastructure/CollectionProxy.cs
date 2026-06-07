using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NJsonSchema.Infrastructure
{
	public class CollectionProxy<TInterface, TImplementation> : ICollection<TInterface>, IEnumerable<TInterface>, IEnumerable where TImplementation : TInterface
	{
		private readonly ICollection<TImplementation> _collection;

		public int Count => _collection.Count;

		public bool IsReadOnly => _collection.IsReadOnly;

		public CollectionProxy(ICollection<TImplementation> collection)
		{
			_collection = collection;
		}

		public IEnumerator<TInterface> GetEnumerator()
		{
			return _collection.OfType<TInterface>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Add(TInterface item)
		{
			_collection.Add((TImplementation)(object)item);
		}

		public void Clear()
		{
			_collection.Clear();
		}

		public bool Contains(TInterface item)
		{
			return _collection.Contains((TImplementation)(object)item);
		}

		public void CopyTo(TInterface[] array, int arrayIndex)
		{
			_collection.CopyTo(array.OfType<TImplementation>().ToArray(), arrayIndex);
		}

		public bool Remove(TInterface item)
		{
			return _collection.Remove((TImplementation)(object)item);
		}
	}
}
