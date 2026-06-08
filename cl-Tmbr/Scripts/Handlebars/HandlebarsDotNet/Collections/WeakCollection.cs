using System;
using System.Collections;
using System.Collections.Generic;

namespace HandlebarsDotNet.Collections
{
	public class WeakCollection<T> : IEnumerable<T>, IEnumerable where T : class
	{
		private readonly List<WeakReference<T>> _store = new List<WeakReference<T>>();

		private int _firstAvailableIndex;

		public int Size => _store.Count;

		public void Add(T value)
		{
			for (int i = _firstAvailableIndex; i < _store.Count; i++)
			{
				if (_store[i] == null)
				{
					_firstAvailableIndex = i + 1;
					_store[i] = new WeakReference<T>(value);
					return;
				}
				if (!_store[i].TryGetTarget(out var _))
				{
					_firstAvailableIndex = i + 1;
					_store[i].SetTarget(value);
					return;
				}
			}
			_store.Add(new WeakReference<T>(value));
			_firstAvailableIndex = _store.Count;
		}

		public void Remove(T value)
		{
			for (int i = 0; i < _store.Count; i++)
			{
				T target;
				if (_store[i] == null)
				{
					_firstAvailableIndex = Math.Min(_firstAvailableIndex, i);
				}
				else if (!_store[i].TryGetTarget(out target))
				{
					_firstAvailableIndex = Math.Min(_firstAvailableIndex, i);
				}
				else if (target.Equals(value))
				{
					_store[i] = null;
					_firstAvailableIndex = Math.Min(_firstAvailableIndex, i);
					break;
				}
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int index = 0; index < _store.Count; index++)
			{
				WeakReference<T> weakReference = _store[index];
				T target;
				if (weakReference == null)
				{
					_firstAvailableIndex = Math.Min(_firstAvailableIndex, index);
				}
				else if (!weakReference.TryGetTarget(out target))
				{
					_firstAvailableIndex = Math.Min(_firstAvailableIndex, index);
				}
				else
				{
					yield return target;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
