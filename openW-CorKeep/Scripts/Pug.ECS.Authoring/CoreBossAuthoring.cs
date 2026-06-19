using System;
using UnityEngine;

public class CoreBossAuthoring : MonoBehaviour
{
	[Serializable]
	public struct SpawnConfiguration
	{
		public bool disabled;

		public float durationUntilSpawn;

		public float durationAfterSpawn;

		public float minCooldown;

		public float maxCooldown;
	}

	[Serializable]
	public struct VoidSpawnConfiguration
	{
		public bool disabled;

		public float duration;

		public float minCooldown;

		public float maxCooldown;

		public float durationUntilSpawn;

		public float durationAfterSpawn;
	}

	public VoidSpawnConfiguration voidSpawn;

	public SpawnConfiguration beamSpawn;

	public int orbCount;

	public float orbRotationSpeed = 6f;

	public float orbMinDistance = 6f;

	public float orbMaxDistance = 9f;

	public int whirlwindProjectileDamage;

	public float whirlwindProjectileDamageMultiplier;

	public int homingTriangleProjectileDamage;

	public float homingTriangleProjectileDamageMultiplier;

	public float phase1HealthThreshold = 0.5f;

	public float phase1TransitionDuration = 1f;

	public float invulnerableDuration = 1f;
}
