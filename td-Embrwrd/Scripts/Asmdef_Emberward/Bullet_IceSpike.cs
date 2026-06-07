using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_IceSpike : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	[FormerlySerializedAs("explodeRange")]
	private float explodeRangeSetting;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private float explodeRange;

	private ABaseTower.eUpgradeType upgradeType;

	private eDamageType damageType;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void Setup(int damage)
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
