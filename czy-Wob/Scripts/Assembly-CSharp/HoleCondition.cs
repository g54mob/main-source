using System;
using UnityEngine;

[Serializable]
public class HoleCondition : TargetConditionBase
{
	public bool requireIsEmpty = true;

	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		bool flag = target.GetComponent<Hole>().GetCurrentHoleStage() == HoleStage.EMPTY;
		return requireIsEmpty == flag;
	}
}
