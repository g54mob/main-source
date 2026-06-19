using System;
using UnityEngine;

[Serializable]
public class RequirementBasedExitCondition : ExitConditionBase
{
	public Requirement requirementType;

	public override bool ConditionMet(GameObject dog)
	{
		return dog.GetComponent<DogAI>().RequirementFilled(requirementType);
	}
}
