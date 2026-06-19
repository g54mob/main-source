using System;
using UnityEngine;

[Serializable]
public class NeedBasedTargetCondition : TargetConditionBase
{
	public Need need;

	public ComparisonOperator comparison;

	public float value;

	public static string[] GetComparisonStrings()
	{
		return new string[5] { "<", ">", "<=", ">=", "=" };
	}

	public override bool ConditionMet(GameObject mainDog, GameObject target)
	{
		DoggyBrain component = target.GetComponent<DoggyBrain>();
		if (component == null)
		{
			Debug.LogError("Attempting to run a need-based condition on a non-dog object. This makes no sense.");
			return false;
		}
		float percentageValueForNeed = component.GetPercentageValueForNeed(need);
		switch (comparison)
		{
		case ComparisonOperator.LESS_THAN:
			return percentageValueForNeed < value;
		case ComparisonOperator.GREATER_THAN:
			return percentageValueForNeed > value;
		case ComparisonOperator.LESS_THAN_OR_EQUAL_TO:
			return percentageValueForNeed <= value;
		case ComparisonOperator.GREATER_THAN_OR_EQUAL_TO:
			return percentageValueForNeed >= value;
		case ComparisonOperator.EQUAL_TO:
			return percentageValueForNeed == value;
		default:
			Debug.LogError("Invalid comparison operator.");
			return false;
		}
	}
}
