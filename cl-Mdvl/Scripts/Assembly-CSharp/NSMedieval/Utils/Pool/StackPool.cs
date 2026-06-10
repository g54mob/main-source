using System.Collections.Generic;
using JetBrains.Annotations;
using NSMedieval.Utils.Pool.Janitors;

namespace NSMedieval.Utils.Pool
{
	public static class StackPool<T>
	{
		private const int AllocationBatchSize = 10;

		private static readonly Stack<Stack<T>> Pool = new Stack<Stack<T>>();

		[MustDisposeResource]
		public static PooledStack<T> GetJanitor()
		{
			return new PooledStack<T>(Get());
		}

		public static Stack<T> Get()
		{
			lock (Pool)
			{
				if (Pool.Count > 0)
				{
					return Pool.Pop();
				}
				for (int i = 1; i < 10; i++)
				{
					Pool.Push(new Stack<T>());
				}
			}
			return new Stack<T>();
		}

		public static void Return(Stack<T> stack)
		{
			if (stack == null)
			{
				return;
			}
			stack.Clear();
			lock (Pool)
			{
				Pool.Push(stack);
			}
		}
	}
}
