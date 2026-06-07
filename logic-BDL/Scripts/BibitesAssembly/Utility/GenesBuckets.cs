using SimulationScripts.BibiteScripts;

namespace Utility
{
	public struct GenesBuckets
	{
		public GenesBucketPoint[] data;

		public GenesBucketPoint this[int i]
		{
			get
			{
				return data[i];
			}
			set
			{
				data[i] = value;
			}
		}

		public GenesBuckets(BibiteGenes[] genes)
		{
			int nGene = BibiteGenes.NGene;
			data = new GenesBucketPoint[nGene];
			for (int i = 0; i < nGene; i++)
			{
				data[i] = new GenesBucketPoint(genes, i);
			}
		}

		public GenesBuckets(int n)
		{
			data = new GenesBucketPoint[n];
			for (int i = 0; i < n; i++)
			{
				data[i] = new GenesBucketPoint(i);
			}
		}
	}
}
