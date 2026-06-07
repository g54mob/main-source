using System.Collections.Generic;
using Reactivity.Types;

namespace Reactivity
{
	public class RDictionary<TKey, TValue> : Ref<RefDictionary<TKey, TValue>>
	{
		public RDictionary()
		{
		}

		public RDictionary(RefDictionary<TKey, TValue> value)
		{
		}

		public RDictionary(Dictionary<TKey, TValue> value)
		{
		}

		public void Changed()
		{
		}
	}
}
