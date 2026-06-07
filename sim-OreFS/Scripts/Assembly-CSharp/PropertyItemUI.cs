using System;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PropertyItemUI : MonoBehaviour
{
	[Header("UI Elements - Text")]
	[Tooltip("Emlak ismi")]
	[SerializeField]
	private TextMeshProUGUI nameText;

	[Tooltip("Emlak adresi/lokasyonu")]
	[SerializeField]
	private TextMeshProUGUI addressText;

	[Tooltip("Emlak fiyatı")]
	[SerializeField]
	private TextMeshProUGUI priceText;

	[Tooltip("Emlak boyutu")]
	[SerializeField]
	private TextMeshProUGUI sizeText;

	[Tooltip("Emlak seviyesi")]
	[SerializeField]
	private TextMeshProUGUI levelText;

	[Tooltip("Emlak türü text")]
	[SerializeField]
	private TextMeshProUGUI typeText;

	[Header("UI Elements - Images")]
	[Tooltip("Emlak görseli")]
	[SerializeField]
	private Image propertyImage;

	[Tooltip("Emlak türü ikonu")]
	[SerializeField]
	private Image typeIcon;

	[Header("UI Elements - Button")]
	[Tooltip("Tıklanabilir buton")]
	[SerializeField]
	private Button selectButton;

	[Header("Type Icons")]
	[Tooltip("Konut ikonu")]
	[SerializeField]
	private Sprite residentialIcon;

	[Tooltip("Ticari ikon")]
	[SerializeField]
	private Sprite commercialIcon;

	private PropertyListingData _listingData;

	private Action<PropertyListingData> _onClickCallback;

	public string ListingId => _listingData.listingId;

	public PropertyListingData ListingData => _listingData;

	public void Initialize(PropertyListingData listing, Action<PropertyListingData> onClick)
	{
		_listingData = listing;
		_onClickCallback = onClick;
		UpdateUI();
	}

	public void UpdateUI()
	{
		if (_listingData.IsValid)
		{
			if (nameText != null)
			{
				nameText.text = _listingData.LocalizedName;
			}
			if (addressText != null)
			{
				addressText.text = _listingData.LocalizedAddress;
			}
			if (priceText != null)
			{
				priceText.text = $"{_listingData.basePrice:N0}";
			}
			if (sizeText != null)
			{
				sizeText.text = $"{_listingData.size} m²";
			}
			if (levelText != null)
			{
				levelText.text = $"Lv.{_listingData.propertyLevel}";
			}
			if (typeText != null)
			{
				typeText.text = LocalizationManager.GetTranslation(_listingData.propertyType);
			}
			if (typeIcon != null)
			{
				typeIcon.sprite = ((_listingData.propertyType == PropertyType.Residential) ? residentialIcon : commercialIcon);
			}
			UpdatePropertyImage();
		}
	}

	private void UpdatePropertyImage()
	{
		if (!(propertyImage == null))
		{
			PropertyConfigSO config = ComputerPropertyManager.Instance?.GetConfig(_listingData.configId);
			Sprite visual = _listingData.GetVisual(config);
			if (visual != null)
			{
				propertyImage.sprite = visual;
				propertyImage.gameObject.SetActive(value: true);
			}
			else
			{
				propertyImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void OnButtonClicked()
	{
		_onClickCallback?.Invoke(_listingData);
		TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Property, TutorialStepType.BuyProperty, TutorialSubStepType.SelectProperty);
	}
}
