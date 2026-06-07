using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_UpgradeTowerButton : MonoBehaviour
{
	[Serializable]
	public class StatTypeToIconDic : SerializableDictionary<eStatType, Sprite>
	{
	}

	[SerializeField]
	private eStatType statType;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private TMP_Text text_Cost;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Button button;

	[SerializeField]
	private StatTypeToIconDic dic_statTypeToIcon;

	public Action<eStatType> OnClickButton;

	private Color text_UpgradeCostNormalColor;

	public eStatType StatType => default(eStatType);

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClick()
	{
	}

	public void SetupContent(eStatType statType, int cost)
	{
	}

	private void SetText()
	{
	}

	public bool SetBuyable(bool isBuyable)
	{
		return false;
	}
}
