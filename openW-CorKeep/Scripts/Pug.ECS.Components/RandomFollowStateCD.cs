using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct RandomFollowStateCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectToFollow;

	public float minDistanceFromObjectToFollow;

	public float maxDistanceFromObjectToFollow;

	public float maxWalkDuration;

	public float minIdleDuration;

	public float maxIdleDuration;

	public ThreadSafeTimerSimple cooldownTimer;

	public ThreadSafeTimerSimple durationTimer;

	public int internalState;

	public float3 goal;

	[HideInInspector]
	public bool replayAnimation;

	public ThreadSafeTimerSimple walkedIntoWallTimer;

	public float currentGravityStrength;

	public bool isDisabled;
}
