using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterDefaults
{
	[SerializeField]
	private List<string> names;

	[SerializeField]
	private List<string> incapables;

	[SerializeField]
	private List<string> backgrounds;

	[SerializeField]
	private List<string> perks;

	public List<string> Names => names;

	public List<string> Incapables => incapables;

	public List<string> Backgrounds => backgrounds;

	public List<string> Perks => perks;

	public void SetNames(List<string> val)
	{
		names = val;
	}

	public void SetIncapables(List<string> val)
	{
		incapables = val;
	}

	public void SetBackgrounds(List<string> val)
	{
		backgrounds = val;
	}

	public void SetPerks(List<string> val)
	{
		perks = val;
	}
}
