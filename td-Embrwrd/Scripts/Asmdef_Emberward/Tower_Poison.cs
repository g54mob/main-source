using System.Collections.Generic;
using UnityEngine;

public class Tower_Poison : ABaseTower
{
	private struct AttackedMonsterRecord
	{
		public AMonsterBase monster;

		public float lastAttackTime;
	}

	[SerializeField]
	private ParticleSystem particle_PoisonDrip;

	[SerializeField]
	private ParticleSystem particle_Error;

	[SerializeField]
	private List<BoxCollider> list_PillarColliders;

	[SerializeField]
	[Header("岩漿particle")]
	private ParticleSystem particle_LavaDrip;

	[Header("灑水器模型")]
	[SerializeField]
	private GameObject model_WaterSprinkler;

	[SerializeField]
	[Header("灑水particle")]
	private ParticleSystem particle_WaterSprinkle;

	[Header("灑水器旋轉")]
	[SerializeField]
	private Spin spin_WaterSprinkler;

	[Header("範圍提示圈")]
	[SerializeField]
	private GameObject upgrade_B_rangeIndicator;

	private List<AttackedMonsterRecord> list_AttackedMonsters;

	private Vector3 headModelForward;

	private float upgradeB_timer;

	private void Start()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	private void Update_UpgradeB_Effect()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	private void CheckContinuousPoisonTowerAchievement()
	{
	}

	public override void TowerUpgradeProc(eUpgradeType upgradeType)
	{
	}

	private bool IsMonsterAttacked(AMonsterBase monster)
	{
		return false;
	}

	public override void TowerStunProc()
	{
	}

	public override void TowerStunEndProc()
	{
	}

	protected override void ShootProc()
	{
	}
}
