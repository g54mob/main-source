using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shapes
{
	public class PointPath<T> : DisposableMesh
	{
		protected List<T> path = new List<T>();

		protected bool hasSetFirstPoint;

		public int Count => path.Count;

		public T LastPoint => path[path.Count - 1];

		public T this[int i]
		{
			get
			{
				return path[i];
			}
			set
			{
				path[i] = value;
				meshDirty = true;
			}
		}

		protected void OnSetFirstDataPoint()
		{
			hasSetFirstPoint = true;
			EnsureMeshExists();
		}

		public void ClearAllPoints()
		{
			path.Clear();
			hasSetFirstPoint = false;
		}

		public void SetPoint(int index, T point)
		{
			path[index] = point;
			meshDirty = true;
		}

		public void AddPoint(T p)
		{
			if (!hasSetFirstPoint)
			{
				OnSetFirstDataPoint();
			}
			path.Add(p);
			meshDirty = true;
		}

		public void AddPoints(params T[] pts)
		{
			AddPoints((IEnumerable<T>)pts);
		}

		public void AddPoints(IEnumerable<T> ptsToAdd)
		{
			int count = path.Count;
			path.AddRange(ptsToAdd);
			if (path.Count - count > 0 && !hasSetFirstPoint)
			{
				OnSetFirstDataPoint();
			}
		}

		protected bool CheckCanAddContinuePoint([CallerMemberName] string callerName = null)
		{
			if (!hasSetFirstPoint)
			{
				Debug.LogWarning(callerName + " requires adding a point before calling it, to determine starting point");
				return true;
			}
			return false;
		}
	}
}
