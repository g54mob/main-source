using UnityEngine;

public class Bullet_TankCannon : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

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

	private eDamageType damageType;

	private int extraPoisonDamage;

	private float flyHeight;

	private void LateUpdate()
	{
	}

	public void ResetFromTower()
	{
	}

	private void Update()
	{
	}

	public void Setup(int damage, eDamageType damageType, int extraPoisonDamage)
	{
	}

	protected override void SpawnProc()
	{
	}

	public void SetDirectHitGroundPosition(Vector3 targetPosition)
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
