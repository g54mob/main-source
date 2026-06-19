using System;
using UnityEngine;

[Serializable]
public class InsideDenCondition : TargetConditionBase
{
	public bool requireNotInDen;

	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		bool flag = false;
		if (DenInteriorManager.GetUIDForDenObjectIsInsideOf(target).HasValue)
		{
			flag = true;
		}
		if (requireNotInDen)
		{
			return !flag;
		}
		return flag;
	}
}
