using UnityEngine;

public class Bullet_PoisionDart : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private eDamageType damageType;

	private void LateUpdate()
	{
	}

	private void Update()
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
