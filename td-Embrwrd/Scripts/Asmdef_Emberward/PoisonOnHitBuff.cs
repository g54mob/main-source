using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/攻擊到的目標中毒", order = 1)]
public class PoisonOnHitBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float percentage;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
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
