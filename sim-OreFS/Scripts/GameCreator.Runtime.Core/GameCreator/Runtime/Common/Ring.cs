using System;
using System.Collections.Generic;

namespace GameCreator.Runtime.Common
{
	public class Ring<T>
	{
		public T[] Buffer { get; }

		public int Length => Buffer.Length;

		public int Index { get; protected set; }

		public Ring()
		{
			Buffer = Array.Empty<T>();
			Index = 0;
		}

		public Ring(int capacity)
		{
			Buffer = new T[capacity];
		}

		public Ring(IReadOnlyList<T> array)
			: this(array.Count)
		{
			for (int i = 0; i < array.Count; i++)
			{
				Buffer[i] = array[i];
			}
		}

		public Ring(List<T> list)
			: this(list.Count)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				Buffer[i] = list[i];
			}
		}

		public Ring(params T[] array)
			: this(array.Length)
		{
			for (int i = 0; i < array.Length; i++)
			{
				Buffer[i] = array[i];
			}
		}

		public Ring(IEnumerable<T> collection)
			: this(new List<T>(collection))
		{
		}

		public void Update(Action<T> action)
		{
			for (int i = 0; i < Length; i++)
			{
				action(Buffer[i]);
			}
		}

		public void Reset()
		{
			Index = 0;
		}

		public T Current()
		{
			return Buffer[Index];
		}

		public T Next()
		{
			Index = ((++Index < Length) ? Index : 0);
			return Current();
		}

		public T Previous()
		{
			Index = ((--Index < 0) ? (Length - 1) : Index);
			return Current();
		}
	}
}
