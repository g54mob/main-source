using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalentSettingData", menuName = "設定檔/TalentSettingData")]
public class TalentSettingData : ScriptableObject
{
	[SerializeField]
	private Sprite defaultIcon;

	[SerializeField]
	private List<TalentSetting> list_talentSettings;

	[SerializeField]
	[Header("在這邊輸入要交換的兩格天賦的index")]
	private Vector2Int switchItemIndex;

	public TalentSetting GetTalentSettingByType(eTalentType talentType)
	{
		return null;
	}

	public TalentSetting GetTalentSettingByIndex(int index)
	{
		return null;
	}

	public List<TalentSetting> GetTalentSettings()
	{
		return null;
	}

	public int GetPointsNeededToLearnAll()
	{
		return 0;
	}

	private void OnValidate()
	{
	}

	private void LockAllTalentsInDemoVersion()
	{
	}

	private void UnlockAllTalentsInDemoVersion()
	{
	}

	private void SwapTalentByIndex()
	{
	}
}
