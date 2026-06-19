using System;
using UnityEngine;

[Serializable]
public class EnergyPersonalityRequirementStartCondition : StartConditionBase
{
	public EnergyPersonalityType energyRequirement;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DoggyBrain>().GetPersonality().GetEnergyPersonality() == energyRequirement;
	}
}
