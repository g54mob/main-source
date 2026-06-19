using System;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkPatternDefinition", menuName = "WalkState/WalkPatternDefinition")]
public class WalkPatternDefinition : ScriptableObject
{
	[Serializable]
	public class BaseMovementProperties
	{
		public Vector2 minMaxWalkDistance;

		public float maxWalkDuration;

		public Vector2 minMaxIdleDurationAfterWalking;

		public float movementSpeedMultiplier = 1f;

		public float goalCheckDistance = 0.707f;
	}

	[Serializable]
	public class ModifiedStepsProperties
	{
		public int modifiedStartingSteps;

		public int modifiedEndingSteps;

		public float modifiedWalkDistanceMultiplier = 1f;

		public float modifiedIdleDurationAfterWalkingMultiplier = 1f;
	}

	public WalkStateGoalPatternType goalPatternType;

	public WalkStateMovementPatternType movementPatternType;

	public WalkStateCancelConditionType cancelConditionType = WalkStateCancelConditionType.All;

	[Header("Pattern Goal Specific")]
	public byte patternGoalSteps = 1;

	[ShowIf("goalPatternType", WalkStateGoalPatternType.CardinalRandom)]
	public PatternRandomSelectionType patternRandomSelectionType;

	[HideIf("goalPatternType", WalkStateGoalPatternType.Default)]
	public Vector2 minMaxStopDistanceFromCollision;

	[HideIf("goalPatternType", WalkStateGoalPatternType.Default)]
	public ModifiedStepsProperties modifiedStepsProperties;

	[Header("Pattern Movement Specific")]
	[HideIf("movementPatternType", WalkStateMovementPatternType.Straight)]
	public float sinusoidalMaxTurnAngleDeg = 45f;

	[HideIf("movementPatternType", WalkStateMovementPatternType.Straight)]
	public float sinusoidalRepeatTimeSeconds = 1f;

	[Header("Base Movement Properties")]
	public bool useAuthoringBehaviourValuesForBaseMovementProperties;

	[HideIf("useAuthoringBehaviourValuesForBaseMovementProperties")]
	public BaseMovementProperties baseMovementProperties;
}
