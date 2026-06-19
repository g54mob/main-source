using System;
using UnityEngine;

[Serializable]
public class DominantRecessiveGene
{
	public GeneticVersion version;

	public GeneticDomRecProperty AA;

	public GeneticDomRecProperty Aa;

	public GeneticDomRecProperty aa;

	public TraitType defaultValue;

	private TraitType currentValue;

	public void SetCurrentValue(TraitType newValue)
	{
		currentValue = newValue;
	}

	public TraitType GetCurrentValue()
	{
		return currentValue;
	}

	public GeneticDomRecProperty GetCurrentProperty()
	{
		switch (currentValue)
		{
		case TraitType.HOMO_DOM_AA:
			return AA;
		case TraitType.HET_Aa:
			return Aa;
		case TraitType.HOMO_SUB_aa:
			return aa;
		default:
			Debug.LogError("No return value found for currentValue: " + currentValue);
			return AA;
		}
	}
}
