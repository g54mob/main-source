using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/攻擊造成範圍中毒", order = 1)]
public class AreaPoisonOnHitBuff : ABaseBuffSettingData
{
	[SerializeField]
	private int damage;

	[SerializeField]
	private float range;

	[SerializeField]
	private float triggerInterval;

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
