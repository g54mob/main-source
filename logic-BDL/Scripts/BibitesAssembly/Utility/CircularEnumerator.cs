using System;
using System.Collections;
using System.Collections.Generic;

namespace Utility
{
	public class CircularEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
	{
		private CircularBuffer<T> buffer;

		private int pos = -1;

		private int size;

		public T Current => buffer[pos];

		object IEnumerator.Current => Current;

		public CircularEnumerator(CircularBuffer<T> buffer)
		{
			this.buffer = buffer;
		}

		public bool MoveNext()
		{
			pos++;
			return pos < buffer.n;
		}

		public void Reset()
		{
			pos = -1;
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
