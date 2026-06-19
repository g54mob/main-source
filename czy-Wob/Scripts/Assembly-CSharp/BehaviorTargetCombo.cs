using UnityEngine;

public struct BehaviorTargetCombo
{
	public GameObject target;

	public DogBehaviorBase behavior;

	public BehaviorTargetCombo(DogBehaviorBase behavior, GameObject target)
	{
		this.target = target;
		this.behavior = behavior;
	}
}
