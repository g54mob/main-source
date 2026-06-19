using System.Runtime.CompilerServices;
using Unity.Mathematics;

public struct RandomWalkStatePatterData
{
	public WalkStateGoalPatternType goalPatternType;

	public WalkStateMovementPatternType movementPatternType;

	public WalkStateCancelConditionType cancelConditionType;

	public byte patternSteps;

	public float2 minMaxWalkDistance;

	public float movementSpeedMultiplier;

	public float maxWalkDuration;

	public float goalCheckDistanceSqr;

	public float movementPatternGoalFloatValue;

	public float movementPatternGoalFloatValue2;

	public float movementPatternGoalFloatValue3;

	public float movementPatternGoalFloatValue4;

	public int movementPatternGoalIntValue;

	public int movementPatternGoalIntValue2;

	public float movementPatternFloatValue;

	public float movementPatternFloatValue2;

	public float2 minMaxIdleDurationAfterWalking;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly float GetModifiedStartingSteps()
	{
		return movementPatternGoalIntValue;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly float GetModifiedEndingSteps()
	{
		return movementPatternGoalIntValue2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public readonly float GetModifiedWalkDistanceMultiplier()
	{
		return movementPatternGoalFloatValue3;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public float GetModifiedIdleDurationAfterWalkingMultiplier()
	{
		return movementPatternGoalFloatValue4;
	}
}
