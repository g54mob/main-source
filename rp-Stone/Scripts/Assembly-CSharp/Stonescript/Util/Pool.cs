using System.Collections.Generic;
using UnityEngine;

namespace Stonescript.Util
{
	public class Pool<T>
	{
		public delegate T CreateObject();

		public delegate void ResetObject(T t);

		protected CreateObject Create;

		protected ResetObject Reset;

		protected Stack<T> pool = new Stack<T>();

		protected HashSet<T> managed = new HashSet<T>();

		protected int created;

		protected int reused;

		protected int maxUsed;

		public Pool(CreateObject create, ResetObject reset)
		{
			Create = create;
			Reset = reset;
		}

		public Pool(CreateObject create, ResetObject reset, int initialCapacity)
		{
			Create = create;
			Reset = reset;
			FillTo(initialCapacity);
		}

		protected void FillTo(int count)
		{
			for (int i = pool.Count; i < count; i++)
			{
				T item = Create();
				managed.Add(item);
				created++;
				pool.Push(item);
			}
		}

		public T Get()
		{
			T val;
			if (pool.Count > 0)
			{
				val = pool.Pop();
				reused++;
			}
			else
			{
				val = Create();
				managed.Add(val);
				created++;
			}
			maxUsed = Mathf.Max(maxUsed, managed.Count - pool.Count);
			return val;
		}

		public void Return(T t)
		{
			if (!managed.Contains(t))
			{
				Debug.LogError("An unmanaged object is being returned to the pool.");
			}
			pool.Push(t);
			Reset(t);
		}
	}
}
