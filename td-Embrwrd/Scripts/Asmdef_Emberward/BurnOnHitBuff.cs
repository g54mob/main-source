using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/攻擊到的目標燃燒", order = 1)]
public class BurnOnHitBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float burnDuration;

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
