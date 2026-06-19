using System;
using UnityEngine;

[Serializable]
public class DenIsEmptyCondition : TargetConditionBase
{
	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		DogDen component = target.GetComponent<DogDen>();
		if (component == null)
		{
			Debug.LogError("Attempting to check if a den is empty, but the target of this behavior is not a den. " + target);
			return false;
		}
		if (component.IsEmpty())
		{
			return component.IsCompleted();
		}
		return false;
	}
}
