using System;
using UnityEngine;

[Serializable]
public class FoodPersonalityRequirementStartCondition : StartConditionBase
{
	public FoodPersonalityType foodRequirement;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DoggyBrain>().GetPersonality().GetFoodPersonality() == foodRequirement;
	}
}
