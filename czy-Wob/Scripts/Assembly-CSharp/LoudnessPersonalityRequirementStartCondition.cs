using System;
using UnityEngine;

[Serializable]
public class LoudnessPersonalityRequirementStartCondition : StartConditionBase
{
	public LoudnessPersonalityType loudnessRequirement;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DoggyBrain>().GetPersonality().GetLoudnessPersonalityType() == loudnessRequirement;
	}
}
