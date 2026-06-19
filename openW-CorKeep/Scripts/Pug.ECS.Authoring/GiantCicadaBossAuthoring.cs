using System;
using UnityEngine;

public class GiantCicadaBossAuthoring : MonoBehaviour
{
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

	[Header("Amount of time to spawn new guards")]
	public int amountOfStages = 5;

	[Header("Arm slams")]
	public float lowestStageMultiplier = 0.3f;

	public int armSlamDamage = 500;

	public float damageMultiplier = 1f;

	public float armSlamCooldown = 7f;

	public float armSlamAnticipation = 1f;

	public float armSlamAnimationDuration = 5f;

	[Header("Stage transition")]
	public float spawnDuration = 9f;

	public float stageTransitionDuration = 3f;

	[Header("Nymph spawn")]
	public float spawnNymphsMinCooldown = 12f;

	public float spawnNymphsMaxCooldown = 16f;

	public VoidSpawnConfiguration voidSpawn;

	[HideInInspector]
	public AreaLevelAuthoring level;

	private void OnValidate()
	{
		if (!Application.isPlaying)
		{
			if (level == null || level.gameObject != base.gameObject)
			{
				level = GetComponent<AreaLevelAuthoring>();
			}
			if (level != null)
			{
				int num = level.CalculateLevel();
				armSlamDamage = MeleeAttackStateAuthoring.LevelToDamage(num, damageMultiplier);
			}
		}
	}
}
