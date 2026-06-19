using System;
using UnityEngine;

[Serializable]
public class AgeRequirementTargetCondition : TargetConditionBase
{
	public DogAge requiredAge;

	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		if (!target.CompareTag(Tags.DOG))
		{
			return false;
		}
		return requiredAge == target.GetComponent<DoggyBrain>().GetCurrentDogAge();
	}
}
