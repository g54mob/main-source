using System;
using UnityEngine;

[DisallowMultipleComponent]
public class OctopusBossAuthoring : MonoBehaviour
{
	[Serializable]
	public struct SpawnConfiguration
	{
		public float durationUntilSpawn;

		public float durationAfterSpawn;

		public float minCooldown;

		public float maxCooldown;
	}

	public float appearDuration;

	public float durationBeforeStartingToSpawnTentacles;

	public float durationBeforeLeaveTentacleSpawnState;

	public SpawnConfiguration tentacleSpawn;
}
