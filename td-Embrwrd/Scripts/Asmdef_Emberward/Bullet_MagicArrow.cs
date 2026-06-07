using System.Collections.Generic;
using UnityEngine;

public class Bullet_MagicArrow : AProjectile
{
	private class HitRecord
	{
		public AMonsterBase monster;

		public float hitTime;

		public HitRecord(AMonsterBase monster, float hitTime)
		{
		}
	}

	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float damageRadius;

	[SerializeField]
	private float detectInterval;

	[SerializeField]
	private ParticleSystem particle_BuffTower;

	[SerializeField]
	private Collider arrowCollider;

	private float maxDistance;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private eDamageType damageType;

	private float flyDistance;

	private Vector3 targetPosition;

	private float detectTimer;

	private bool isOnFire;

	private int hitCount;

	private ABaseTower.eUpgradeType upgradeType;

	private List<AMonsterBase> list_HitMonsters;

	public override void Spawn(AMonsterBase target, GameObject source = null)
	{
	}

	private void LateUpdate()
	{
	}

	private void Update()
	{
	}

	public void Setup(int damage, float maxDistance, eDamageType damageType = eDamageType.NONE)
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

	private void OnDrawGizmosSelected()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}
}
