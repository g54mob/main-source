using System;
using UnityEngine;

[Serializable]
public class SerializableTargetCondition
{
	public bool assigned;

	public TargetConditionType type;

	public RequirementBasedTargetCondition requirementCondition;

	public InsideDenCondition insideDenCondition;

	public AgeRequirementTargetCondition ageCondition;

	public NeedBasedTargetCondition needCondition;

	public DenIsEmptyCondition emptyDenCondition;

	public LOSTargetCondition LOSCondition;

	public HoleCondition holeCondition;

	public bool ConditionMet(GameObject mainDog, GameObject target)
	{
		return GetConditionForType().ConditionMet(mainDog, target);
	}

	private TargetConditionBase GetConditionForType()
	{
		switch (type)
		{
		case TargetConditionType.REQUIREMENT_CONDITION:
			return requirementCondition;
		case TargetConditionType.NEED_CONDITION:
			return needCondition;
		case TargetConditionType.WITHIN_CURRENT_LOS:
			return LOSCondition;
		case TargetConditionType.AGE_CONDITION:
			return ageCondition;
		case TargetConditionType.DEN_IS_EMPTY:
			return emptyDenCondition;
		case TargetConditionType.INSIDE_DEN:
			return insideDenCondition;
		case TargetConditionType.HOLE_CONDITION:
			return holeCondition;
		default:
			Debug.LogError("Invalid type: " + type);
			return null;
		}
	}
}
