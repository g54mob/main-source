using System;
using UnityEngine;

public class Bullet_EmberFire : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private Vector3 randomOffsetMaxRange;

	[SerializeField]
	private float maxFlightHeight;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private Vector3 startOffsetVector;

	private eDamageType damageType;

	public Action<AProjectile, AMonsterBase> OnKillMonster;

	private bool isTargetGround;

	public Action<AGridObject> OnHitGroundTarget;

	private AGridObject targetGridObject;

	private void LateUpdate()
	{
	}

	private void Update()
	{
	}

	private void OnKillMonsterCallback(AMonsterBase monster)
	{
	}

	public void Setup(int damage, eDamageType damageType)
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

	public void SetAttackCorruptGrid(AGridObject target, Action<AGridObject> OnHitGroundTarget = null)
	{
	}

	internal void SetDirectHitGroundPosition(Vector3 vector3, object onHitGroundTarget)
	{
	}

	internal void SetDirectHitGroundPosition(AGridObject target, object onHitGroundTarget)
	{
	}
}
