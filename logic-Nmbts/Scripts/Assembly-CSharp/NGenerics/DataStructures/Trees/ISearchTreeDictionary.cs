using System.Collections;
using System.Collections.Generic;

namespace NGenerics.DataStructures.Trees
{
	public interface ISearchTreeDictionary<TKey, TValue> : ISearchTree<KeyValuePair<TKey, TValue>>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable, IDictionary<TKey, TValue>
	{
	}
}
