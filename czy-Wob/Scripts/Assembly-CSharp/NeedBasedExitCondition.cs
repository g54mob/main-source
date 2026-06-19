using System;
using UnityEngine;

[Serializable]
public class NeedBasedExitCondition : ExitConditionBase
{
	public Need need;

	public ComparisonOperator comparison;

	public float value;

	public static string[] GetComparisonStrings()
	{
		return new string[5] { "<", ">", "<=", ">=", "=" };
	}

	public override bool ConditionMet(GameObject dog)
	{
		float percentageValueForNeed = dog.GetComponent<DoggyBrain>().GetPercentageValueForNeed(need);
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
