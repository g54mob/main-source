using UnityEngine;

public class Bullet_PoisonSpear : ASingleTargetProjectile
{
	private enum eSpearState
	{
		NONE = 0,
		FLYING = 1,
		ON_MONSTER = 2
	}

	[SerializeField]
	private Renderer renderer_Spear;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Rigidbody rigidbody;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	private Material mat_Spear_Normal;

	[SerializeField]
	private Material mat_Spear_Poison;

	[SerializeField]
	private Material mat_Spear_Arcane;

	[SerializeField]
	private ParticleSystem particle_Explosion_Normal;

	[SerializeField]
	private ParticleSystem particle_Explosion_Poison;

	[SerializeField]
	private ParticleSystem particle_Explosion_Arcane;

	[SerializeField]
	private Transform node_Content;

	private float explosionRange;

	[SerializeField]
	private eSpearState spearState;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private eDamageType damageType;

	private float flyHeight;

	private float duration;

	private float durationTimer;

	private float towerMaxRangeAtShoot;

	private Transform monsterBoneNode;

	private ABaseTower.eUpgradeType upgradeType;

	private int hitDamage;

	private float monsterMoveDistance;

	private Vector3 lastMonsterMoveUpdatePosition;

	private float lastDamageTickDistance;

	private float upgradeADuration;

	private float upgradeATimer;

	public void Setup(int damage, ABaseTower.eUpgradeType upgradeType)
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

	private void OnTargetMonsterDespawn(AMonsterBase monster)
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
