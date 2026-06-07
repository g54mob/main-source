using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/ScrapMasterSettingAssetData", order = 1)]
public class ScrapMasterSettingAssetData : ScriptableObject
{
	public List<ScrapMasterSkillSetting> list_SkillSettings;

	public ScrapMasterSkillAttribute GetSkillSettingByType(eScrapMasterSkillType skillType, int level)
	{
		return null;
	}

	public string GetCardDataDescription(eScrapMasterSkillType skillType, int level)
	{
		return null;
	}
}
