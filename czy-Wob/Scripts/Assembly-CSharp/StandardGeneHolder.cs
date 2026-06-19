public class StandardGeneHolder
{
	private string geneString;

	public StandardGeneHolder(string gene)
	{
		geneString = gene;
	}

	public void UpdateGene(string newValue)
	{
		geneString = newValue;
	}

	public string GetGeneString()
	{
		return geneString;
	}
}
