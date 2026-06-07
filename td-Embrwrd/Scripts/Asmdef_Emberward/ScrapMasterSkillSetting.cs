using System;
using System.Collections.Generic;

[Serializable]
public class ScrapMasterSkillSetting
{
	public eScrapMasterSkillType skillType;

	public List<ScrapMasterSkillAttribute> list_Attributes;

	public ScrapMasterSkillAttribute GetAttributeByLevel(int level)
	{
		return null;
	}
}
