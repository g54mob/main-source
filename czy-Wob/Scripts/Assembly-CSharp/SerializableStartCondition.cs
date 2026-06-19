using System;
using UnityEngine;

[Serializable]
public class SerializableStartCondition
{
	public bool assigned;

	public StartConditionType type;

	public NeedBasedStartCondition needCondition;

	public AgeRequirementStartCondition ageCondition;

	public RequirementBasedStartCondition requirementCondition;

	public CanBuildNewDenInteriorsCondition denInteriorsCondition;

	public FoodPersonalityRequirementStartCondition foodPersonalityRequirementCondition;

	public EnergyPersonalityRequirementStartCondition energyPersonalityRequirementCondition;

	public SocialPersonalityRequirementStartCondition socialPersonalityRequirementCondition;

	public MischiefPersonalityRequirementStartCondition mischiefPersonalityRequirementCondition;

	public LoudnessPersonalityRequirementStartCondition loudnessPersonalityRequirementCondition;

	public bool ConditionMet(GameObject dog)
	{
		return GetConditionForType().ConditionMet(dog);
	}

	private StartConditionBase GetConditionForType()
	{
		switch (type)
		{
		case StartConditionType.REQUIREMENT_CONDITION:
			return requirementCondition;
		case StartConditionType.NEED_CONDITION:
			return needCondition;
		case StartConditionType.FOOD_PERSONALITY_REQUIREMENT:
			return foodPersonalityRequirementCondition;
		case StartConditionType.SOCIAL_PERSONALITY_REQUIREMENT:
			return socialPersonalityRequirementCondition;
		case StartConditionType.ENERGY_PERSONALITY_REQUIREMENT:
			return energyPersonalityRequirementCondition;
		case StartConditionType.MISCHIEF_PERSONALITY_REQUIREMENT:
			return mischiefPersonalityRequirementCondition;
		case StartConditionType.LOUDNESS_PERSONALITY_REQUIREMENT:
			return loudnessPersonalityRequirementCondition;
		case StartConditionType.AGE_CONDITION:
			return ageCondition;
		case StartConditionType.CAN_BUILD_NEW_DEN_INTERIORS:
			return denInteriorsCondition;
		default:
			Debug.LogError("Invalid type: " + type);
			return null;
		}
	}
}
