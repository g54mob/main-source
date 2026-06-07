using UnityEngine;

public class Bullet_Barrage : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private GameObject trail_Normal;

	[SerializeField]
	private GameObject trail_UpgradeA;

	[SerializeField]
	private GameObject trail_Arcane;

	[SerializeField]
	private ParticleSystem particle_Explosion_Normal;

	[SerializeField]
	private ParticleSystem particle_Explosion_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_Explosion_Arcane;

	[SerializeField]
	private Vector3 randomOffsetMaxRange;

	[SerializeField]
	private float explosionRadius;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private Vector3 startOffsetVector;

	private Vector3 lastUpdatePosition;

	private Vector3 lastMonsterPosition;

	protected eDamageType damageType;

	private ABaseTower.eUpgradeType towerUpgradeType;

	private Vector3 targetGroundPosition;

	private bool isEmpoweredUpgradeA;

	private void Update()
	{
	}

	protected virtual void Explode()
	{
	}

	public void Setup(int damage, int shootCount, eDamageType damageType)
	{
	}

	protected override Vector3 GetFlyTargetPosition(bool isAttackHeadPosition = true)
	{
		return default(Vector3);
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
