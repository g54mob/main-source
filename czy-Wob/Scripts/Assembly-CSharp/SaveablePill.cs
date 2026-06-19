using System;

[Serializable]
public class SaveablePill
{
	private string newGene;

	public SaveablePill(string geneString)
	{
		newGene = geneString;
	}

	public SaveablePill(Pill p)
	{
		newGene = p.newGene;
	}

	public void Load(Pill p)
	{
		p.newGene = newGene;
	}

	public SaveablePill GetCopy()
	{
		return new SaveablePill(newGene);
	}
}
