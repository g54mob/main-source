using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ShopItemRocket : MonoBehaviour
{
	[SerializeField]
	private GameObject itemGO;

	[SerializeField]
	private Image mainImage;

	[SerializeField]
	private TextMeshProUGUI shopItemTitle;

	public bool purchased;

	private void OnEnable()
	{
		LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		ChangeLanguage();
	}

	private void OnDisable()
	{
		LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
	}

	private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
	{
		ChangeLanguage();
	}

	private void ChangeLanguage()
	{
		RocketAttachment componentInChildren = itemGO.GetComponentInChildren<RocketAttachment>();
		string localizedString = componentInChildren.partNameTemp.GetLocalizedString();
		shopItemTitle.text = $"{localizedString}\n{componentInChildren.partValue}$";
	}

	private void Start()
	{
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		string key = base.gameObject.name + "isPurchased";
		purchased = ES3.Load(key, purchased);
		RocketAttachment componentInChildren = itemGO.GetComponentInChildren<RocketAttachment>();
		mainImage.sprite = componentInChildren.mainImage;
		string localizedString = componentInChildren.partNameTemp.GetLocalizedString();
		shopItemTitle.text = $"{localizedString}\n{componentInChildren.partValue}$";
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		ES3.Save(base.gameObject.name + "isPurchased", purchased);
	}

	private void OnDestroy()
	{
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	public void Clicked()
	{
		GameManager.S.ShopItemClicked(itemGO, base.gameObject);
	}
}
