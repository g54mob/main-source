using UnityEngine;

public class ADirectionalTower : ABaseTower
{
	[SerializeField]
	protected Obj_AreaMonsterDetector detector;

	[SerializeField]
	protected int attackWidth;

	public Obj_AreaMonsterDetector Detector => null;

	public int AttackWidth => 0;

	protected override void CannonSpawnProc()
	{
	}

	protected override void SwitchToPlacementModeProc()
	{
	}

	protected override void SetDynamicPlacementTargetProc(IDynamicPlacementTarget target)
	{
	}

	protected override void OnApplyBuffProc(TowerStats buffStat)
	{
	}

	protected override void CannonUpdateProc()
	{
	}

	protected override void OnRemoveBuffProc()
	{
	}

	protected override void OnBuffCardExpiredProc(eItemType itemType)
	{
	}

	public void UpdateRangeDisplay()
	{
	}

	public void RotateTowerToPossibleBestDir()
	{
	}

	public Vector3 GetBestRotateDir()
	{
		return default(Vector3);
	}

	protected virtual void OnAttackRangeChangeProc(float range)
	{
	}

	protected override void OnMouseEnterProc()
	{
	}

	protected override void OnMouseExitProc()
	{
	}

	protected override void ShootProc()
	{
	}
}
