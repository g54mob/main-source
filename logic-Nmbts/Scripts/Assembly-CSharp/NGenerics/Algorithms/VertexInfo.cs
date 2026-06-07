using NGenerics.DataStructures.General;

namespace NGenerics.Algorithms
{
	internal class VertexInfo<T>
	{
		public double Distance { get; set; }

		public Edge<T> EdgeFollowed { get; set; }

		public bool IsFinalised { get; set; }

		public VertexInfo(double distance, Edge<T> edgeFollowed, bool isFinalised)
		{
			Distance = distance;
			EdgeFollowed = edgeFollowed;
			IsFinalised = isFinalised;
		}
	}
}
