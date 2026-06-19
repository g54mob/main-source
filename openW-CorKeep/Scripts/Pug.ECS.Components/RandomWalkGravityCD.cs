using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct RandomWalkGravityCD : IComponentData, IQueryTypeParameter
{
	public uint attractMask;

	public float chanceToBeAffectedByGravityWell;

	public float strength;

	public float maxDistanceToBeAffected;

	[Tooltip("The creature will move in a random direction given the maxAngleDeviation from the target direction.")]
	public float maxAngleDeviation;

	[HideInInspector]
	public bool isAffected;

	[HideInInspector]
	public float3 position;

	public float timer;
}
