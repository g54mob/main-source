using System;
using System.Collections.Generic;

[Serializable]
public class SaveableDogEgg
{
	public SaveableDogGene associatedGene;

	public SaveableDogProfile dogProfile;

	public bool emptyGut;

	public List<string> floraPool = new List<string>();

	public bool fertilized;

	public SaveableDogEgg()
	{
	}

	public SaveableDogEgg(SaveableDogGene newGene, SaveableDogProfile newProfile, bool fertilizedStatus, List<string> newFloraPool, bool newEmptyGut)
	{
		dogProfile = newProfile;
		associatedGene = newGene;
		fertilized = fertilizedStatus;
		if (floraPool == null)
		{
			floraPool = new List<string>();
		}
		if (newFloraPool != null)
		{
			floraPool.AddRange(newFloraPool);
		}
		emptyGut = newEmptyGut;
	}

	public SaveableDogEgg GetCopy()
	{
		SaveableDogEgg saveableDogEgg = new SaveableDogEgg();
		saveableDogEgg.associatedGene = associatedGene;
		if (dogProfile != null)
		{
			saveableDogEgg.dogProfile = dogProfile.GetCopy();
		}
		saveableDogEgg.fertilized = fertilized;
		saveableDogEgg.emptyGut = emptyGut;
		if (floraPool != null && floraPool.Count > 0)
		{
			saveableDogEgg.floraPool = new List<string>();
			saveableDogEgg.floraPool.AddRange(floraPool);
		}
		return saveableDogEgg;
	}
}
