using System;
using UnityEngine;

[Serializable]
public class CharacterInGameSkillData
{
	[Header("每回合可用幾次")]
	public int usablePerRound;

	[Header("技能資料")]
	public AItemSettingData skillSettingData;
}
