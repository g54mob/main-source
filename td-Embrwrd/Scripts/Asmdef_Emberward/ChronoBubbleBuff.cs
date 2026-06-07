using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/ChronoBubbleBuff", order = 2)]
public class ChronoBubbleBuff : ABaseBuffSettingData
{
	private TowerStats buffModifierStats;

	private float bubbleDuration;

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
