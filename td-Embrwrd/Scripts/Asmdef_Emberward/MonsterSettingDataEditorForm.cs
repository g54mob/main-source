using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/MonsterSettingData編輯表格", order = 1)]
public class MonsterSettingDataEditorForm : ScriptableObject
{
	[SerializeField]
	private List<MonsterSettingData> monsterSettingDataList;
}
