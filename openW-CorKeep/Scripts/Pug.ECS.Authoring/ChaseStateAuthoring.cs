using System.Collections.Generic;
using Unity.Physics.Authoring;
using UnityEngine;

[RequireComponent(typeof(BehaviourTagsAuthoring))]
public class ChaseStateAuthoring : MonoBehaviour
{
	public bool disabled;

	public bool skipVisibilityCheck;

	public float moveSpeedMultiplier;

	public float chaseAtDistance;

	public bool ignoreLowColliders;

	public float preChaseDuration;

	public float endChaseDuration;

	public float idleDuration;

	public float idleCooldown;

	[Header("Behaviour parameters")]
	public float distanceToStartSideStepping;

	public bool distanceToKeepNoiseDisabled;

	public float minDistanceToKeep;

	public float maxDistanceToKeep;

	public float obstacleAvoidDistance;

	public bool preferPathFind;

	public bool neverStopChasing;

	public bool needPathToChase;

	public List<ObjectID> chaseHeldObjects;

	public PhysicsShapeAuthoring belongsToShape;
}
