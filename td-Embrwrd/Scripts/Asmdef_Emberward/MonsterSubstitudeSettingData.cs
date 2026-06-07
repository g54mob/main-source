using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterSubstitudeSettingData", menuName = "設定檔/MonsterSubstitudeSettingData")]
public class MonsterSubstitudeSettingData : ScriptableObject
{
	[Serializable]
	public class MonsterSubstitudeGroup
	{
		public List<eMonsterType> list_MonsterType;
	}

	public class MonsterSubstitudeData
	{
		public eMonsterType monsterType;

		private int count;

		public MonsterSubstitudeData(eMonsterType monsterType, int count)
		{
		}
	}

	[SerializeField]
	private List<MonsterSubstitudeGroup> list_MonsterSubstitudeGroups;

	public void UpdateFromData()
	{
	}

	public MonsterSubstitudeData GetSubstitudeMonster(eMonsterType type, int count)
	{
		return null;
	}
}
