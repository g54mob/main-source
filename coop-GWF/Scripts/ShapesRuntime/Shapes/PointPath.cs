using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Shapes
{
	public class PointPath<T> : DisposableMesh
	{
		protected List<T> path = new List<T>();

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
			hasData = true;
			meshDirty = true;
		}

		public void ClearAllPoints()
		{
			path.Clear();
			hasData = false;
		}

		public void SetPoint(int index, T point)
		{
			path[index] = point;
			meshDirty = true;
		}

		public void RemovePointAt(int index)
		{
			int count = path.Count;
			if (index < 0 || index >= count)
			{
				throw new IndexOutOfRangeException();
			}
			path.RemoveAt(index);
			meshDirty = true;
			if (count == 1)
			{
				hasData = false;
			}
		}

		public void AddPoint(T p)
		{
			if (!hasData)
			{
				OnSetFirstDataPoint();
			}
			path.Add(p);
			hasData = true;
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
			if (path.Count - count > 0)
			{
				if (!hasData)
				{
					OnSetFirstDataPoint();
				}
				hasData = true;
				meshDirty = true;
			}
		}

		protected bool CheckCanAddContinuePoint([CallerMemberName] string callerName = null)
		{
			if (!hasData)
			{
				Debug.LogWarning(callerName + " requires adding a point before calling it, to determine starting point");
				return true;
			}
			return false;
		}
	}
}
