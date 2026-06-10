using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApartmentItemElementController : MonoBehaviour
{
	[Header("Components")]
	public InteractablePreset itemPreset;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI priceText;

	public TextMeshProUGUI sellText;

	public InfoWindow thisWindow;

	public DecorController decorController;

	public ApartmentItemsController itemsController;

	public Image mainImage;

	[NonSerialized]
	public Interactable worldItemReference;

	public ButtonController placeButton;

	public ButtonController storageButton;

	public ButtonController sellButton;

	public Image icon;

	[Header("State")]
	public int price;

	public void SetupItem(InteractablePreset newItemPreset, ApartmentItemsController newDecorController, InfoWindow newThisWindow, Interactable newWorldItemReference)
	{
	}

	public void VisualUpdate()
	{
	}

	public void UpdateButtonText()
	{
	}

	public void OnPlaceButton()
	{
	}

	public void PurchaseConfirm()
	{
	}

	public void PurchaseCancel()
	{
	}

	public void OnStorageButton()
	{
	}

	public void OnSellButton()
	{
	}

	public void UpdatePurchaseAbility()
	{
	}
}
