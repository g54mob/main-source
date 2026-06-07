using System;
using System.Collections.Generic;
using System.Threading;

namespace Gh
{
	public static class ListPoolX
	{
		private static class ThreadLocalPool<T>
		{
			public static readonly ThreadLocal<Stack<DisposablePooledList<T>>> pool;
		}

		public class DisposablePooledList<T> : List<T>, IDisposable
		{
			public DisposablePooledList(int capacity)
			{
			}

			public void Dispose()
			{
			}

			private void ClearFast()
			{
			}
		}

		private static Stack<DisposablePooledList<T>> GetPool<T>()
		{
			return null;
		}

		private static void AddBackToPool<T>(DisposablePooledList<T> list)
		{
		}

		private static DisposablePooledList<T> GetList<T>()
		{
			return null;
		}

		public static DisposablePooledList<T> ToPooledDisposableList<T>(this IEnumerable<T> enumerable)
		{
			return null;
		}

		public static DisposablePooledList<T> GetPooledDisposableList<T>()
		{
			return null;
		}
	}
}
