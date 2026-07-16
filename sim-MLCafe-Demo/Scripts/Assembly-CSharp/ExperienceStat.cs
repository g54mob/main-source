using System;

[Serializable]
public class ExperienceStat
{
	public string name;

	public int value;

	public int experiencePerUnit = 1;

	public int gainedXP => value * experiencePerUnit;
}
