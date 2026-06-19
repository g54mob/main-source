using System;
using UnityEngine;

[Serializable]
public class LOSTargetCondition : TargetConditionBase
{
	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		return mainDog.GetComponent<DogAI>().CanRaycastToObject(target);
	}
}
