using UnityEngine;

namespace Coherence.Interpolation
{
	public class SplineInterpolator : Interpolator
	{
		private enum CurveType
		{
			Uniform = 0,
			Centripetal = 1,
			Chordal = 2
		}

		[SerializeField]
		private CurveType curveType;

		[SerializeField]
		[Range(0f, 1f)]
		private float tension;

		private float Alpha => 0f;

		public override int NumberOfSamplesToStayBehind => 0;

		public override float InterpolateFloat(float p0, float p1, float p2, float p3, float t)
		{
			return 0f;
		}

		public override double InterpolateDouble(double p0, double p1, double p2, double p3, float t)
		{
			return 0.0;
		}

		public override Vector2 InterpolateVector2(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, float t)
		{
			return default(Vector2);
		}

		public override Vector3 InterpolateVector3(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
		{
			return default(Vector3);
		}
	}
}
