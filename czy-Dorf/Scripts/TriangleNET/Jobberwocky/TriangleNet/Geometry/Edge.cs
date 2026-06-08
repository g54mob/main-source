namespace Jobberwocky.TriangleNet.Geometry
{
	public class Edge : IEdge
	{
		private int _003CP0_003Ek__BackingField;

		private int _003CP1_003Ek__BackingField;

		private int _003CLabel_003Ek__BackingField;

		public int P0
		{
			get
			{
				return _003CP0_003Ek__BackingField;
			}
			private set
			{
				_003CP0_003Ek__BackingField = value;
			}
		}

		public int P1
		{
			get
			{
				return _003CP1_003Ek__BackingField;
			}
			private set
			{
				_003CP1_003Ek__BackingField = value;
			}
		}

		public int Label
		{
			get
			{
				return _003CLabel_003Ek__BackingField;
			}
			private set
			{
				_003CLabel_003Ek__BackingField = value;
			}
		}

		public Edge(int p0, int p1)
			: this(p0, p1, 0)
		{
		}

		public Edge(int p0, int p1, int label)
		{
			P0 = p0;
			P1 = p1;
			Label = label;
		}
	}
}
