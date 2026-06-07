using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/射速_百分比增加", order = 1)]
public class PercentageShootSpeedBuff : ABaseBuffSettingData
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
