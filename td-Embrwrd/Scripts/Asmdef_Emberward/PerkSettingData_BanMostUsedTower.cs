using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PerkSettingData/Perk_禁用最常使用的砲塔", order = 1)]
public class PerkSettingData_BanMostUsedTower : PerkSettingData
{
	public override string GetLocStatsString()
	{
		return null;
	}
}
