using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ContractItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Contract numarası (3 basamak)")]
	[SerializeField]
	private TextMeshProUGUI contractNumberText;

	[Tooltip("Şirket ismi")]
	[SerializeField]
	private TextMeshProUGUI companyNameText;

	[Tooltip("Contract fiyatı")]
	[SerializeField]
	private TextMeshProUGUI priceText;

	[Tooltip("Teslimat süresi")]
	[SerializeField]
	private TextMeshProUGUI deliveryDaysText;

	[Tooltip("Şirket logosu")]
	[SerializeField]
	private Image companyLogoImage;

	[Tooltip("Şirket arkaplan görseli")]
	[SerializeField]
	private Image companyBackgroundImage;

	[Tooltip("Kazanılacak XP miktarı")]
	[SerializeField]
	private TextMeshProUGUI xpText;

	[Tooltip("Tıklanabilir buton")]
	[SerializeField]
	private Button selectButton;

	[Tooltip("Kilitli durumda gösterilecek overlay")]
	[SerializeField]
	private GameObject lockedOverlay;

	[Tooltip("İnceleme durumunda gösterilecek overlay")]
	[SerializeField]
	private GameObject inspectOverlay;

	[Tooltip("Kilitli durumda gösterilecek gerekli level metni")]
	[SerializeField]
	private TextMeshProUGUI requiredLevelText;

	private ContractListingData _listingData;

	private ActiveContractData _activeData;

	private bool _isActiveMode;

	private Action<ContractListingData> _onListingClickCallback;

	private Action<ActiveContractData> _onDetailCallback;

	private Action<ActiveContractData> _onCancelCallback;

	public bool IsActiveMode => _isActiveMode;

	public string ListingId => _listingData.listingId;

	public string ActiveId => _activeData.activeId;

	public ContractListingData ListingData => _listingData;

	public ActiveContractData ActiveData => _activeData;

	public void InitializeAsListing(ContractListingData listing, Action<ContractListingData> onClick)
	{
		_isActiveMode = false;
		_listingData = listing;
		_onListingClickCallback = onClick;
		UpdateListingUI();
	}

	public void InitializeAsActive(ActiveContractData contract, Action<ActiveContractData> onDetail, Action<ActiveContractData> onCancel)
	{
		_isActiveMode = true;
		_activeData = contract;
		_onDetailCallback = onDetail;
		_onCancelCallback = onCancel;
		UpdateActiveUI();
	}

	public void UpdateActiveContractData(ActiveContractData contract)
	{
		if (_isActiveMode)
		{
			_activeData = contract;
			UpdateActiveUI();
		}
	}

	public void UpdateUI()
	{
		if (_isActiveMode)
		{
			UpdateActiveUI();
		}
		else
		{
			UpdateListingUI();
		}
	}

	private void UpdateListingUI()
	{
		if (_listingData.IsValid)
		{
			if (contractNumberText != null)
			{
				contractNumberText.text = $"#{_listingData.contractNumber:D3}";
			}
			if (companyNameText != null)
			{
				companyNameText.text = _listingData.companyName;
			}
			if (priceText != null)
			{
				priceText.text = $"{_listingData.price:N0}";
			}
			if (deliveryDaysText != null)
			{
				int deliveryDays = _listingData.deliveryDays;
				string arg = ((deliveryDays == 1) ? LocalizationManager.GetTranslation("Day") : LocalizationManager.GetTranslation("Days"));
				deliveryDaysText.text = $"{deliveryDays} {arg}";
			}
			UpdateXPText(_listingData.contractId);
			UpdateCompanyVisuals(_listingData.contractId);
			UpdateLockedState();
		}
	}

	private void UpdateLockedState()
	{
		bool isLocked = _listingData.IsLocked;
		if (lockedOverlay != null)
		{
			lockedOverlay.SetActive(isLocked);
		}
		if (inspectOverlay != null)
		{
			inspectOverlay.SetActive(!isLocked);
		}
		if (requiredLevelText != null)
		{
			if (isLocked)
			{
				string translation = LocalizationManager.GetTranslation("Level");
				LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
				{
					"Number",
					_listingData.requiredLevel.ToString()
				} });
				requiredLevelText.text = translation;
				requiredLevelText.gameObject.SetActive(value: true);
			}
			else
			{
				requiredLevelText.gameObject.SetActive(value: false);
			}
		}
	}

	private void UpdateActiveUI()
	{
		if (!_activeData.IsValid)
		{
			return;
		}
		if (contractNumberText != null)
		{
			contractNumberText.text = $"#{_activeData.contractNumber:D3}";
		}
		if (companyNameText != null)
		{
			companyNameText.text = _activeData.companyName;
		}
		if (priceText != null)
		{
			priceText.text = $"{_activeData.agreedPrice:N0}";
		}
		if (deliveryDaysText != null)
		{
			int remainingDays = _activeData.RemainingDays;
			if (remainingDays > 0)
			{
				string arg = ((remainingDays == 1) ? LocalizationManager.GetTranslation("Day") : LocalizationManager.GetTranslation("Days"));
				string translation = LocalizationManager.GetTranslation("Remaining!");
				deliveryDaysText.text = $"{remainingDays} {arg} {translation}";
			}
			else
			{
				string text = LocalizationManager.GetTranslation("Last Day");
				if (string.IsNullOrEmpty(text))
				{
					text = "Last Day";
				}
				deliveryDaysText.text = text;
			}
		}
		UpdateXPText(_activeData.contractId);
		UpdateCompanyVisuals(_activeData.contractId);
	}

	private void UpdateXPText(string contractId)
	{
		if (!(xpText == null))
		{
			ContractSO contractSO = ComputerContractManager.Instance?.GetContractConfig(contractId);
			if (contractSO != null)
			{
				xpText.text = $"{contractSO.TierXP} XP";
			}
			else
			{
				xpText.text = "";
			}
		}
	}

	private void UpdateCompanyVisuals(string contractId)
	{
		ContractSO contractSO = ComputerContractManager.Instance?.GetContractConfig(contractId);
		if (companyLogoImage != null)
		{
			Sprite sprite = null;
			sprite = ((!_isActiveMode) ? _listingData.GetLogo(contractSO) : contractSO?.company?.companyLogo);
			if (sprite != null)
			{
				companyLogoImage.sprite = sprite;
				companyLogoImage.gameObject.SetActive(value: true);
			}
			else
			{
				companyLogoImage.gameObject.SetActive(value: false);
			}
		}
		if (companyBackgroundImage != null)
		{
			Sprite sprite2 = null;
			sprite2 = (_isActiveMode ? contractSO?.company?.companyBackground : _listingData.GetBackground(contractSO));
			if (sprite2 != null)
			{
				companyBackgroundImage.sprite = sprite2;
				companyBackgroundImage.gameObject.SetActive(value: true);
			}
			else
			{
				companyBackgroundImage.gameObject.SetActive(value: false);
			}
		}
	}

	public void OnButtonClicked()
	{
		if (_isActiveMode)
		{
			_onDetailCallback?.Invoke(_activeData);
		}
		else
		{
			_onListingClickCallback?.Invoke(_listingData);
		}
	}

	public void OnCancelButtonClicked()
	{
		if (_isActiveMode)
		{
			_onCancelCallback?.Invoke(_activeData);
		}
	}
}
