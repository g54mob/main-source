using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PerkSettingData/Perk_無盡模式_只會出現三種屬性的砲塔", order = 1)]
public class PerkSettingData_ThreeElementTowerOnly : PerkSettingData
{
	[SerializeField]
	private List<eDamageType> list_Elements;

	public List<eDamageType> List_Elements => null;

	protected override void InitializeProc(int seed)
	{
	}

	public override string GetLocStatsString()
	{
		return null;
	}
}
