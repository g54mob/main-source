using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/角色/_BasicSetting", order = 1)]
public class CharacterSettingData : ScriptableObject
{
	[SerializeField]
	[Header("角色類型")]
	protected eCharacterType characterType;

	[SerializeField]
	protected Color characterColor;

	[SerializeField]
	protected Color characterColorBright;

	[SerializeField]
	protected Sprite characterIcon;

	[SerializeField]
	[Header("是否可以在無盡模式使用")]
	protected bool isUseableInEndlessMode;

	[Header("是否可以在謎之聖殿使用")]
	[SerializeField]
	protected bool isUseableInEnigmaSanctum;

	[Header("開始遊戲時的額外神器")]
	[SerializeField]
	protected List<eItemType> list_StartingRelic;

	[SerializeField]
	[Header("開始遊戲時的額外砲塔")]
	protected List<eItemType> list_StartingTowers;

	[Header("角色技能資料")]
	[SerializeField]
	protected List<CharacterSkillData> skillData;

	[SerializeField]
	protected int initialHPChange;

	public eCharacterType CharacterType => default(eCharacterType);

	public Color CharacterColor => default(Color);

	public Color CharacterColorBright => default(Color);

	public Sprite CharacterIcon => null;

	public bool IsUseableInEndlessMode => false;

	public bool IsUseableInEnigmaSanctum => false;

	public int InitialHPChange => 0;

	public virtual List<TetrisCardData> GetStartingTetrisSet(int seed)
	{
		return null;
	}

	public virtual List<TetrisCardData> GetStartingTetrisSet(List<eItemType> list_Preset)
	{
		return null;
	}

	public virtual List<eItemType> GetStartingRunes()
	{
		return null;
	}

	public virtual List<eItemType> GetAvailableTetrisTypes()
	{
		return null;
	}

	public virtual List<TowerSettingData> GetStartingTowerSet(List<eItemType> list_ExcludeTowers)
	{
		return null;
	}

	private List<TowerSettingData> GetBasicRandomTowerSet(List<eItemType> list_ExcludeTowers)
	{
		return null;
	}

	public int GetSkillCount()
	{
		return 0;
	}

	public string GetSkillLocalizationName(int index)
	{
		return null;
	}

	public string GetSkillLocalizationDescription(int index)
	{
		return null;
	}

	public CharacterSkillData GetSkillData(int index)
	{
		return null;
	}

	public bool IsHaveStartingRelic()
	{
		return false;
	}

	public List<eItemType> GetStartingRelic()
	{
		return null;
	}

	public bool IsRelicInStartingRelic(eItemType itemType)
	{
		return false;
	}

	public bool IsHaveStartingTower()
	{
		return false;
	}

	public List<eItemType> GetStartingTower()
	{
		return null;
	}

	public int GetProcessedMaxHP(int originalHP)
	{
		return 0;
	}

	protected void AddRuneToRandomBlocks(List<TetrisCardData> list_TetrisCardData, int count, eItemType runeType)
	{
	}

	protected void AddRuneToSelectedBlock(List<TetrisCardData> list_TetrisCardData, int index, eItemType runeType)
	{
	}

	private Color ValidateStartingRelic()
	{
		return default(Color);
	}
}
