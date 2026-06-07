using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/殺死怪物增加攻擊速度", order = 1)]
public class IncreaseSpeedOnKillBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float decreaseRatePerShoot;

	[SerializeField]
	private float maxIncreaseRate;

	private int shootCount;

	protected override void ApplyEffect()
	{
	}

	protected override void RemoveEffect()
	{
	}

	private void OnTowerShootCallback(ABaseTower tower, AMonsterBase @base)
	{
	}

	private void OnRoundEnd()
	{
	}

	private void UpdateBuff()
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
