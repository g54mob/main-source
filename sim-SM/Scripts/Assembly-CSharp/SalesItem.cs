using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class SalesItem : SalesUIElement
{
	[Header("Sales Item")]
	[SerializeField]
	private Image m_ProductIcon;

	[SerializeField]
	private TextMeshProUGUI m_ProductAmountText;

	[SerializeField]
	private LocalizeStringEvent m_ProductStorageTypeText;

	[SerializeField]
	private TextMeshProUGUI m_InventoryProductAmountText;

	[Header("Price Change")]
	[SerializeField]
	private Image m_PriceChangeIndicator;

	[SerializeField]
	private Sprite m_IncreasedPriceArrow;

	[SerializeField]
	private Sprite m_DecreasedPriceArrow;

	[SerializeField]
	private Color m_IncreasedPriceColor;

	[SerializeField]
	private Color m_DecreasedPriceColor;

	private ProductViewer m_ProductViewer;

	public string ProductName => null;

	public string ProductBrand => null;

	public DisplayType StorageType => default(DisplayType);

	public ProductSO.ProductCategory ProductType => default(ProductSO.ProductCategory);

	public int ProductID => 0;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void Setup(int productID, ProductViewer productViewer)
	{
	}

	protected override void UpdateLocalizeText(Locale _ = null)
	{
	}

	public void AddToCart()
	{
	}

	private void LoadCostChangesData()
	{
	}

	private void CostChanged(List<int> products)
	{
	}

	private void CostChanged()
	{
	}

	public void UpdateInventoryAmountText()
	{
	}

	private void OnPriceManagerDisabled()
	{
	}
}
