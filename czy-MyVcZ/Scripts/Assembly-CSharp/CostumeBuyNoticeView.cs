using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostumeBuyNoticeView : MonoBehaviour
{
	[SerializeField]
	private Image _costumeIcon;

	[SerializeField]
	private TextMeshProUGUI _costumeNameText;

	public void Show(CostumeID costumeID)
	{
		CostumeData costumeData = DataManager.Instance.GetCostumeData(costumeID);
		_costumeIcon.sprite = Resources.Load<Sprite>(costumeData.IconPath);
		_costumeNameText.text = LocaleHelper.Get(costumeData.NameLocalKey);
		base.gameObject.SetActive(value: true);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}
}
