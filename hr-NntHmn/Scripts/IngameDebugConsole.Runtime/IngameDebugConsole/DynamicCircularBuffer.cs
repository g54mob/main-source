using System;

namespace IngameDebugConsole
{
	public class DynamicCircularBuffer<T>
	{
		private T[] array;

		private int startIndex;

		public int Count { get; private set; }

		public int Capacity => 0;

		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public DynamicCircularBuffer(int initialCapacity = 2)
		{
		}

		private void SetCapacity(int capacity)
		{
		}

		public void AddFirst(T value)
		{
		}

		public void Add(T value)
		{
		}

		public void AddRange(DynamicCircularBuffer<T> other)
		{
		}

		public T RemoveFirst()
		{
			return default(T);
		}

		public T RemoveLast()
		{
			return default(T);
		}

		public int RemoveAll(Predicate<T> shouldRemoveElement)
		{
			return 0;
		}

		public int RemoveAll<Y>(Predicate<T> shouldRemoveElement, Action<T, int> onElementIndexChanged, DynamicCircularBuffer<Y> synchronizedBuffer)
		{
			return 0;
		}

		public void TrimStart(int trimCount, Action<T> perElementCallback = null)
		{
		}

		public void TrimEnd(int trimCount, Action<T> perElementCallback = null)
		{
		}

		private void TrimInternal(int trimCount, int startIndex, Action<T> perElementCallback)
		{
		}

		public void Clear()
		{
		}

		public int IndexOf(T value)
		{
			return 0;
		}

		public void ForEach(Action<T> action)
		{
		}
	}
}
