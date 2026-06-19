using UnityEngine;

public class LoopedGeneHolder
{
	private string geneString;

	private int length;

	private bool discrete;

	private int counter;

	public LoopedGeneHolder(string gene, int newLen, bool isDiscrete)
	{
		geneString = gene;
		length = newLen;
		discrete = isDiscrete;
		counter = 0;
	}

	public bool IsDiscrete()
	{
		return discrete;
	}

	public string GetRawGene()
	{
		return geneString;
	}

	public string GetGene()
	{
		string text = geneString.Substring(counter, length);
		counter += length;
		if (counter >= geneString.Length)
		{
			counter = 0;
		}
		if (text.Length < length)
		{
			Debug.LogError("Invalid use of looped genes.");
		}
		return text;
	}

	public int GetLoopLength()
	{
		return length;
	}

	public int GetTotalLength()
	{
		return geneString.Length;
	}
}
