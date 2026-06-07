using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Obj_UI_ScrapMasterUpgradeCard : MonoBehaviour
{
	[Serializable]
	public class CardDisplaySetting
	{
		public eScrapMasterSkillType skillType;

		public Sprite sprite_BG;

		public Sprite sprite_Icon;

		public Color color_IconBG;
	}

	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_Title;

	[SerializeField]
	private TMP_Text text_Content;

	[SerializeField]
	private TMP_Text text_Level;

	[SerializeField]
	private List<Image> list_BGImages;

	[SerializeField]
	private Image image_IconBG;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private Button button;

	[SerializeField]
	private GameObject node_SelectOutline;

	[SerializeField]
	private List<Shadow> list_ImagesWithShadow;

	[SerializeField]
	private List<CardDisplaySetting> list_CardDisplaySettings;

	private UI_ChooseScrapMasterPerk_Popup parent;

	private ScrapMasterCardData cardData;

	public Button Button => null;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnClick()
	{
	}

	public void Setup(ScrapMasterCardData cardData, ScrapMasterSettingAssetData assetData, UI_ChooseScrapMasterPerk_Popup parent)
	{
	}

	public void Toggle(bool isOn)
	{
	}

	private string TranslateCardDataContent(ScrapMasterCardData cardData, ScrapMasterSettingAssetData assetData)
	{
		return null;
	}

	private void OnButtonSelect()
	{
	}

	private void OnButtonDeselect()
	{
	}

	private void OnClickButton()
	{
	}
}
