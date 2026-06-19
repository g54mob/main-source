using UnityEngine;

public class RandomWalkStateAuthoring : MonoBehaviour
{
	public float minWalkDistance = 0.5f;

	public float maxWalkDistance = 2f;

	public float maxWalkDuration = 3f;

	public float minIdleDuration = 0.5f;

	public float maxIdleDuration = 1f;

	public float movementSpeedMultiplier = 1f;

	public bool overrideUseAuthoringBehaviourValuesForAllPatternBaseMovementProperties;

	public WalkPatternBehaviourDefinition walkPatternBehaviourDefinition;

	public const float goalCheckDistance = 0.707f;
}
