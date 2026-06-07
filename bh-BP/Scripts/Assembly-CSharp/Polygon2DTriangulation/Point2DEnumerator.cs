using System;
using System.Collections;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class Point2DEnumerator : IEnumerator<Point2D>, IEnumerator, IDisposable
	{
		protected IList<Point2D> mPoints;

		protected int position;

		object IEnumerator.Current => null;

		public Point2D Current => null;

		public Point2DEnumerator(IList<Point2D> points)
		{
		}

		public bool MoveNext()
		{
			return false;
		}

		public void Reset()
		{
		}

		void IDisposable.Dispose()
		{
		}
	}
}
