using UnityEngine;

public class Bullet_LightningSpark : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	protected float decreaseFlightHeightRange;

	[SerializeField]
	protected float maxFlightHeightSetting;

	[SerializeField]
	private ParticleSystem particle_AreaExplosion;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private eDamageType damageType;

	private float explodeRange;

	protected float flyHeight;

	private bool isLastShot;

	private ABaseTower.eUpgradeType upgradeType;

	private void Update()
	{
	}

	protected void CalculateFlyHeight()
	{
	}

	public void Setup(int damage, eDamageType damageType, bool isLastShot)
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
