using System;
using System.Collections.Generic;

namespace Coherence.Toolkit
{
	public class CoherenceObjectPool<T> : IDisposable where T : class
	{
		private readonly Stack<T> objectStack;

		private readonly Func<T> createFunc;

		private readonly Func<T, bool> onGet;

		private readonly Action<T> onRelease;

		private readonly Action<T> onDestroy;

		private readonly int maxSize;

		private bool collectionCheck;

		public int CountAll { get; private set; }

		public int CountActive => 0;

		public int CountInactive => 0;

		public CoherenceObjectPool(Func<T> createFunc, Func<T, bool> actionOnGet = null, Action<T> actionOnRelease = null, Action<T> actionOnDestroy = null, bool collectionCheck = true, int maxSize = 10000)
		{
		}

		public void ForceGet(T instance)
		{
		}

		public T Get()
		{
			return null;
		}

		public void Release(T element)
		{
		}

		public void Clear()
		{
		}

		public void Dispose()
		{
		}

		private T GetObjectFromStackOrCreate()
		{
			return null;
		}
	}
}
