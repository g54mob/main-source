using UnityEngine;

public class Bullet_Torch : ASingleTargetProjectile
{
	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxFlightHeight_Max;

	[SerializeField]
	private float maxFlightHeight_Min;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private float upgradeB_BounceRange;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private Spin spin;

	private float maxFlightHeight;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private eDamageType damageType;

	private ABaseTower.eUpgradeType towerUpgradeType;

	private int bounceCount;

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
