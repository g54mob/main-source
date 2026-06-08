using System.Collections.Generic;
using System.Linq;

namespace Moq
{
	internal readonly struct ImmutablePopOnlyStack<T>
	{
		private readonly T[] items;

		private readonly int index;

		public bool Empty => index == items.Length;

		public ImmutablePopOnlyStack(IEnumerable<T> items)
		{
			this.items = items.ToArray();
			index = 0;
		}

		private ImmutablePopOnlyStack(T[] items, int index)
		{
			this.items = items;
			this.index = index;
		}

		public T Pop(out ImmutablePopOnlyStack<T> stackBelowTop)
		{
			T result = items[index];
			stackBelowTop = new ImmutablePopOnlyStack<T>(items, index + 1);
			return result;
		}
	}
}
