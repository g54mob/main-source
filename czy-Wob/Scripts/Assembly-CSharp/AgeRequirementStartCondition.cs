using System;
using UnityEngine;

[Serializable]
public class AgeRequirementStartCondition : StartConditionBase
{
	public DogAge requiredAge;

	public override bool ConditionMet(GameObject dog)
	{
		return requiredAge == dog.GetComponent<DoggyBrain>().GetCurrentDogAge();
	}
}
