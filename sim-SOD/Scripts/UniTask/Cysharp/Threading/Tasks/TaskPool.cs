using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Cysharp.Threading.Tasks
{
	public static class TaskPool
	{
		internal static int MaxPoolSize;

		private static Dictionary<Type, Func<int>> sizes;

		static TaskPool()
		{
		}

		public static void RegisterSizeGetter(Type type, Func<int> getSize)
		{
		}
	}
	[StructLayout((LayoutKind)3)]
	public struct TaskPool<T> where T : class, ITaskPoolNode<T>
	{
		private int gate;

		private int size;

		private T root;

		public int Size => 0;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPop(out T result)
		{
			result = null;
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryPush(T item)
		{
			return false;
		}
	}
}
