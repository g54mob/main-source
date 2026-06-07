using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class ShopItemChip : MonoBehaviour
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
		Chips component = itemGO.GetComponent<Chips>();
		shopItemTitle.text = component.chipName.GetLocalizedString();
	}

	private void Start()
	{
		Chips component = itemGO.GetComponent<Chips>();
		mainImage.sprite = component.mainImage;
		shopItemTitle.text = component.chipName.GetLocalizedString();
	}

	public void Clicked()
	{
		itemGO.GetComponent<Item>();
		GameManager.S.ShopItemClicked(itemGO, base.gameObject);
	}
}
