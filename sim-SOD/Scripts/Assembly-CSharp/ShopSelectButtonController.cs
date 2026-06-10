using TMPro;
using UnityEngine.UI;

public class ShopSelectButtonController : ButtonController
{
	public InteractablePreset preset;

	public Interactable sellInteractable;

	public SyncDiskPreset syncDisk;

	public int price;

	public TextMeshProUGUI priceText;

	public TextMeshProUGUI specialText;

	public InfoWindow thisWindow;

	public BuyInterfaceController buyController;

	public Image mainImage;

	public bool todayOnly;

	public bool sellMode;

	public void Setup(InteractablePreset newPreset, int newPrice, BuyInterfaceController newBuyController, InfoWindow newThisWindow, SyncDiskPreset newSyncDisk = null, bool newTemp = false, Interactable newSellInteractable = null, bool newSellMode = false)
	{
	}

	public override void UpdateButtonText()
	{
	}

	public void UpdateTooltip()
	{
	}

	public override void OnLeftClick()
	{
	}

	public void PurchaseExecute()
	{
	}

	public void SellExecute()
	{
	}

	public void Cancel()
	{
	}

	public void UpdatePurchaseAbility()
	{
	}
}
