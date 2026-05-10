namespace Dreamteck.Splines.Primitives
{
	public class Ngon : SplinePrimitive
	{
		public float radius;

		public int sides;

		public override Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		protected override void Generate()
		{
		}
	}
}
