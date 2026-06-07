using System.Collections.Generic;

namespace Jundroo.Common.Pool
{
	public class DictionaryPool<TKey, TValue> : CollectionPool<Dictionary<TKey, TValue>, KeyValuePair<TKey, TValue>>
	{
	}
}
