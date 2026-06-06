using System;
using System.Collections;
using System.Collections.Generic;

namespace LitMotion
{
	public sealed class CompositeMotionHandle : ICollection<MotionHandle>, IEnumerable<MotionHandle>, IEnumerable
	{
		private readonly List<MotionHandle> handleList;

		public int Count => handleList.Count;

		public bool IsReadOnly => false;

		public CompositeMotionHandle()
		{
			handleList = new List<MotionHandle>();
		}

		public CompositeMotionHandle(int capacity)
		{
			if (capacity < 0)
			{
				throw new ArgumentOutOfRangeException("capacity");
			}
			handleList = new List<MotionHandle>(capacity);
		}

		public void Cancel()
		{
			for (int i = 0; i < handleList.Count; i++)
			{
				MotionHandle handle = handleList[i];
				if (handle.IsActive())
				{
					handle.Cancel();
				}
			}
			handleList.Clear();
		}

		public void Complete()
		{
			for (int i = 0; i < handleList.Count; i++)
			{
				MotionHandle handle = handleList[i];
				if (handle.IsActive())
				{
					handle.Complete();
				}
			}
			handleList.Clear();
		}

		public void Add(MotionHandle handle)
		{
			handleList.Add(handle);
		}

		public List<MotionHandle>.Enumerator GetEnumerator()
		{
			return handleList.GetEnumerator();
		}

		IEnumerator<MotionHandle> IEnumerable<MotionHandle>.GetEnumerator()
		{
			return handleList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return handleList.GetEnumerator();
		}

		public void Clear()
		{
			handleList.Clear();
		}

		public bool Contains(MotionHandle item)
		{
			return handleList.Contains(item);
		}

		public void CopyTo(MotionHandle[] array, int arrayIndex)
		{
			handleList.CopyTo(array, arrayIndex);
		}

		public bool Remove(MotionHandle item)
		{
			return handleList.Remove(item);
		}
	}
}
