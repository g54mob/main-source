using UnityEngine;

public class TargetConditionBase
{
	public virtual bool ConditionMet(GameObject mainDog, GameObject target)
	{
		return false;
	}
}
