using Unity.Mathematics;
using UnityEngine;

public class RandomWalkGravityAuthoring : MonoBehaviour
{
	public uint attractMask;

	public float chanceToBeAffectedByGravityWell;

	public float strength;

	public float maxDistanceToBeAffected;

	public float maxAngleDeviation;

	public bool isAffected;

	public float3 position;

	public float timer;
}
