using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PerkSettingData/Perk_無盡模式_開局給神器", order = 1)]
public class PerkSettingData_GetRelicAtGameStart : PerkSettingData
{
	[SerializeField]
	private eItemType relicType;

	public eItemType RelicType => default(eItemType);

	protected override void InitializeProc(int seed)
	{
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
