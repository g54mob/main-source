using System;
using System.Collections;
using System.Collections.Generic;

namespace MiscUtil.Collections
{
	public static class SmartEnumerable
	{
		public static SmartEnumerable<T> Create<T>(IEnumerable<T> source)
		{
			return new SmartEnumerable<T>(source);
		}
	}
	public class SmartEnumerable<T> : IEnumerable<SmartEnumerable<T>.Entry>, IEnumerable
	{
		public class Entry
		{
			private readonly bool isFirst;

			private readonly bool isLast;

			private readonly T value;

			private readonly int index;

			public T Value => value;

			public bool IsFirst => isFirst;

			public bool IsLast => isLast;

			public int Index => index;

			internal Entry(bool isFirst, bool isLast, T value, int index)
			{
				this.isFirst = isFirst;
				this.isLast = isLast;
				this.value = value;
				this.index = index;
			}
		}

		private readonly IEnumerable<T> enumerable;

		public SmartEnumerable(IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException("enumerable");
			}
			this.enumerable = enumerable;
		}

		public IEnumerator<Entry> GetEnumerator()
		{
			using (IEnumerator<T> enumerator = enumerable.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					bool isFirst = true;
					bool isLast = false;
					int index = 0;
					while (!isLast)
					{
						T current = enumerator.Current;
						isLast = !enumerator.MoveNext();
						yield return new Entry(isFirst, isLast, current, index++);
						isFirst = false;
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
