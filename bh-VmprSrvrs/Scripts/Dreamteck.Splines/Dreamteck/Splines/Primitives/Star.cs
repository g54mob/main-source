namespace Dreamteck.Splines.Primitives
{
	public class Star : SplinePrimitive
	{
		public float radius;

		public float depth;

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
