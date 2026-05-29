using System;
using System.Runtime.CompilerServices;

namespace Cysharp.Threading.Tasks.Internal
{
	internal sealed class PooledDelegate<T> : ITaskPoolNode<PooledDelegate<T>>
	{
		private static TaskPool<PooledDelegate<T>> pool;

		private PooledDelegate<T> nextNode;

		private readonly Action<T> runDelegate;

		private Action continuation;

		public ref PooledDelegate<T> NextNode
		{
			get
			{
				throw null;
			}
		}

		static PooledDelegate()
		{
		}

		private PooledDelegate()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Action<T> Create(Action continuation)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Run(T _)
		{
		}
	}
}
