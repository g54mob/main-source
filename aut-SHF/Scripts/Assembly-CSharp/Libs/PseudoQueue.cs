using System;
using System.Collections.Generic;

namespace Libs
{
	public class PseudoQueue<T>
	{
		private struct Unit
		{
			public long Index;

			public T Data;
		}

		private long _writeIndex;

		private long _readIndex;

		private readonly List<Unit> _units;

		public int Count => 0;

		public void Add(T[] ary)
		{
		}

		public T[] GetNewData()
		{
			return null;
		}

		public int CountNewData(Func<T, bool> condition)
		{
			return 0;
		}

		public void GC()
		{
		}
	}
}
