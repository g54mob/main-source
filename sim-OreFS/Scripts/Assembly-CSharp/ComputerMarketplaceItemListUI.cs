using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ComputerMarketplaceItemListUI : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
{
	[Header("UI Elements")]
	[Tooltip("Item icon")]
	[SerializeField]
	private Image itemIcon;

	[Tooltip("Item name text")]
	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[Tooltip("Item price text")]
	[SerializeField]
	private TextMeshProUGUI itemPriceText;

	[Tooltip("Normal price text rengi")]
	[SerializeField]
	private Color defaultPriceColor = Color.white;

	[Tooltip("Para yetmediğinde price text rengi")]
	[SerializeField]
	private Color insufficientFundsPriceColor = Color.red;

	[Tooltip("Item level text")]
	[SerializeField]
	private TextMeshProUGUI itemLevelText;

	[Tooltip("Paket adedi text (örn: 10x)")]
	[SerializeField]
	private TextMeshProUGUI packageQuantityText;

	[Tooltip("Button component (prefab'ta tek buton)")]
	[SerializeField]
	private Button button;

	[Tooltip("Add to Cart GameObject (para yeterliyse gösterilecek)")]
	[SerializeField]
	private GameObject addToCartGameObject;

	[Tooltip("Yetersiz Para GameObject (para yetmiyorsa gösterilecek)")]
	[SerializeField]
	private GameObject insufficientFundsGameObject;

	[SerializeField]
	private GameObject levelLockedGameObject;

	[SerializeField]
	private GameObject levelLockedButtonGameObject;

	[Tooltip("Version Locked GameObject (version yetersizse gösterilecek)")]
	[SerializeField]
	private GameObject versionLockedGameObject;

	[Tooltip("Upgrade Locked GameObject (gerekli upgrade yapılmamışsa gösterilecek)")]
	[SerializeField]
	private GameObject upgradeLockedGameObject;

	[SerializeField]
	private GameObject upgradeLockedButtonGameObject;

	private bool _isUpgradeLocked;

	private bool _isVersionLocked;

	private T_BuildingItemSO _itemSO;

	private int _itemSOIndex;

	private ComputerMarketplaceUI _marketplaceUI;

	public void Setup(T_BuildingItemSO itemSO, int itemSOIndex, ComputerMarketplaceUI marketplaceUI)
	{
		_itemSO = itemSO;
		_itemSOIndex = itemSOIndex;
		_marketplaceUI = marketplaceUI;
		UpdateUI();
		UpdateButtonState();
	}

	private int GetTotalPrice()
	{
		if (_itemSO == null)
		{
			return 0;
		}
		if (ShoppingCartItemData.IsTutorialFreeItem(_itemSO))
		{
			return 0;
		}
		return _itemSO.Price * _itemSO.packageQuantity;
	}

	public void UpdateUI()
	{
		if (_itemSO == null)
		{
			return;
		}
		if (itemIcon != null)
		{
			itemIcon.sprite = _itemSO.Icon;
		}
		if (itemNameText != null)
		{
			itemNameText.text = LocalizationManager.GetTranslation(_itemSO.Name);
		}
		if (itemPriceText != null)
		{
			int totalPrice = GetTotalPrice();
			if (totalPrice == 0)
			{
				itemPriceText.text = LocalizationManager.GetTranslation("UI_FREE");
			}
			else
			{
				itemPriceText.text = $"{totalPrice:N0}";
			}
		}
		if (itemLevelText != null)
		{
			string translation = LocalizationManager.GetTranslation("Level");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, object> { 
			{
				"Number",
				_itemSO.Level.ToString()
			} });
			itemLevelText.text = translation;
		}
		if (packageQuantityText != null)
		{
			if (_itemSO.packageQuantity > 1)
			{
				packageQuantityText.text = $"{_itemSO.packageQuantity}x";
			}
			else
			{
				packageQuantityText.text = "";
			}
		}
	}

	public void UpdateButtonState()
	{
		if (!(_itemSO == null) && !(FactoryManager.Instance == null))
		{
			if (button != null)
			{
				button.interactable = true;
			}
			bool flag = FactoryManager.Instance.Level >= _itemSO.Level;
			int totalPrice = GetTotalPrice();
			bool flag2 = totalPrice == 0 || FactoryManager.Instance.Money >= totalPrice;
			bool flag3 = true;
			if (SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo && _itemSO.fullVersionOnly)
			{
				flag3 = false;
			}
			bool flag4 = true;
			if (_itemSO.requiredUpgrade != UpgradeType.None && UpgradeManager.Instance != null)
			{
				flag4 = UpgradeManager.Instance.GetUpgradeLevel(_itemSO.requiredUpgrade) >= _itemSO.requiredUpgradeLevel;
			}
			_isUpgradeLocked = !flag4;
			_isVersionLocked = !flag3;
			bool flag5 = !flag3;
			bool active = flag3 && !flag4;
			bool flag6 = flag3 && flag4 && !flag;
			bool active2 = flag3 && flag4 && flag && !flag2;
			bool active3 = flag3 && flag4 && flag;
			if (versionLockedGameObject != null)
			{
				versionLockedGameObject.SetActive(flag5);
			}
			if (upgradeLockedGameObject != null)
			{
				upgradeLockedGameObject.SetActive(active);
			}
			if (upgradeLockedButtonGameObject != null)
			{
				upgradeLockedButtonGameObject.SetActive(active);
			}
			if (levelLockedButtonGameObject != null)
			{
				levelLockedButtonGameObject.SetActive(flag5 || flag6);
			}
			if (levelLockedGameObject != null)
			{
				levelLockedGameObject.SetActive(flag6);
			}
			if (insufficientFundsGameObject != null)
			{
				insufficientFundsGameObject.SetActive(active2);
			}
			if (addToCartGameObject != null)
			{
				addToCartGameObject.SetActive(active3);
			}
			if (itemPriceText != null)
			{
				bool flag7 = flag3 && flag4 && flag && !flag2;
				itemPriceText.color = (flag7 ? insufficientFundsPriceColor : defaultPriceColor);
			}
		}
	}

	public void OnAddToCartButtonClicked()
	{
		if (!_isVersionLocked && !_isUpgradeLocked)
		{
			if (_marketplaceUI != null)
			{
				_marketplaceUI.OnAddToCartClicked(_itemSOIndex);
			}
			TutorialManager.Instance?.TryCompleteSubStep(TutorialConfigType.Production, TutorialStepType.BuyMachine, TutorialSubStepType.SelectFirstMachine);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (InputDetection.Instance != null && InputDetection.Instance.KeyboardEnabled)
		{
			ShowHoverPanel();
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HideHoverPanel();
	}

	public void OnSelect(BaseEventData eventData)
	{
		if (InputDetection.Instance != null && InputDetection.Instance.GamepadEnabled)
		{
			ShowHoverPanel();
		}
	}

	public void OnDeselect(BaseEventData eventData)
	{
		HideHoverPanel();
	}

	private void ShowHoverPanel()
	{
		if (_marketplaceUI != null && _itemSO != null)
		{
			RectTransform component = GetComponent<RectTransform>();
			_marketplaceUI.ShowHoverPanel(_itemSO, component);
		}
	}

	private void HideHoverPanel()
	{
		if (_marketplaceUI != null)
		{
			_marketplaceUI.HideHoverPanel();
		}
	}
}
