using System.Collections.Generic;
using MLCN_Localization;
using TMPro;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
	[SerializeField]
	private ShopOptionsLibrary shopOptionsLibraryDemo;

	[SerializeField]
	private ShopOptionsLibrary shopOptionsLibraryFullVersion;

	private ShopOptionsLibrary shopOptionsLibrary;

	[SerializeField]
	private UIContentAnimator shoppingCartPanel;

	[SerializeField]
	private GameObject contentItemPrefab;

	[SerializeField]
	private Transform content;

	[SerializeField]
	private GameObject shoppingCartItemPrefab;

	[SerializeField]
	private Transform shoppingCartContent;

	[SerializeField]
	private UIContentAnimator animatorShoppingCart;

	[SerializeField]
	private UIContentAnimator cartItemCountPanel;

	[SerializeField]
	private TMP_Text[] labelBudget;

	[SerializeField]
	private TMP_Text labelCartItemCount;

	[SerializeField]
	private TMP_Text[] labelsTotal;

	[SerializeField]
	private TMP_Text[] labelDeliveryState;

	[SerializeField]
	private TMP_Text[] labelDeliveryTime;

	[SerializeField]
	private TMP_Text[] labelDeliveryCount;

	[SerializeField]
	private UIContentAnimator[] iconDeliveryCount;

	[SerializeField]
	private TMP_Text labelDeliveryTotalPackagesOnTheWay;

	[SerializeField]
	private TMP_Text labelDeliveryCurrentOrderPackageCount;

	[SerializeField]
	private string hintTag = "Delivery";

	[SerializeField]
	private string[] localizationDeliveryStateKeys;

	private List<ShopContentItem> contentItems = new List<ShopContentItem>();

	private List<CartItem> shoppingCart = new List<CartItem>();

	public static int GetMaxAmount()
	{
		return 10;
	}

	public ShopOptionsLibrary GetShopOptions()
	{
		return shopOptionsLibrary;
	}

	private void Start()
	{
		shopOptionsLibrary = shopOptionsLibraryDemo;
		shoppingCartPanel.BeginWithNormalState();
		cartItemCountPanel.BeginWithNormalState();
		TMP_Text[] array = labelBudget;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].text = WalletSystem.GetPlayerWallet().GetFormattedBudget();
		}
		WalletSystem.GetPlayerWallet().OnBudgetChange.AddListener(delegate(int budget)
		{
			TMP_Text[] array3 = labelBudget;
			foreach (TMP_Text tMP_Text in array3)
			{
				if (budget >= 0)
				{
					tMP_Text.color = Color.white;
				}
				else
				{
					tMP_Text.color = Color.red;
				}
				tMP_Text.text = budget.ToString();
			}
		});
		UpdateDeliveryState();
		UIContentAnimator[] array2 = iconDeliveryCount;
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i].BeginWithNormalState();
		}
		OrderManager.OnOrderChangeEvent.AddListener(delegate
		{
			UpdateDeliveryState();
		});
		DeliverSystem.OnDeliveryArrives.AddListener(delegate
		{
			UpdateDeliveryState();
		});
		ClearOptions();
		LoadOptions(shopOptionsLibrary.shopOptions);
		UpdateDeliveryLocalization();
		LocalizationManager.OnLanguageChange.AddListener(delegate
		{
			ReloadShopOptions(0);
			UpdateDeliveryLocalization();
		});
		ProgressionManager.ListenOnLevelUp(delegate
		{
			ReloadShopOptions(0);
		});
		CountTotal();
		UpdateTotalPackagesInTransport(DeliverSystem.GetCurrentlyActivePackageCount());
		DeliverSystem.OnActiveDeliveryPackagesChanges.AddListener(delegate(int x)
		{
			UpdateTotalPackagesInTransport(x);
		});
	}

	public void ReloadShopOptions(int type)
	{
		ClearOptions();
		List<ShopOption> options = ((type == -1) ? shopOptionsLibrary.shopOptions : shopOptionsLibrary.GetOptionsOfType((ItemInfo.ItemType)type));
		LoadOptions(options);
	}

	private void LoadOptions(List<ShopOption> options)
	{
		for (int i = 0; i < options.Count; i++)
		{
			if (!options[i].notForBuy && (!options[i].locked || options[i].unlockLevel <= ProgressionManager.GetCurrentLevel() + 1))
			{
				ShopContentItem component = Object.Instantiate(contentItemPrefab, content).GetComponent<ShopContentItem>();
				component.Initialize(this, options[i].itemId, options[i]);
				contentItems.Add(component);
			}
		}
	}

	private void ClearOptions()
	{
		contentItems.ForEach(delegate(ShopContentItem x)
		{
			Object.Destroy(x.gameObject);
		});
		contentItems.Clear();
	}

	public void PlaceOrderFromCart()
	{
		int packagesByCartItems = GetPackagesByCartItems();
		if (packagesByCartItems + DeliverSystem.GetCurrentlyActivePackageCount() > DeliverSystem.GetDepotCapacity())
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_shop_ordering_depotcapacityreached", 2f);
			return;
		}
		if (!OrderManager.PlacedOrder(shoppingCart, GetTotalAmount(), packagesByCartItems))
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds("ui_popup_invalid_msg_shop_ordering_notenoughmoney", 2f);
			return;
		}
		UpdateTotalPackagesInTransport(DeliverSystem.GetCurrentlyActivePackageCount());
		ClearCart();
		UpdatePackageCount();
		SoundManager.PlaySoundOnce("management_cashing");
		animatorShoppingCart.OnReverse();
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		PopupMessageManager.GetPopHint().TryShow(hintBoxByTag);
	}

	public void AddItemToCart(ShopOptionsLibrary options, int itemId, int unitPrice, int amount)
	{
		CartItem cartItem = shoppingCart.Find((CartItem x) => x.itemId == itemId);
		if (shoppingCart.Contains(cartItem))
		{
			if (cartItem.amount >= GetMaxAmount())
			{
				cartItem.amount = GetMaxAmount();
				return;
			}
			cartItem.amount += amount;
		}
		else
		{
			cartItem = new CartItem(itemId, unitPrice, amount);
			shoppingCart.Add(cartItem);
		}
		UpdateCart();
	}

	public void SetItemAmountInsideCart(int itemId, int amount)
	{
		if (shoppingCart.Exists((CartItem x) => x.itemId == itemId))
		{
			shoppingCart.Find((CartItem x) => x.itemId == itemId).amount = amount;
		}
		UpdatePackageCount();
		CountTotal();
	}

	public void RemoveItemFromCart(int itemId)
	{
		if (shoppingCart.Exists((CartItem x) => x.itemId == itemId))
		{
			CartItem item = shoppingCart.Find((CartItem x) => x.itemId == itemId);
			shoppingCart.Remove(item);
		}
		UpdatePackageCount();
		CountTotal();
	}

	private void ClearCart()
	{
		shoppingCart.ForEach(delegate(CartItem x)
		{
			Object.Destroy(x.instance.gameObject);
		});
		shoppingCart.Clear();
		UpdateCart();
	}

	private void UpdateCart()
	{
		for (int i = 0; i < shoppingCart.Count; i++)
		{
			CartItem cartItem = shoppingCart[i];
			if (cartItem.instance == null)
			{
				cartItem.instance = Object.Instantiate(shoppingCartItemPrefab, shoppingCartContent);
			}
			ShopContentItem component = cartItem.instance.GetComponent<ShopContentItem>();
			component.info = shopOptionsLibrary.shopOptions.Find((ShopOption x) => x.itemId == cartItem.itemId);
			component.Initialize(this, cartItem.itemId, component.info, cartItem.amount);
		}
		ScrollviewResizer.ResizeContent(shoppingCartContent.GetComponent<RectTransform>(), shoppingCartItemPrefab, shoppingCart.Count, 5f);
		CountTotal();
		UpdatePackageCount();
	}

	private void UpdatePackageCount()
	{
		int packagesByCartItems = GetPackagesByCartItems();
		labelDeliveryCurrentOrderPackageCount.text = packagesByCartItems.ToString();
		if (packagesByCartItems + DeliverSystem.GetCurrentlyActivePackageCount() > DeliverSystem.GetDepotCapacity())
		{
			labelDeliveryCurrentOrderPackageCount.color = Color.red;
		}
		else
		{
			labelDeliveryCurrentOrderPackageCount.color = Color.white;
		}
	}

	private void UpdateTotalPackagesInTransport(int amount)
	{
		labelDeliveryTotalPackagesOnTheWay.text = amount + " / " + DeliverSystem.GetDepotCapacity();
	}

	private void CountTotal()
	{
		int totalAmount = GetTotalAmount();
		for (int i = 0; i < labelsTotal.Length; i++)
		{
			labelsTotal[i].text = totalAmount.ToString();
		}
		if (shoppingCart.Count == 0)
		{
			cartItemCountPanel.OnReverse();
		}
		else
		{
			cartItemCountPanel.OnPlay();
		}
		labelCartItemCount.text = shoppingCart.Count.ToString();
	}

	private int GetPackagesByCartItems()
	{
		return Mathf.CeilToInt((float)GetTotalCartItems() / (float)DeliverSystem.GetMaxPackageCapacity());
	}

	private int GetTotalAmount()
	{
		int num = 0;
		for (int i = 0; i < shoppingCart.Count; i++)
		{
			num += shoppingCart[i].amount * shoppingCart[i].unitPrice;
		}
		return num;
	}

	private int GetTotalCartItems()
	{
		int num = 0;
		for (int i = 0; i < shoppingCart.Count; i++)
		{
			num += shoppingCart[i].amount;
		}
		return num;
	}

	private void UpdateDeliveryState()
	{
		if (OrderManager.HasOrders())
		{
			TMP_Text[] array = labelDeliveryState;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = LocalizationManager.GetLocalizedString(localizationDeliveryStateKeys[0], LocalizationManager.GetTableComputerKeys());
			}
			array = labelDeliveryTime;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = DeliverSystem.GetNextDeliveryTime().GetTimeFormatted();
			}
			array = labelDeliveryCount;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = OrderManager.GetCurrentOrders().Count.ToString();
			}
			UIContentAnimator[] array2 = iconDeliveryCount;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].OnPlay();
			}
		}
		else
		{
			TMP_Text[] array = labelDeliveryState;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = LocalizationManager.GetLocalizedString(localizationDeliveryStateKeys[1], LocalizationManager.GetTableComputerKeys());
			}
			array = labelDeliveryTime;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = "";
			}
			array = labelDeliveryCount;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = "0";
			}
			UIContentAnimator[] array2 = iconDeliveryCount;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].OnReverse();
			}
		}
	}

	private void UpdateDeliveryLocalization()
	{
		if (OrderManager.HasOrders())
		{
			TMP_Text[] array = labelDeliveryState;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = LocalizationManager.GetLocalizedString(localizationDeliveryStateKeys[0], LocalizationManager.GetTableComputerKeys());
			}
			array = labelDeliveryTime;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = DeliverSystem.GetNextDeliveryTime().GetTimeFormatted();
			}
		}
		else
		{
			TMP_Text[] array = labelDeliveryState;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = LocalizationManager.GetLocalizedString(localizationDeliveryStateKeys[1], LocalizationManager.GetTableComputerKeys());
			}
			array = labelDeliveryTime;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].text = "";
			}
		}
	}
}
