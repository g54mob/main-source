using System;
using System.Collections;
using System.Collections.Generic;

namespace Mystery.Graphing
{
	public class LineGraphReader<X, Y> : IEnumerator<LineGraphPoint<X, Y>>, IDisposable, IEnumerator where X : IComparable<X>
	{
		private IEnumerator<LineGraphPoint<X, Y>> enumerator;

		public LineGraphPoint<X, Y> Current => enumerator.Current;

		object IEnumerator.Current => Current;

		public LineGraphReader(LineGraph<X, Y> graph)
		{
			enumerator = graph.GetEnumerator();
		}

		public void Reset()
		{
			enumerator.Reset();
		}

		public void GoTo(X value)
		{
			if (enumerator.Current.ValueX.CompareTo(value) > 0)
			{
				enumerator.Reset();
			}
			while (enumerator.Current.ValueX.CompareTo(value) < 0 && enumerator.MoveNext())
			{
			}
		}

		public void Dispose()
		{
			enumerator.Dispose();
		}

		public bool MoveNext()
		{
			return enumerator.MoveNext();
		}
	}
}
