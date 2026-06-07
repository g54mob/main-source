using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Slime : AProjectile
{
	private class HitRecord
	{
		public AMonsterBase monster;

		public float hitTime;

		public HitRecord(AMonsterBase monster, float hitTime)
		{
		}
	}

	[FormerlySerializedAs("speed")]
	[SerializeField]
	private float initialSpeed;

	[SerializeField]
	private float damageRadius;

	[SerializeField]
	private float detectInterval;

	[SerializeField]
	private Collider arrowCollider;

	[SerializeField]
	private Spin spin;

	[SerializeField]
	private float maxSpinSpeed;

	[SerializeField]
	private float minSpinSpeed;

	private float speed;

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

	private int bounceCount;

	private ABaseTower.eUpgradeType upgradeType;

	private List<AMonsterBase> list_HitMonsters;

	private Vector3 lastFramePosition;

	private Vector3 lastGroundBouncePosition;

	private float totalTraveledDistance;

	private Vector3 moveDirection;

	private int consequentBounceCount;

	private bool isFalling;

	[SerializeField]
	private float fallAcceleration;

	public override void Spawn(AMonsterBase target, GameObject source = null)
	{
	}

	public void SetBounceCount(int count)
	{
	}

	private void Update()
	{
	}

	public void Setup(int damage, float maxDistance, ABaseTower.eUpgradeType upgradeType, eDamageType damageType = eDamageType.NONE)
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
}
