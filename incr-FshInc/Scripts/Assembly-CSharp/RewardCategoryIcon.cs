using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct RewardCategoryIcon
{
	public string categoryName;

	public List<SkillBonusType> bonusTypes;

	public Sprite icon;
}
