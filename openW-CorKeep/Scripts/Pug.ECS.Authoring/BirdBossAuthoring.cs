using System;
using UnityEngine;

[DisallowMultipleComponent]
public class BirdBossAuthoring : MonoBehaviour
{
	[Serializable]
	public struct SpawnConfiguration
	{
		public float durationUntilSpawn;

		public float durationAfterSpawn;

		public float minCooldown;

		public float maxCooldown;
	}

	public float landDuration;

	public float durationBeforeStartingToSpawnStones;

	public float durationBeforeLeaveStonesSpawnState;

	public SpawnConfiguration beamSpawn;

	public SpawnConfiguration stoneSpawn;
}
