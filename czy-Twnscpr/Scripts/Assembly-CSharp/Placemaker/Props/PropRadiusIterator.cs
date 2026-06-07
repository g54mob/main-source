using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Props
{
	public struct PropRadiusIterator<T> : IEnumerator<T>, IEnumerator, IDisposable, IEnumerable<T>, IEnumerable where T : Component
	{
		private PropPlacer propPlacer;

		private float sqRadius;

		private Vector3 pos;

		private int x;

		private int y;

		private int z;

		private int i;

		private List<PropCollider> propColliders;

		private int3 min;

		private int3 max;

		private T current;

		T IEnumerator<T>.Current => null;

		object IEnumerator.Current => null;

		public PropRadiusIterator(Vector3 pos, float radius, PropPlacer propPlacer)
		{
			this.propPlacer = null;
			sqRadius = 0f;
			this.pos = default(Vector3);
			x = 0;
			y = 0;
			z = 0;
			i = 0;
			propColliders = null;
			min = default(int3);
			max = default(int3);
			current = null;
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			return false;
		}

		void IDisposable.Dispose()
		{
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		void IEnumerator.Reset()
		{
		}
	}
}
