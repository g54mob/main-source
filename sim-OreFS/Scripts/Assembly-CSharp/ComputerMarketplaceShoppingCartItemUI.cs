using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMarketplaceShoppingCartItemUI : MonoBehaviour
{
	[Header("UI Elements")]
	[Tooltip("Item icon")]
	[SerializeField]
	private Image itemIcon;

	[Tooltip("Item name text")]
	[SerializeField]
	private TextMeshProUGUI itemNameText;

	[Tooltip("Item quantity text (sepetteki adet)")]
	[SerializeField]
	private TextMeshProUGUI itemQuantityText;

	[Tooltip("Delete butonu (adet azaltır)")]
	[SerializeField]
	private Button deleteButton;

	private T_BuildingItemSO _itemSO;

	public ShoppingCartItemData _cartItem;

	private ComputerMarketplaceUI _marketplaceUI;

	public void Setup(T_BuildingItemSO itemSO, ShoppingCartItemData cartItem, ComputerMarketplaceUI marketplaceUI)
	{
		_itemSO = itemSO;
		_cartItem = cartItem;
		_marketplaceUI = marketplaceUI;
		UpdateUI();
	}

	public void UpdateUI()
	{
		if (!(_itemSO == null))
		{
			if (itemIcon != null)
			{
				itemIcon.sprite = _itemSO.Icon;
			}
			if (itemNameText != null)
			{
				itemNameText.text = LocalizationManager.GetTranslation(_itemSO.Name);
			}
			if (itemQuantityText != null)
			{
				itemQuantityText.text = $"x{_cartItem.quantity}";
			}
		}
	}

	public void OnDeleteButtonClicked()
	{
		if (!(_marketplaceUI != null) || !(_itemSO != null))
		{
			return;
		}
		ComputerMarketplaceManager computerMarketplaceManager = Object.FindFirstObjectByType<ComputerMarketplaceManager>();
		if (computerMarketplaceManager != null)
		{
			int itemIndex = computerMarketplaceManager.GetItemIndex(_itemSO);
			if (itemIndex >= 0)
			{
				_marketplaceUI.OnCartItemDeleteClicked(itemIndex);
			}
		}
	}
}
