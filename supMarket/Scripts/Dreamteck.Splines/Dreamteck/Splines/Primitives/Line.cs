namespace Dreamteck.Splines.Primitives
{
	public class Line : SplinePrimitive
	{
		public bool mirror;

		public float length;

		public int segments;

		public override Spline.Type GetSplineType()
		{
			return default(Spline.Type);
		}

		protected override void Generate()
		{
		}
	}
}
