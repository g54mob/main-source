using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Tornado : ASingleTargetProjectile
{
	public enum eTornadoState
	{
		FLYING = 0,
		TORNADO_ACTIVATED = 1,
		ENDED = 2
	}

	[SerializeField]
	private ParticleSystem particle_Tornado;

	[SerializeField]
	private List<ParticleSystem> list_Tornado_WindParticle;

	[SerializeField]
	private Material material_Tornado_NormalMode;

	[SerializeField]
	private Material material_Tornado_TransparentMode;

	[SerializeField]
	private float speed;

	[SerializeField]
	private float maxFlightHeight;

	[SerializeField]
	private float decreaseFlightHeightRange;

	[SerializeField]
	[FormerlySerializedAs("tornadoRange")]
	private float tornadoRangeSetting;

	[SerializeField]
	private float tornadoMoveSpeed;

	[FormerlySerializedAs("tornadoDuration")]
	[SerializeField]
	private float tornadoDurationSetting;

	[SerializeField]
	private float damageInterval;

	[SerializeField]
	private float upgrade_B_FreezeDuration;

	private float tornadoRange;

	private float tornadoDuration;

	private float tornadoTimer;

	private float totalFlyTime;

	private float flyTimer;

	private Vector3 startPosition;

	private int damage;

	private float flyHeight;

	private float damageTimer;

	private ABaseTower.eUpgradeType towerUpgradeType;

	private eDamageType damageType;

	private Vector3Int targetPosition;

	private eTornadoState tornadoState;

	private bool isTransparentParticle;

	public Vector3Int TargetPosition => default(Vector3Int);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnGameStateChanged(eGameState fromState, eGameState toState)
	{
	}

	public void Setup(int damage, Vector3 targetPosition)
	{
	}

	public void ActivateTornado()
	{
	}

	protected override void SpawnProc()
	{
	}

	private void Update()
	{
	}

	protected override void DespawnProc()
	{
	}

	protected override void DestroyProc()
	{
	}
}
