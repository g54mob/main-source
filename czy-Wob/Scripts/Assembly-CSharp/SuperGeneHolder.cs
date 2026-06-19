public class SuperGeneHolder
{
	private string geneString;

	private int originalLength;

	private float maxValIncrease;

	public SuperGeneHolder(string gene, int length, float newMaxValIncrease)
	{
		geneString = gene;
		originalLength = length;
		maxValIncrease = newMaxValIncrease;
	}

	public string GetGene()
	{
		return geneString;
	}

	public int GetOriginalLength()
	{
		return originalLength;
	}

	public float GetMaxValIncrease()
	{
		return maxValIncrease;
	}
}
