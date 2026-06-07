using System;
using System.Collections;
using System.Collections.Generic;

namespace Utility
{
	public class CircularBuffer<T> : IEnumerable<T>, IEnumerable
	{
		public int size;

		public T[] buffer;

		public int index0;

		public int n;

		public T this[int index]
		{
			get
			{
				return buffer[RealI(index)];
			}
			set
			{
				buffer[RealI(index)] = value;
			}
		}

		public int RealI(int i)
		{
			return (index0 + i) % size;
		}

		public CircularBuffer(int size)
		{
			this.size = size;
			buffer = new T[size];
		}

		public void Push(T val)
		{
			index0--;
			if (index0 < 0)
			{
				index0 = size - 1;
			}
			if (n < size)
			{
				n++;
			}
			buffer[index0] = val;
		}

		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
