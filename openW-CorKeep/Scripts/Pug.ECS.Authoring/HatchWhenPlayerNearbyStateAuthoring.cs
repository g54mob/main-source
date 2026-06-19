using Pug.UnityExtensions;
using UnityEngine;

public class HatchWhenPlayerNearbyStateAuthoring : MonoBehaviour
{
	public ThreadSafeTimerSimple timer;

	public float timeToHatch;

	public int internalState;

	public ObjectID objectToSpawn;

	public int minSpawnAmount;

	public int maxSpawnAmount;

	public bool hatchAnimationIsPlaying;
}
