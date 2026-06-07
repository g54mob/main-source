namespace Noesis
{
	public class PointHitTestParameters : HitTestParameters
	{
		private Point _hitPoint;

		public Point HitPoint => default(Point);

		public PointHitTestParameters(Point point)
		{
		}
	}
}
