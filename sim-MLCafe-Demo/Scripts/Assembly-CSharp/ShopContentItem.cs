using MLCN_Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopContentItem : MonoBehaviour
{
	[SerializeField]
	private TMP_Text labelName;

	[SerializeField]
	private TMP_Text labelUnitPrice;

	[SerializeField]
	private TMP_Text labelTotal;

	[SerializeField]
	private TMP_Text labelDescription;

	[SerializeField]
	private GameObject labelUpkeep;

	[SerializeField]
	private GameObject labelAmbientRating;

	[SerializeField]
	private TMP_Text labelUpkeepValue;

	[SerializeField]
	private TMP_Text labelAmbientRatingValue;

	[SerializeField]
	private TMP_InputField labelAmount;

	[SerializeField]
	private Image iconItem;

	[SerializeField]
	private Image iconLocked;

	[SerializeField]
	private Sprite spriteLocked;

	[SerializeField]
	private GameObject unlockedDisplay;

	[SerializeField]
	private GameObject lockedDisplay;

	[SerializeField]
	private TMP_Text labelLockedLevel;

	public ShopOption info;

	private int amount;

	private int unitPrice;

	private int itemId;

	private ShopMenu menu;

	public void Initialize(ShopMenu menu, int itemId, ShopOption option, int amount = 0)
	{
		this.menu = menu;
		this.itemId = itemId;
		info = option;
		unitPrice = Mathf.RoundToInt((float)info.buyPrice * AnomalyManager.GetAnomalyProperties().shop_item_price_multiplier);
		this.amount = amount;
		labelName.text = InventorySystem.GetItemLibrary().itemInfos[itemId].GetLocalizedName();
		if (labelDescription != null)
		{
			labelDescription.text = InventorySystem.GetItemLibrary().itemInfos[itemId].GetLocalizedDescription();
		}
		if (labelUpkeep != null && labelUpkeepValue != null)
		{
			int upkeep = InventorySystem.GetItemLibrary().itemInfos[itemId].upkeep;
			if (upkeep > 0)
			{
				labelUpkeep.SetActive(value: true);
				labelUpkeepValue.text = "-" + upkeep;
				labelUpkeepValue.gameObject.SetActive(value: true);
			}
			else
			{
				labelUpkeep.SetActive(value: false);
				labelUpkeepValue.gameObject.SetActive(value: false);
			}
		}
		if (labelAmbientRating != null && labelAmbientRatingValue != null)
		{
			int ambientRating = InventorySystem.GetItemLibrary().itemInfos[itemId].ambientRating;
			if (ambientRating != 0)
			{
				labelAmbientRating.SetActive(value: true);
				labelAmbientRatingValue.text = ambientRating.ToString();
				labelAmbientRatingValue.gameObject.SetActive(value: true);
			}
			else
			{
				labelAmbientRating.SetActive(value: false);
				labelAmbientRatingValue.gameObject.SetActive(value: false);
			}
		}
		labelUnitPrice.text = unitPrice.ToString();
		if (itemId != info.itemId)
		{
			info.itemId = itemId;
		}
		iconItem.sprite = info.LoadIcon();
		bool flag = info.locked && info.unlockLevel > ProgressionManager.GetCurrentLevel();
		iconItem.color = (flag ? Color.black : Color.white);
		if (iconLocked != null)
		{
			iconLocked.gameObject.SetActive(flag);
		}
		if (unlockedDisplay != null)
		{
			unlockedDisplay.SetActive(!flag);
		}
		if (lockedDisplay != null)
		{
			lockedDisplay.SetActive(flag);
		}
		if (labelLockedLevel != null)
		{
			labelLockedLevel.text = LocalizationManager.GetLocalizedString("com_shop_contentitem_label_unlock", LocalizationDataTable.Tables.ComputerElements) + " <color=orange>" + info.unlockLevel + "</color>";
		}
		UpdateAmount();
	}

	private void UpdateAmount()
	{
		if (amount < 0)
		{
			amount = 0;
		}
		else if (amount > ShopMenu.GetMaxAmount())
		{
			amount = ShopMenu.GetMaxAmount();
		}
		labelAmount.text = amount.ToString();
		if (itemId <= InventorySystem.GetItemLibrary().itemInfos.Count)
		{
			labelTotal.text = (unitPrice * amount).ToString();
		}
	}

	public void AddAmount()
	{
		amount++;
		if (amount > ShopMenu.GetMaxAmount())
		{
			amount = ShopMenu.GetMaxAmount();
		}
		UpdateAmount();
	}

	public void ReduceAmount()
	{
		amount--;
		UpdateAmount();
	}

	public void InputAmount(string amountString)
	{
		amount = int.Parse(amountString);
		if (amount > ShopMenu.GetMaxAmount())
		{
			amount = ShopMenu.GetMaxAmount();
		}
		UpdateAmount();
	}

	public void AddToCart()
	{
		if (amount != 0)
		{
			menu.AddItemToCart(menu.GetShopOptions(), itemId, unitPrice, amount);
			amount = 0;
			UpdateAmount();
		}
	}

	public void RemoveFromCart()
	{
		menu.RemoveItemFromCart(itemId);
		Object.Destroy(base.gameObject);
	}

	public void AddAmountInsideCart()
	{
		amount++;
		if (amount > ShopMenu.GetMaxAmount())
		{
			amount = ShopMenu.GetMaxAmount();
		}
		else
		{
			menu.AddItemToCart(menu.GetShopOptions(), itemId, unitPrice, 1);
		}
	}

	public void InputAmountInsideCart(string amountString)
	{
		int num = int.Parse(amountString);
		if (num <= 0)
		{
			amount = 1;
		}
		else if (num > ShopMenu.GetMaxAmount())
		{
			amount = ShopMenu.GetMaxAmount();
		}
		else
		{
			amount = num;
		}
		menu.SetItemAmountInsideCart(itemId, amount);
		UpdateAmount();
	}

	public void ReduceAmountWithDeleteOption()
	{
		amount--;
		if (amount <= 0)
		{
			menu.RemoveItemFromCart(itemId);
			Object.Destroy(base.gameObject);
		}
		else
		{
			UpdateAmount();
		}
	}
}
