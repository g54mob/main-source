using UnityEngine;

public class Tower_Drone : ABaseTower
{
	private enum eDroneState
	{
		IDLE = 0,
		FLYING = 1,
		ATTACKING = 2,
		GO_HOME = 3
	}

	[SerializeField]
	private float detectRange;

	[SerializeField]
	private float maxSpeed;

	[SerializeField]
	private float accelerate;

	[SerializeField]
	private Transform node_Drone;

	[SerializeField]
	private Transform node_RadarEffect;

	[SerializeField]
	private SpriteRenderer spriteRenderer_RadarEffect;

	[SerializeField]
	private ParticleSystem particle_FoundTarget;

	private float speed;

	private Vector3 flyTargetPosition;

	private Vector3 headModelForward;

	private Vector3 droneToTargetDir;

	private Transform targetTransform;

	private float updateTargetInterval;

	private float updateTargetTimer;

	private float findTargetTimer;

	private eDroneState droneState;

	private void Start()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	private void OnBattleStart()
	{
	}

	protected override void CannonDespawnProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	protected override void ShootProc()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void OnMouseEnterProc()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	public override float GetVisionRange()
	{
		return 0f;
	}
}
