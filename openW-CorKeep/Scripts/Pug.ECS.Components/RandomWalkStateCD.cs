using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct RandomWalkStateCD : IComponentData, IQueryTypeParameter
{
	public enum State
	{
		Idle = 0,
		Walking = 1
	}

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple durationTimer;

	public ThreadSafeTimerSimple walkedIntoWallTimer;

	public State internalState;

	public float2 target;

	public float movementSpeedMultiplier;

	[HideInInspector]
	public bool isNewStateTrigger;

	public sbyte patternGroupIndex;

	public sbyte patternIndex;

	public byte patternProgress;

	public byte patternGoalByteValue;

	public byte patternMovementByteValue;
}
