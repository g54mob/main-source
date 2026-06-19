using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct SpotShapeEnumerator : ShapeEnumerator, IEnumerator<int2>, IEnumerator, IDisposable
	{
		private bool hasMoved;

		public int2 Current { get; }

		object IEnumerator.Current => Current;

		public SpotShapeEnumerator(int2 position)
		{
			hasMoved = false;
			Current = position;
		}

		public bool MoveNext()
		{
			if (hasMoved)
			{
				return false;
			}
			hasMoved = true;
			return true;
		}

		public void Reset()
		{
			hasMoved = false;
		}

		public void Dispose()
		{
		}
	}
}
