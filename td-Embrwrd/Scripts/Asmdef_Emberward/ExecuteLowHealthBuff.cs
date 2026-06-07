using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/斬殺低生命敵人", order = 1)]
public class ExecuteLowHealthBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float triggerInterval;

	[SerializeField]
	private float hpPercentageThreshold;

	private float triggerTimer;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	protected override void TickProc(float delta)
	{
	}

	private void OnMonsterHitCallback(AMonsterBase monster, int value, eDamageType type, bool isCrit, ABaseTower tower)
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
