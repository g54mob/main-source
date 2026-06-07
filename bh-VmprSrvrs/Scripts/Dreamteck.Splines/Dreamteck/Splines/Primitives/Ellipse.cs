namespace Dreamteck.Splines.Primitives
{
	public class Ellipse : SplinePrimitive
	{
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
