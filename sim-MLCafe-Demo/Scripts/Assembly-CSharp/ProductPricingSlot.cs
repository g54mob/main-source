using System.Collections;
using System.Collections.Generic;
using MLCN_Localization;
using TMPro;
using UnityEngine;

public class ProductPricingSlot : MonoBehaviour
{
	private int slotId;

	private int productId;

	private int flavours;

	private int price;

	[Header("Interface")]
	[SerializeField]
	private TMP_InputField inputFieldProductName;

	[SerializeField]
	private TMP_InputField inputFieldProductPrice;

	[SerializeField]
	private TMP_Text labelFlavours;

	[SerializeField]
	private GameObject buttonRemoveProduct;

	[SerializeField]
	private ProductPricingSizeSlot[] sizeSlots;

	[SerializeField]
	private GameObject flavourToggleDropdownButton;

	[SerializeField]
	private GameObject flavourToggleDropdown;

	[SerializeField]
	private ProductFlavourToggle[] flavourToggles;

	[SerializeField]
	private GameObject[] editInteractionObjects;

	private ProductSlotData saveData = new ProductSlotData();

	private bool create;

	private PricingBoard pricingBoard;

	private bool loadGameData;

	private void Start()
	{
		if (!loadGameData)
		{
			Init();
		}
	}

