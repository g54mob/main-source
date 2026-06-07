using System.Collections.Generic;
using Reactivity.Types;

namespace Reactivity
{
	public class RList<T> : Ref<RefList<T>>
	{
		public RList(RefList<T> value)
		{
		}

		public RList(List<T> value)
		{
		}

		public RList()
		{
		}

		public void Changed()
		{
		}
	}
}
