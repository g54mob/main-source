using UnityEngine;

public class Tower_Spark : ABaseTower
{
	[SerializeField]
	private Transform node_ProgressBarScaler;

	[SerializeField]
	private GameObject node_EnergyBar_Blue;

	[SerializeField]
	private float shootSpeedMultiplier_Min;

	[SerializeField]
	private float shootSpeedMultiplier_Max;

	[SerializeField]
	private float energyIncreasePerShoot;

	[SerializeField]
	private float energyDecreasePerSecond;

	[SerializeField]
	private float timeBeforeEnergyDecreases;

	private Vector3 headModelForward;

	private float energy;

	private float energyPerShoot;

	private float rechargeTime;

	private float lastShootTime;

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	private void UpdateEnergyBar(float energy)
	{
	}

	protected override void StunnedTowerUpdateProc(float deltaTime)
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
}
