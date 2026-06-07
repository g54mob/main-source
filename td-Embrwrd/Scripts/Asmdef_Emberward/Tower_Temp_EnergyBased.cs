using UnityEngine;

public class Tower_Temp_EnergyBased : ABaseTower
{
	public enum eTowerState
	{
		CHARGE = 0,
		ATTACK = 1
	}

	[SerializeField]
	private Transform node_ProgressBarScaler;

	[SerializeField]
	private GameObject node_EnergyBar_Blue;

	[SerializeField]
	private GameObject node_EnergyBar_Red;

	[SerializeField]
	private float shootSpeedMultiplier_Min;

	[SerializeField]
	private float shootSpeedMultiplier_Max;

	private Vector3 headModelForward;

	private float energy;

	private float energyPerShoot;

	private float rechargeTime;

	private eTowerState towerState;

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void CannonSpawnProc()
	{
	}

	private void UpdateEnergyBar(float energy)
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
