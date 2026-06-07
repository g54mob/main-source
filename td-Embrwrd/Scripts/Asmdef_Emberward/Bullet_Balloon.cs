using UnityEngine;

public class Bullet_Balloon : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private float targetFlyHeight;

	[SerializeField]
	private float detonateDistance;

	[SerializeField]
	private float explodeRange;

	[SerializeField]
	private GameObject node_Balloon;

	[SerializeField]
	private Renderer renderer_Balloon;

	[SerializeField]
	private Material mat_Normal;

	[SerializeField]
	private Material mat_UpgradeA;

	[SerializeField]
	private Material mat_UpgradeB;

	[SerializeField]
	private ParticleSystem particle_Explode_Normal;

	[SerializeField]
	private ParticleSystem particle_Explode_UpgradeA;

	[SerializeField]
	private ParticleSystem particle_Explode_UpgradeB;

	[SerializeField]
	private GameObject node_UpgradeAEffect;

	[SerializeField]
	private GameObject node_UpgradeBEffect;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private ABaseTower.eUpgradeType towerUpgradeType;

	private eDamageType damageType;

	private bool isExploded;

	private int initialCharge;

	private int currentCharge;

	private float timeFlying;

	private float upgradeBEffectInterval;

	private float upgradeBEffectTimer;

	public void Setup(int damage)
	{
	}

	protected override void SpawnProc()
	{
	}

	private void Update()
	{
	}

	private void Explode()
	{
	}
}
