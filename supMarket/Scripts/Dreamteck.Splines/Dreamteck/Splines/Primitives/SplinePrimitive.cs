using UnityEngine;

namespace Dreamteck.Splines.Primitives
{
	public class SplinePrimitive
	{
		protected bool closed;

		protected SplinePoint[] points;

		public Vector3 offset;

		public Vector3 rotation;

		public bool is2D;

		public virtual void Calculate()
		{
		}

		protected virtual void Generate()
		{
		}

		public Spline CreateSpline()
		{
			return null;
		}

		public void UpdateSpline(Spline spline)
		{
		}

		public SplineComputer CreateSplineComputer(string name, Vector3 position, Quaternion rotation)
		{
			return null;
		}

		public void UpdateSplineComputer(SplineComputer comp)
		{
		}

		public SplinePoint[] GetPoints()
		{
			return null;
		}

		public virtual Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		public bool GetIsClosed()
		{
			return false;
		}

		private void ApplyOffset()
		{
		}

		protected void CreatePoints(int count, SplinePoint.Type type)
		{
		}
	}
}
