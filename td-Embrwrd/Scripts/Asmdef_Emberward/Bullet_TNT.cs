using UnityEngine;

public class Bullet_TNT : ASingleTargetProjectile
{
	private enum eTNTState
	{
		NONE = 0,
		FLYING = 1,
		ON_MONSTER = 2,
		ON_GROUND = 3
	}

	[SerializeField]
	private Renderer renderer_TNT;

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

	[SerializeField]
	private float extraExplodeRange_UpgradeB;

	[SerializeField]
	private Transform node_Content;

	[SerializeField]
	private eTNTState tntState;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private float duration;

	private float durationTimer;

	private float traveledDistance;

	private Vector3 lastUpdatePosition;

	private Transform monsterBoneNode;

	private ABaseTower.eUpgradeType upgradeType;

	public void Setup(int damage, float explodeTime, ABaseTower.eUpgradeType upgradeType)
	{
	}

	protected override void SpawnProc()
	{
	}

	protected override Vector3 GetFlyTargetPosition(bool isAttackHeadPosition = true)
	{
		return default(Vector3);
	}

	private void Update()
	{
	}

	private void Explode()
	{
	}

	private void OnDisable()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
