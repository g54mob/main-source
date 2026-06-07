using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/解鎖Buff", order = 2)]
public class UnlockBuff : ABaseBuffSettingData
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
