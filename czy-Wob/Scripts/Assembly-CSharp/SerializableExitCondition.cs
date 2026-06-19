using System;
using UnityEngine;

[Serializable]
public class SerializableExitCondition
{
	public bool assigned;

	public ExitConditionType type;

	public TimeBasedExitCondition timeCondition;

	public RandomTimeBasedExitCondition randomTimeCondition;

	public RequirementBasedExitCondition requirementsCondition;

	public CustomExitCondition customCondition;

	public NeedBasedExitCondition needCondition;

	public void ResetCondition()
	{
		GetConditionForType().ResetCondition();
	}

	public void UpdateCondition()
	{
		GetConditionForType().UpdateCondition();
	}

	public bool ConditionMet(GameObject dog)
	{
		return GetConditionForType().ConditionMet(dog);
	}

	private ExitConditionBase GetConditionForType()
	{
		switch (type)
		{
		case ExitConditionType.TIME:
			return timeCondition;
		case ExitConditionType.RANDOM_TIME:
			return randomTimeCondition;
		case ExitConditionType.REQUIREMENT:
			return requirementsCondition;
		case ExitConditionType.CUSTOM:
			return customCondition;
		case ExitConditionType.NEED_CONDITION:
			return needCondition;
		default:
			Debug.LogError("Invalid type: " + type);
			return null;
		}
	}
}
