using System;
using System.Collections;
using System.Collections.Generic;

namespace Poly2Tri.Utility
{
	public struct FixedArray3<T> : IEnumerable<T>, IEnumerable where T : IEquatable<T>
	{
		public T Item0;

		public T Item1;

		public T Item2;

		public T this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return Item0;
				case 1:
					return Item1;
				case 2:
					return Item2;
				default:
					throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
				case 0:
					Item0 = value;
					break;
				case 1:
					Item1 = value;
					break;
				case 2:
					Item2 = value;
					break;
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		public bool Contains(T value)
		{
			return IndexOf(value) != -1;
		}

		public int IndexOf(T value)
		{
			for (int i = 0; i < 3; i++)
			{
				if (!this[i].Equals(default(T)) && this[i].Equals(value))
				{
					return i;
				}
			}
			return -1;
		}

		public void Clear()
		{
			Item0 = (Item1 = (Item2 = default(T)));
		}

		public void Clear(T value)
		{
			for (int i = 0; i < 3; i++)
			{
				if (this[i].Equals(default(T)) && this[i].Equals(value))
				{
					this[i] = default(T);
				}
			}
		}

		private IEnumerable<T> Enumerate()
		{
			int i = 0;
			while (i < 3)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Enumerate().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
