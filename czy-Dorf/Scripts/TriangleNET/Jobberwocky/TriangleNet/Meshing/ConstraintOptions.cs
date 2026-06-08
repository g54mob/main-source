namespace Jobberwocky.TriangleNet.Meshing
{
	public class ConstraintOptions
	{
		private bool _003CConformingDelaunay_003Ek__BackingField;

		private bool _003CConvex_003Ek__BackingField;

		private int _003CSegmentSplitting_003Ek__BackingField;

		public bool ConformingDelaunay
		{
			get
			{
				return _003CConformingDelaunay_003Ek__BackingField;
			}
			set
			{
				_003CConformingDelaunay_003Ek__BackingField = value;
			}
		}

		public bool Convex
		{
			get
			{
				return _003CConvex_003Ek__BackingField;
			}
			set
			{
				_003CConvex_003Ek__BackingField = value;
			}
		}

		public int SegmentSplitting => _003CSegmentSplitting_003Ek__BackingField;
	}
}
