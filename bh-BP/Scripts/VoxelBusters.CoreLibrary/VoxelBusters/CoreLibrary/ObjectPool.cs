using System;
using System.Collections.Generic;

namespace VoxelBusters.CoreLibrary
{
	public class ObjectPool<T> where T : class
	{
		private readonly Stack<T> m_stack;

		private readonly Func<T> m_createFunc;

		private readonly Callback<T> m_actionOnGet;

		private readonly Callback<T> m_actionOnAdd;

		private readonly Callback<T> m_actionOnRelease;

		public int CountAll { get; private set; }

		public int CountActive => 0;

		public int CountInactive => 0;

		public ObjectPool(Func<T> createFunc, Callback<T> actionOnGet = null, Callback<T> actionOnAdd = null, Callback<T> actionOnRelease = null)
		{
		}

		public T Get()
		{
			return null;
		}

		public void Add(T element)
		{
		}

		public void Reset()
		{
		}
	}
}
