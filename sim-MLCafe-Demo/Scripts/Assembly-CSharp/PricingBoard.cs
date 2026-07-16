using System;
using System.Collections.Generic;
using UnityEngine;

public class PricingBoard : MonoBehaviour
{
	[SerializeField]
	private GameObject productSlotPrefab;

	[SerializeField]
	private RectTransform productContent;

	[SerializeField]
	private int maxProducts = 3;

	[SerializeField]
	private List<ProductPricingSlot> slots = new List<ProductPricingSlot>();

	[SerializeField]
	private GameObject buttonAddProduct;

	[SerializeField]
	private GameObject buttonExitComputer;

	[Header("Enter Board")]
	[SerializeField]
	private Transform cameraPoint;

	[SerializeField]
	private Transform fallbackPoint;

	[SerializeField]
	private string hintTag = "PricingBoard";

	[Header("Localization")]
	[SerializeField]
	private string localizationKeyInvalidCafeOpen;

	[SerializeField]
	private string localizationKeyInvalidCustomers;

	private bool isUsingBoard;

	private bool transition;

	private void Start()
	{
		Init();
	}

	public int GetSlotCount()
	{
		return slots.Count;
	}

	private void Init()
	{
		InputManager.OnCancelMenuWindow.AddListener(delegate
		{
			if (isUsingBoard)
			{
				OnExitBoard();
			}
		});
		UpdateEditToolsVisibility(visible: false);
	}

	public void OnEnterBoard(CharacterControllerComponent character)
	{
		if (CafeShopManager.IsCafeOpen())
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidCafeOpen);
			return;
		}
		if (CafeShopManager.CustomersInCafe())
		{
			PopupMessageManager.GetInValidOrMissingPopUp().ShowMessageForSeconds(localizationKeyInvalidCustomers);
			return;
		}
		HintBox hintBoxByTag = PopupMessageManager.GetPopHint().GetHintBoxByTag(hintTag);
		if (!PopupMessageManager.GetPopHint().TryShow(hintBoxByTag) && !isUsingBoard)
		{
			fallbackPoint.position = GlobalReferences.GetCameraController().GetCamera().transform.position;
			fallbackPoint.rotation = GlobalReferences.GetCameraController().GetCamera().transform.rotation;
			GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.MenuOpen);
			TweenerManager.Tween("EnterComputer", GlobalReferences.GetCameraController().GetCamera().transform, fallbackPoint, cameraPoint, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve());
			isUsingBoard = true;
			InputManager.OnMainClick.AddListener(OnBoardClick);
			UpdateEditToolsVisibility(visible: true);
		}
	}

	public void OnExitBoard()
	{
		if (!transition)
		{
			transition = true;
			Action executeOnFinish = delegate
			{
				GameStateManager.ChangeCharacterState(GameStateManager.CharacterState.CharacterMode);
				isUsingBoard = false;
				GlobalReferences.GetCameraController().GetCamera().transform.position = fallbackPoint.position;
				GlobalReferences.GetCameraController().GetCamera().transform.rotation = fallbackPoint.rotation;
				transition = false;
			};
			TweenerManager.Tween("ExitComputer", GlobalReferences.GetCameraController().GetCamera().transform, cameraPoint, fallbackPoint, TweenerManager.GetDefaultDuration(), TweenerManager.GetDefaultEaseCurve(), executeOnFinish);
			InputManager.OnMainClick.RemoveListener(OnBoardClick);
			slots.RemoveAll((ProductPricingSlot x) => x == null);
			UpdateEditToolsVisibility(visible: false);
		}
	}

	private void OnBoardClick()
	{
		SoundManager.PlaySoundOnce("ui_button_tapping");
	}

	[ContextMenu("Create Slot")]
	public void CreateProductSlot()
	{
		if (slots.Count < maxProducts)
		{
			ProductPricingSlot component = UnityEngine.Object.Instantiate(productSlotPrefab, productContent).GetComponent<ProductPricingSlot>();
			component.OnCreateSlot(ProductManager.GetProductLibrary().GetAsProduct(0), this);
			slots.Add(component);
			buttonAddProduct.transform.SetAsLastSibling();
			UpdateEditToolsVisibility(visible: true);
		}
	}

	public void RemoveProductSlot(ProductPricingSlot slot)
	{
		if (slots.Contains(slot))
		{
			slots.Remove(slot);
		}
		UpdateEditToolsVisibility(visible: true);
	}

	private void UpdateEditToolsVisibility(bool visible)
	{
		if (slots.Count >= maxProducts)
		{
			buttonAddProduct.SetActive(value: false);
		}
		else
		{
			buttonAddProduct.SetActive(visible);
		}
		buttonExitComputer.SetActive(visible);
		slots.ForEach(delegate(ProductPricingSlot slot)
		{
			slot.UpdateEditToolsVisibility(visible);
		});
	}

	public void LoadBoardSlots(GameData data, bool isNewGameData)
	{
		if (!isNewGameData)
		{
			bool flag = ProductManager.GetSellingProductList().Count != data.registeredProducts.Count;
			Init();
			slots.Clear();
			for (int i = 0; i < ProductManager.GetSellingProductList().Count; i++)
			{
				ProductPricingSlot component = UnityEngine.Object.Instantiate(productSlotPrefab, productContent).GetComponent<ProductPricingSlot>();
				slots.Add(component);
				component.OnCreateSlotByExistingListingProduct(flag ? data.registeredProducts[i] : ProductManager.GetSellingProductList()[i], this);
				buttonAddProduct.transform.SetAsLastSibling();
			}
			UpdateEditToolsVisibility(visible: false);
		}
	}
}
