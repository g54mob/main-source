using Pug.UnityExtensions;
using Unity.Entities;
using UnityEngine;

public struct HatchWhenPlayerNearbyStateCD : IComponentData, IQueryTypeParameter
{
	public ThreadSafeTimerSimple timer;

	public float timeToHatch;

	public int internalState;

	public ObjectID objectToSpawn;

	public int minSpawnAmount;

	public int maxSpawnAmount;

	[HideInInspector]
	public bool hatchAnimationIsPlaying;
}
