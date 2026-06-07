using UnityEngine;

public class Bullet_HomingMissile : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private Vector3 randomOffsetMaxRange;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private Vector3 startOffsetVector;

	private Vector3 lastUpdatePosition;

	private Vector3 lastMonsterPosition;

	protected eDamageType damageType;

	private void LateUpdate()
	{
	}

	private void Update()
	{
	}

	protected virtual void Explode()
	{
	}

	public void Setup(int damage, eDamageType damageType = eDamageType.NONE)
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
