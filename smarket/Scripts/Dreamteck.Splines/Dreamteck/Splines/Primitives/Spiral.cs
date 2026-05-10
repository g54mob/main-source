using UnityEngine;

namespace Dreamteck.Splines.Primitives
{
	public class Spiral : SplinePrimitive
	{
		public float startRadius;

		public float endRadius;

		public float stretch;

		public int iterations;

		public bool clockwise;

		public AnimationCurve curve;

		public override Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		protected override void Generate()
		{
		}
	}
}
