using System;
using System.Collections;
using UnityEngine;

public class Monster_FrostElemental : Monster_Basic
{
	[SerializeField]
	private ParticleSystem particle_FrostRing;

	[SerializeField]
	private float skillRange;

	[SerializeField]
	private float skillDetectInterval;

	[SerializeField]
	private float towerStunTime;

	[SerializeField]
	private float startSpeedMultiplier;

	private bool isAttacked;

	private float timer;

	protected override void SpawnProc()
	{
	}

	public override void Hit(int damage, eDamageType damageType, Action<AMonsterBase> OnKillCallback = null, ABaseTower fromTower = null, bool hideDamageNumber = false, bool doTriggerHitReaction = true, float baseCritChance = 0f)
	{
	}

	public override void Hit(int damage, float baseCritChance, eDamageType damageType, ABaseTower tower, bool hideDamageNumber = false, bool doTriggerHitReaction = true)
	{
	}

	protected override void UpdateProc(float deltaTime)
	{
	}

	protected override IEnumerator DeathProc(int damage, bool isKilled, bool playAnimation = true)
	{
		return null;
	}

	protected override void HitProc(int damage, eDamageType damageType, bool doTriggerHitReaction, bool isFromTower)
	{
	}

	protected override void DespawnProc()
	{
	}
}
