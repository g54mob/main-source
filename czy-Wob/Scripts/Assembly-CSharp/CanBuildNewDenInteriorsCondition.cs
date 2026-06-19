using System;
using UnityEngine;

[Serializable]
public class CanBuildNewDenInteriorsCondition : StartConditionBase
{
	public override bool ConditionMet(GameObject dog)
	{
		return DenInteriorManager.CanBuildNewDenInteriors();
	}
}
