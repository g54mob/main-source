using System;
using UnityEngine;

[Serializable]
public class MischiefPersonalityRequirementStartCondition : StartConditionBase
{
	public MischiefPersonalityType mischiefRequirement;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DoggyBrain>().GetPersonality().GetMischiefPersonality() == mischiefRequirement;
	}
}
