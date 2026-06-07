using System;
using System.Collections.Generic;

[Serializable]
public class NUMBERSSGOUP
{
	public List<NGU> skills = new List<NGU>();

	public List<NGU> magicSkills = new List<NGU>();

	public bool autoAdvance;

	public bool disabled;

	public int size()
	{
		return 11;
	}

	public int NGUEnergySize()
	{
		return 9;
	}

	public int NGUMagicSize()
	{
		return 7;
	}

	public NUMBERSSGOUP()
	{
		for (int i = 0; i < size(); i++)
		{
			skills.Add(new NGU());
		}
		for (int j = 0; j < size(); j++)
		{
			magicSkills.Add(new NGU());
		}
		autoAdvance = false;
		disabled = false;
	}

	public void checkNGU()
	{
		if (skills == null)
		{
			skills = new List<NGU>();
		}
		while (skills.Count < size())
		{
			skills.Add(new NGU());
		}
		if (magicSkills == null)
		{
			magicSkills = new List<NGU>();
		}
		while (magicSkills.Count < size())
		{
			magicSkills.Add(new NGU());
		}
	}
}
