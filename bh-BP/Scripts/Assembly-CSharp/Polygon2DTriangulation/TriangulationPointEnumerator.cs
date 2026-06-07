using System;
using System.Collections;
using System.Collections.Generic;

namespace Polygon2DTriangulation
{
	public class TriangulationPointEnumerator : IEnumerator<TriangulationPoint>, IEnumerator, IDisposable
	{
		protected IList<Point2D> mPoints;

		protected int position;

		object IEnumerator.Current => null;

		public TriangulationPoint Current => null;

		public TriangulationPointEnumerator(IList<Point2D> points)
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
