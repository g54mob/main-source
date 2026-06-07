using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/攻擊力提升但發射速度下降", order = 1)]
public class SpeedToDamageBuff : ABaseBuffSettingData
{
	[SerializeField]
	private float damageMultiplier;

	[SerializeField]
	private float shootRateMultiplier;

	private TowerStats damageModifierStats;

	private TowerStats shootRateModifierStats;

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
