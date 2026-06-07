using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/RuneSettingData", order = 1)]
public class RuneSettingData : AItemSettingData
{
	[SerializeField]
	[Header("稀有度")]
	private eRarityType rarityType;

	[Header("是否為特殊符文 (第三插槽)")]
	[SerializeField]
	private bool isSpecialRune;

	[Header("相關屬性")]
	[SerializeField]
	private eDamageType damageType;

	[Header("符文背景顏色")]
	[SerializeField]
	private Color runeColor;

	[Header("是否會產生Buff Tile")]
	[SerializeField]
	private bool isHaveBuffTile;

	[SerializeField]
	[Header("是否顯示額外符文說明")]
	private bool isShowAdditionalDescription;

	[Header("額外說明的設定檔")]
	[SerializeField]
	private PowerGridSettingData powerGridSettingData;

	[SerializeField]
	[Header("比這個弱的符文類型 (當同時可選擇時，會將弱的符文移除)")]
	private eItemType lesserRuneType;

	public eRarityType RarityType => default(eRarityType);

	public bool IsSpecialRune => false;

	public eDamageType DamageType => default(eDamageType);

	public bool IsHaveBuffTile => false;

	public bool IsShowAdditionalDescription => false;

	public eItemType LesserRuneType => default(eItemType);

	public Color GetRuneColor()
	{
		return default(Color);
	}

	public Color GetRarityColor()
	{
		return default(Color);
	}

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}

	private Color Editor_GetRarityColor()
	{
		return default(Color);
	}

	public Color Editor_GetDamageTypeColor()
	{
		return default(Color);
	}
}
