namespace Dreamteck.Splines.Primitives
{
	public class Capsule : SplinePrimitive
	{
		public float radius;

		public float height;

		public override Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		protected override void Generate()
		{
		}
	}
}
