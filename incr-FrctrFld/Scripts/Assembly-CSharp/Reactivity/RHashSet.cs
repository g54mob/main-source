using System.Collections.Generic;
using Reactivity.Types;

namespace Reactivity
{
	public class RHashSet<T> : Ref<RefHashSet<T>>
	{
		public RHashSet()
		{
		}

		public RHashSet(RefHashSet<T> value)
		{
		}

		public RHashSet(HashSet<T> value)
		{
		}

		public void Changed()
		{
		}
	}
}
