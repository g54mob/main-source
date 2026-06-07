using System;
using System.Collections.Generic;

namespace AwesomeTechnologies.Utility
{
	[Serializable]
	public class ObjectPool<T> where T : new()
	{
		private readonly List<T> _available = new List<T>();

		private readonly List<T> _inUse = new List<T>();

		public T Get()
		{
			lock (_available)
			{
				if (_available.Count != 0)
				{
					T val = _available[0];
					_inUse.Add(val);
					_available.RemoveAt(0);
					return val;
				}
				T val2 = new T();
				_inUse.Add(val2);
				return val2;
			}
		}

		public void Release(T obj)
		{
			CleanUp(obj);
			lock (_available)
			{
				_available.Add(obj);
				_inUse.Remove(obj);
			}
		}

		private void CleanUp(T obj)
		{
		}
	}
}
