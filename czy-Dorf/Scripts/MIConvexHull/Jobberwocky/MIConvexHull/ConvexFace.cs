namespace Jobberwocky.MIConvexHull
{
	public abstract class ConvexFace<TVertex, TFace> where TVertex : IVertex where TFace : ConvexFace<TVertex, TFace>
	{
		private TFace[] _003CAdjacency_003Ek__BackingField;

		private TVertex[] _003CVertices_003Ek__BackingField;

		private double[] _003CNormal_003Ek__BackingField;

		public TFace[] Adjacency
		{
			get
			{
				return _003CAdjacency_003Ek__BackingField;
			}
			set
			{
				_003CAdjacency_003Ek__BackingField = value;
			}
		}

		public TVertex[] Vertices
		{
			get
			{
				return _003CVertices_003Ek__BackingField;
			}
			set
			{
				_003CVertices_003Ek__BackingField = value;
			}
		}

		public double[] Normal
		{
			set
			{
				_003CNormal_003Ek__BackingField = value;
			}
		}
	}
}
