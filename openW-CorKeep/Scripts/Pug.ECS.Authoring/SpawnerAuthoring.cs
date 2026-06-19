using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
	public float minSpawnDistance;

	public float maxSpawnDistance;

	public int maxNumberSpawned;

	public float forgetWhenThisFarAway;

	public int2 lastPosition;

	public bool disableSpawnWhenStationary;
}
