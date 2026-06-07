using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Bullet_Boulder : ASingleTargetProjectile
{
	[SerializeField]
	private Transform node_Boulder;

	[SerializeField]
	private ParticleSystem particle_NormalExplosion;

	[SerializeField]
	private ParticleSystem particle_BoulderBreak;

	[SerializeField]
	private ParticleSystem particle_CrystalElectric;

	[SerializeField]
	private ParticleSystem particle_CrystalBreak;

	[SerializeField]
	private Spin spin;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float groundSpeed;

	[SerializeField]
	private float groundDetectRange;

	[SerializeField]
	private float maxRollingDistance;

	[SerializeField]
	private float maxCrystalWaitTime;

	[SerializeField]
	private float crystalDamageRange;

	[SerializeField]
	private float CrystalDamagePercentage;

	[SerializeField]
	private float CrystalDamageInterval;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private float explodeRange;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private bool isLanded;

	private Vector3 flyDirection;

	private float totalRollingDistance;

	private float crystalWaitTimer;

	private float crystalDamageTimer;

	private List<AMonsterBase> list_MonsterAttackedByRolling;

	private ABaseTower.eUpgradeType towerUpgradeType;

	private eDamageType damageType;

	private Sequence tween_BoulderJump;

	private void LateUpdate()
	{
	}

	private void Update()
	{
	}

	public void Setup(int damage)
	{
	}

	private void UpdateAfterLanded(float deltaTime)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
