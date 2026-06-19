using System;
using UnityEngine;

[Serializable]
public class CustomExitCondition : ExitConditionBase
{
	public override bool ConditionMet(GameObject dog)
	{
		return false;
	}
}
