using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/Buff/修改砲塔屬性", order = 1)]
public class SwichElementBuff : ABaseBuffSettingData
{
	[SerializeField]
	private eDamageType damageType;

	private eDamageType originalDamageType;

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
