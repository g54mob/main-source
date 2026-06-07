using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/紅色升級套件", order = 1)]
public class RedUpgradeKitBuff : ABaseBuffSettingData
{
	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	public override void PreRegisterProc(ABaseTower tower)
	{
	}

	public override bool IsTowerBuffApplyable(ABaseTower tower)
	{
		return false;
	}

	public override void OnPointerEnterTargetTower(ABaseTower tower)
	{
	}

	public override void OnPointerExitTarget(ABaseTower tower)
	{
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
