using System;
using UnityEngine;

[Serializable]
public class SaveableDogGene
{
	public string dogGene = "";

	public string domRecGene = "";

	[HideInInspector]
	public string dogGeneEncoded = "";

	[HideInInspector]
	public string domRecGeneEncoded = "";

	[HideInInspector]
	public string puppyCode = "";

	[HideInInspector]
	public string childCode = "";

	[HideInInspector]
	public string teenCode = "";

	[HideInInspector]
	public string youngAdultCode = "";

	public GeneticVersion geneVersion;

	public SerializableDictionary<string, int> dynamicLoopPropertiesCounter;

	public SaveableDogGene GetCopy()
	{
		SaveableDogGene saveableDogGene = new SaveableDogGene();
		saveableDogGene.dogGene = dogGene;
		saveableDogGene.domRecGene = domRecGene;
		saveableDogGene.dogGeneEncoded = dogGeneEncoded;
		saveableDogGene.domRecGeneEncoded = domRecGeneEncoded;
		saveableDogGene.puppyCode = puppyCode;
		saveableDogGene.childCode = childCode;
		saveableDogGene.teenCode = teenCode;
		saveableDogGene.youngAdultCode = youngAdultCode;
		saveableDogGene.geneVersion = geneVersion;
		if (dynamicLoopPropertiesCounter != null)
		{
			saveableDogGene.dynamicLoopPropertiesCounter = dynamicLoopPropertiesCounter.GetCopy();
		}
		return saveableDogGene;
	}
}
