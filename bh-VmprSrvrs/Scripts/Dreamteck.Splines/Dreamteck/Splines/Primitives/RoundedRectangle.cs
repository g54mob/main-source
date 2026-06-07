using UnityEngine;

namespace Dreamteck.Splines.Primitives
{
	public class RoundedRectangle : SplinePrimitive
	{
		public Vector2 size;

		public float xRadius;

		public float yRadius;

		public override Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		protected override void Generate()
		{
		}
	}
}
