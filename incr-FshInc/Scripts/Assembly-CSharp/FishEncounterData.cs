using System;
using UnityEngine;

[Serializable]
public class FishEncounterData
{
	public Fish fishSpecies;

	[Tooltip("The relative chance (or weight) for this fish to be chosen. A fish with a chance of 10 is twice as likely to appear as one with a chance of 5.")]
	public float encounterWeight;
}
