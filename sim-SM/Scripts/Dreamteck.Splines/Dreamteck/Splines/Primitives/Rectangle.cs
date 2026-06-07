using UnityEngine;

namespace Dreamteck.Splines.Primitives
{
	public class Rectangle : SplinePrimitive
	{
		public Vector2 size;

		public override Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		protected override void Generate()
		{
		}
	}
}
