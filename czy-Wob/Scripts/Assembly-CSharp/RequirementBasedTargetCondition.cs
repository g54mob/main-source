using System;
using UnityEngine;

[Serializable]
public class RequirementBasedTargetCondition : TargetConditionBase
{
	public Requirement requirementType;

	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		DogAI component = target.GetComponent<DogAI>();
		if (component == null)
		{
			Debug.LogError("Attempting to run a requirement-based condition on a non-dog object. This makes no sense.");
			return false;
		}
		return component.RequirementFilled(requirementType);
	}
}
