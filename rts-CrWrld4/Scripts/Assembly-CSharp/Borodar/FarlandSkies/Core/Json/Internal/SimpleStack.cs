using System.Collections.Generic;

namespace Borodar.FarlandSkies.Core.Json.Internal
{
	internal sealed class SimpleStack<T>
	{
		private readonly List<T> stack;

		public int Count => 0;

		public void Push(T value)
		{
		}

		public T Pop()
		{
			return default(T);
		}

		public T Peek()
		{
			return default(T);
		}
	}
}
