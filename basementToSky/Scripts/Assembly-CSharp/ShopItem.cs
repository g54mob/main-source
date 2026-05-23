using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
	public GameObject itemGO;

	[SerializeField]
	private Image mainImage;

	[SerializeField]
	private TextMeshProUGUI shopItemTitle;

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
		Item component = itemGO.GetComponent<Item>();
		string localizedString = component.itemNameTemp.GetLocalizedString();
		shopItemTitle.text = $"{localizedString}\n{component.value}$";
	}

	private void Start()
	{
		Item component = itemGO.GetComponent<Item>();
		mainImage.sprite = component.mainImage;
		string localizedString = component.itemNameTemp.GetLocalizedString();
		shopItemTitle.text = $"{localizedString}\n{component.value}$";
	}

	public void Clicked()
	{
		itemGO.GetComponent<Item>();
		GameManager.S.ShopItemClicked(itemGO, base.gameObject);
	}
}
