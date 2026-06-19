using System;
using System.Collections.Generic;

[Serializable]
public class BehaviorScoreModifier
{
	public List<DogBehaviorTargetedEnum> modifiedBehaviors = new List<DogBehaviorTargetedEnum>();

	public float finalScoreMultiplier = 1f;
}
