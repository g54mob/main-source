using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PerkSettingData/Perk_無盡模式_使用特定砲塔神器組合", order = 1)]
public class PerkSettingData_UsePresetCombination : PerkSettingData
{
	[SerializeField]
	private List<eItemType> list_Towers;

	[SerializeField]
	private List<eItemType> list_Relics;

	public List<eItemType> List_Towers => null;

	public List<eItemType> List_Relics => null;

	protected override void InitializeProc(int seed)
	{
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
