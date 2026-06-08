namespace Jobberwocky.MIConvexHull
{
	public class VoronoiEdge<TVertex, TCell> where TVertex : IVertex where TCell : TriangulationCell<TVertex, TCell>
	{
		private TCell _003CSource_003Ek__BackingField;

		private TCell _003CTarget_003Ek__BackingField;

		public TCell Source
		{
			get
			{
				return _003CSource_003Ek__BackingField;
			}
			internal set
			{
				_003CSource_003Ek__BackingField = value;
			}
		}

		public TCell Target
		{
			get
			{
				return _003CTarget_003Ek__BackingField;
			}
			internal set
			{
				_003CTarget_003Ek__BackingField = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (!(obj is VoronoiEdge<TVertex, TCell> voronoiEdge))
			{
				return false;
			}
			if (this == voronoiEdge)
			{
				return true;
			}
			return (Source == voronoiEdge.Source && Target == voronoiEdge.Target) || (Source == voronoiEdge.Target && Target == voronoiEdge.Source);
		}

		public override int GetHashCode()
		{
			int num = 23;
			num = num * 31 + Source.GetHashCode();
			return num * 31 + Target.GetHashCode();
		}
	}
}
