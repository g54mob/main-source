namespace Polygon2DTriangulation
{
	public class TriangulationConstraint : Edge
	{
		private uint mContraintCode;

		public TriangulationPoint P
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TriangulationPoint Q
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public uint ConstraintCode => 0u;

		public TriangulationConstraint(TriangulationPoint p1, TriangulationPoint p2)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void CalculateContraintCode()
		{
		}

		public static uint CalculateContraintCode(TriangulationPoint p, TriangulationPoint q)
		{
			return 0u;
		}
	}
}
