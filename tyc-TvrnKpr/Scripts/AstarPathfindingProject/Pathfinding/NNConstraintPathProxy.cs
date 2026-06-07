namespace Pathfinding
{
	public class NNConstraintPathProxy
	{
		private readonly Path path;

		private readonly int pathID;

		public GraphMask graphMask
		{
			get
			{
				return default(GraphMask);
			}
			set
			{
			}
		}

		public int tags
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public DistanceMetric distanceMetric
		{
			get
			{
				return default(DistanceMetric);
			}
			set
			{
			}
		}

		internal NNConstraintPathProxy(Path path)
		{
		}

		private void Validate()
		{
		}
	}
}
