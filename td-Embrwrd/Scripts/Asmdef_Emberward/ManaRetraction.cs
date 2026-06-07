using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/魔力回收", order = 1)]
public class ManaRetraction : ABaseBuffSettingData
{
	private eItemType previousBuffType;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	public override void PreRegisterProc(ABaseTower tower)
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