	private void Init()
	{
		ProductPricingSizeSlot[] array = sizeSlots;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].gameObject.SetActive(value: false);
		}
		SetEventListeners(remove: false);
		if (!create)
		{
			InitFlavourToggles();
			UpdateEditToolsVisibility(visible: false);
			inputFieldProductPrice.onEndEdit.AddListener(delegate
			{
				inputFieldProductPrice.text = "$" + ProductManager.GetProductBasePrice(slotId) + ",00";
			});
			UpdateSizePrices();
		}
	}

	public ProductSlotData GetSaveData()
	{
		return saveData;
	}

	public int GetFlavours()
	{
		return flavours;
	}

	private void SetEventListeners(bool remove)
	{
		if (remove)
		{
			inputFieldProductName.onValueChanged.RemoveListener(delegate(string x)
			{
				UpdateProductName(x);
			});
			inputFieldProductPrice.onValueChanged.RemoveListener(delegate(string x)
			{
				UpdateProductPrice(x);
			});
			inputFieldProductPrice.onValueChanged.RemoveListener(delegate
			{
				UpdateSizePrices();
			});
			ProductManager.OnUnlockNewProductSize.RemoveListener(delegate(Product.ProductSize x)
			{
				UpdateSizeOptions((int)x);
			});
			ProductManager.OnUnlockNewProductFlavour.RemoveListener(delegate
			{
				UnlockFlavourToggles();
			});
			LocalizationManager.OnLanguageChange.RemoveListener(delegate
			{
				OnUpdateSlot(slotId);
			});
		}
		else
		{
			inputFieldProductName.onValueChanged.AddListener(delegate(string x)
			{
				UpdateProductName(x);
			});
			inputFieldProductPrice.onValueChanged.AddListener(delegate(string x)
			{
				UpdateProductPrice(x);
			});
			inputFieldProductPrice.onValueChanged.AddListener(delegate
			{
				UpdateSizePrices();
			});
			ProductManager.OnUnlockNewProductSize.AddListener(delegate(Product.ProductSize x)
			{
				UpdateSizeOptions((int)x);
			});
			ProductManager.OnUnlockNewProductFlavour.AddListener(delegate
			{
				UnlockFlavourToggles();
			});
			LocalizationManager.OnLanguageChange.AddListener(delegate
			{
				OnUpdateSlot(slotId);
			});
		}
	}

	public void InitFlavourToggles(bool skipDefaultSetup = true)
	{
		if (loadGameData)
		{
			return;
		}
		List<int> unlockedProductFlavours = ProductManager.GetUnlockedProductFlavours();
		List<int> defaultProductFlavours = ProductManager.GetDefaultProductFlavours();
		for (int i = 0; i < flavourToggles.Length; i++)
		{
			flavourToggles[i].Init(this, i);
			if (!unlockedProductFlavours.Contains(flavourToggles[i].tag.anomalyFlags))
			{
				flavourToggles[i].gameObject.SetActive(value: false);
			}
			else
			{
				flavourToggles[i].gameObject.SetActive(value: true);
			}
			if (skipDefaultSetup)
			{
				continue;
			}
			for (int j = 0; j < defaultProductFlavours.Count; j++)
			{
				if (flavourToggles[i].tag.anomalyFlags == defaultProductFlavours[j])
				{
					flavourToggles[i].SetToggleWithoutNotify(value: true);
				}
			}
		}
		flavourToggleDropdown.SetActive(value: false);
	}

	public void InitFlavourTogglesAndReset()
	{
		List<int> unlockedProductFlavours = ProductManager.GetUnlockedProductFlavours();
		for (int i = 0; i < flavourToggles.Length; i++)
		{
			flavourToggles[i].Init(this, i);
			flavourToggles[i].SetToggleWithoutNotify(value: false);
			if (!unlockedProductFlavours.Contains(flavourToggles[i].tag.anomalyFlags))
			{
				flavourToggles[i].gameObject.SetActive(value: false);
			}
			else
			{
				flavourToggles[i].gameObject.SetActive(value: true);
			}
		}
		flavourToggleDropdown.SetActive(value: false);
	}

	private void UnlockFlavourToggles()
	{
		List<int> unlockedProductFlavours = ProductManager.GetUnlockedProductFlavours();
		for (int i = 0; i < flavourToggles.Length; i++)
		{
			flavourToggles[i].Init(this, i);
			if (!unlockedProductFlavours.Contains(flavourToggles[i].tag.anomalyFlags))
			{
				flavourToggles[i].gameObject.SetActive(value: false);
			}
			else
			{
				flavourToggles[i].gameObject.SetActive(value: true);
			}
		}
		flavourToggleDropdown.SetActive(value: false);
	}

	private void SetFlavourTogglesWithoutNotify(int mask)
	{
		List<int> indexList = AnomalyTag.GetIndexList(mask);
		for (int i = 0; i < flavourToggles.Length; i++)
		{
			for (int j = 0; j < indexList.Count; j++)
			{
				if (flavourToggles[i].tag.anomalyFlags == indexList[j])
				{
					flavourToggles[i].SetToggleWithoutNotify(value: true);
				}
				else
				{
					flavourToggles[i].SetToggleWithoutNotify(value: false);
				}
			}
		}
	}

	public void ToggleFlavourDropdown()
	{
		flavourToggleDropdown.SetActive(!flavourToggleDropdown.activeInHierarchy);
	}

	public void OnCreateSlot(Product product, PricingBoard board, bool register = true, int predefinedSlotId = -1)
	{
		pricingBoard = board;
		create = true;
		string text = LocalizationManager.GetLocalizedString(product.GetInfo().localizeKey, LocalizationDataTable.Tables.ProductBoard) + " " + (board.GetSlotCount() + 1);
		flavours = 0;
		int basePrice = 1;
		inputFieldProductName.text = text;
		inputFieldProductPrice.text = basePrice.ToString();
		labelFlavours.text = LocalizationManager.GetLocalizedString("product_ui_label_noflavours", LocalizationDataTable.Tables.ProductBoard);
		price = basePrice;
		productId = product.id;
		if (register)
		{
			slotId = ProductManager.RegisterNewProductForSale(text, product.id, flavours, basePrice);
		}
		else
		{
			slotId = predefinedSlotId;
		}
		InitFlavourToggles();
		for (int i = 0; i < ProductManager.GetUnlockedProductSizes().Length; i++)
		{
			UpdateSizeOptions(i);
		}
		UpdateEditToolsVisibility(visible: true);
		StartCoroutine(InitializeSizePriceList());
	}

	public void OnCreateSlotByExistingListingProduct(ProductListingElement productElement, PricingBoard board)
	{
		pricingBoard = board;
		create = true;
		inputFieldProductName.text = productElement.productName;
		flavours = productElement.flavours;
		inputFieldProductPrice.text = productElement.basePrice.ToString();
		price = productElement.basePrice;
		productId = productElement.productId;
		slotId = productElement.slotId;
		InitFlavourTogglesAndReset();
		List<int> productFlavoursByFlag = ProductManager.GetProductFlavoursByFlag(productElement.flavours);
		for (int i = 0; i < productFlavoursByFlag.Count; i++)
		{
			flavourToggles[productFlavoursByFlag[i]].SetToggleWithoutNotify(value: true);
		}
		for (int j = 0; j < ProductManager.GetUnlockedProductSizes().Length; j++)
		{
			UpdateSizeOptions(j);
		}
		UpdateEditToolsVisibility(visible: true);
		StartCoroutine(InitializeSizePriceList());
	}

	private IEnumerator InitializeSizePriceList()
	{
		yield return new WaitForSeconds(0.25f);
		UpdateProductPrice(price.ToString());
		UpdateSizePrices();
		StopCoroutine(InitializeSizePriceList());
	}

	private void OnUpdateSlot(int slotId)
	{
		string formattedLocalizedTags = ProductManager.GetSellingProduct(slotId).GetTag().GetFormattedLocalizedTags();
		labelFlavours.text = ((formattedLocalizedTags != "") ? formattedLocalizedTags : LocalizationManager.GetLocalizedString("product_ui_label_noflavours", LocalizationDataTable.Tables.ProductBoard));
		for (int i = 0; i < flavourToggles.Length; i++)
		{
			flavourToggles[i].UpdateLocalization();
		}
		UpdateSizePrices();
	}

	public void RemoveProductSlot()
	{
		LocalizationManager.OnLanguageChange.RemoveListener(delegate
		{
			OnUpdateSlot(slotId);
		});
		ProductManager.UnregisterProduct(slotId);
		SetEventListeners(remove: true);
		pricingBoard.RemoveProductSlot(this);
		Object.Destroy(base.gameObject);
	}

	public void UpdateFlavourSelection(int mask)
	{
		flavours = mask;
		ProductManager.UpdateProductFlavour(slotId, flavours);
		string formattedLocalizedTags = ProductManager.GetSellingProduct(slotId).GetTag().GetFormattedLocalizedTags();
		labelFlavours.text = ((formattedLocalizedTags != "") ? formattedLocalizedTags : LocalizationManager.GetLocalizedString("product_ui_label_noflavours", LocalizationDataTable.Tables.ProductBoard));
		TryCheckTutorialOption();
	}

	public void UpdateFlavourDisplay(int mask)
	{
		flavours = mask;
		string formattedLocalizedTags = ProductManager.GetSellingProduct(slotId).GetTag().GetFormattedLocalizedTags();
		labelFlavours.text = ((formattedLocalizedTags != "") ? formattedLocalizedTags : LocalizationManager.GetLocalizedString("product_ui_label_noflavours", LocalizationDataTable.Tables.ProductBoard));
	}

	private void UpdateProductName(string newName)
	{
		ProductManager.UpdateProductName(slotId, newName);
	}

	private void UpdateProductPrice(string newPrice)
	{
		if (newPrice == string.Empty || int.Parse(newPrice) <= 0)
		{
			price = 1;
			inputFieldProductPrice.SetTextWithoutNotify(price.ToString());
		}
		else
		{
			price = int.Parse(newPrice);
		}
		ProductManager.UpdateProductPrice(slotId, price);
		TryCheckTutorialOption();
	}

	public void UpdateEditToolsVisibility(bool visible)
	{
		buttonRemoveProduct.SetActive(visible);
		flavourToggleDropdownButton.SetActive(visible);
		if (!visible)
		{
			flavourToggleDropdown.SetActive(value: false);
			inputFieldProductName.ReleaseSelection();
			inputFieldProductPrice.ReleaseSelection();
		}
		GameObject[] array = editInteractionObjects;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].SetActive(visible);
		}
	}

	private void UpdateSizePrices()
	{
		ProductSizeOption[] unlockedProductSizes = ProductManager.GetUnlockedProductSizes();
		for (int i = 0; i < unlockedProductSizes.Length; i++)
		{
			if (!unlockedProductSizes[i].locked)
			{
				UpdateSizeOptions(i);
			}
			else
			{
				sizeSlots[i].gameObject.SetActive(value: false);
			}
		}
	}

	private void UpdateSizeOptions(int newSize)
	{
		sizeSlots[newSize].gameObject.SetActive(value: true);
		ProductListingElement sellingProduct = ProductManager.GetSellingProduct(slotId);
		sizeSlots[newSize].UpdatePrice(newSize, sellingProduct.GetPrice((Product.ProductSize)newSize));
	}

	private void TryCheckTutorialOption()
	{
		if ((TutorialManager.IsRunning() || PopupMessageManager.GetCheckListPopUp().IsVisible()) && !TutorialManager.GetSectionOfState(TutorialManager.TutorialState.RunCafe).GetCheckListOption("AddProductHotMild").check && price >= 5 && price <= 14 && flavours == ProductManager.GetDefaultProductFlavourMask())
		{
			TutorialManager.TryCheckSectionChecklistOption("AddProductHotMild", TutorialManager.TutorialState.RunCafe);
		}
	}
}
