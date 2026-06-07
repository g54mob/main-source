using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildInfoPanel : MonoBehaviour
{
	public static BuildInfoPanel ins;

	public bool verticalVersion;

	[SerializeField]
	private TMP_Text infoHeader;

	[SerializeField]
	private TMP_Text nameText;

	[SerializeField]
	private TMP_Text infoText;

	[SerializeField]
	private TMP_Text extraInfoText;

	[SerializeField]
	private Image[] images;

	[SerializeField]
	private RectTransform rectTransform;

	[Header("Balatro mini panel")]
	public BalatroInfoPanel balatroInfoPanel;

	private void Start()
	{
		SetBlank();
		if (verticalVersion && SaveData.ins.verticalMode)
		{
			ins = this;
		}
		else if (!verticalVersion && !SaveData.ins.verticalMode)
		{
			ins = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	public void SetInfo(BuildingSO buildSO)
	{
		nameText.text = LocalizationSystem.GetLocalizedValue(buildSO.buildName);
		infoText.text = LocalizationSystem.GetLocalizedValue(buildSO.buildDesc);
		infoText.alignment = TextAlignmentOptions.Midline;
		if (buildSO.extraInfo == "")
		{
			extraInfoText.text = "";
		}
		else
		{
			extraInfoText.text = LocalizationSystem.GetLocalizedValue(buildSO.extraInfo);
		}
		ConsolidateForVerticalMode();
		base.gameObject.SetActive(value: true);
	}

	public void SetInfo(House house)
	{
		nameText.text = LocalizationSystem.GetLocalizedValue(house.houseName);
		infoText.text = LocalizationSystem.GetLocalizedValue(house.houseDesc);
		extraInfoText.text = LocalizationSystem.GetLocalizedValue("_CANT_DEMOLISH_HOUSE");
		if (balatroInfoPanel != null)
		{
			balatroInfoPanel.SetInfo(house);
		}
		ConsolidateForVerticalMode();
		base.gameObject.SetActive(value: true);
	}

	private void ConsolidateForVerticalMode()
	{
		if (SaveData.ins.verticalMode)
		{
			nameText.gameObject.SetActive(value: false);
			extraInfoText.gameObject.SetActive(value: false);
			string text = nameText.text + ": " + infoText.text + "<br><color=#747270><voffset=-0.2em>" + extraInfoText.text;
			infoText.text = text;
		}
	}

	public void SetBlank()
	{
		nameText.text = "";
		infoText.text = "";
		extraInfoText.text = "";
		if (balatroInfoPanel != null)
		{
			balatroInfoPanel.SetBlank();
		}
		base.gameObject.SetActive(value: false);
	}

	public void MoveToRightSide()
	{
		if (!SaveData.ins.verticalMode)
		{
			rectTransform.anchoredPosition = new Vector2(-112f, 0f);
		}
	}

	public void MoveToLeftSide()
	{
		if (!SaveData.ins.verticalMode)
		{
			rectTransform.anchoredPosition = new Vector2(-112f, 0f);
		}
	}
}
