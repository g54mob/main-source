using System.Collections.Generic;

namespace tripolygon.UModeler
{
	public class Partitions
	{
		public List<Edge> positives = new List<Edge>();

		public List<Edge> negatives = new List<Edge>();

		public List<Edge> coPositive = new List<Edge>();

		public List<Edge> coNegative = new List<Edge>();

		public void Join(Partitions partitions)
		{
			positives.AddRange(partitions.positives);
			negatives.AddRange(partitions.negatives);
			coPositive.AddRange(partitions.coPositive);
			coNegative.AddRange(partitions.coNegative);
		}
	}
}
