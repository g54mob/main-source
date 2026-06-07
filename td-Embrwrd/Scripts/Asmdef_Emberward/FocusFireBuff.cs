using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/集火攻擊Buff", order = 2)]
public class FocusFireBuff : ABaseBuffSettingData
{
	private TowerStats buffModifierStats;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
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
