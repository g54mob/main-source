using System;
using UnityEngine;

[Serializable]
public class RequirementBasedStartCondition : StartConditionBase
{
	public Requirement requirementType;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DogAI>().RequirementFilled(requirementType);
	}
}
