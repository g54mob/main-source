using System;
using UnityEngine;

[Serializable]
public class SocialPersonalityRequirementStartCondition : StartConditionBase
{
	public SocialPersonalityType socialRequirement;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DoggyBrain>().GetPersonality().GetSocialPersonality() == socialRequirement;
	}
}
