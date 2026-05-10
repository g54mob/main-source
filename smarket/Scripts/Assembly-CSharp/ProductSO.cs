using System;
using MyBox;
using NaisuPorter.CommonScripts;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
[CreateAssetMenu(fileName = "New Product", menuName = "Scriptable Objects/Product/Product")]
public class ProductSO : ScriptableObject
{
	[Serializable]
	public enum ProductCategory
	{
		EDIBLE = 0,
		DRINK = 1,
		CLEANING = 2,
		BOOK = 3,
		CLOTHING = 4,
		ELECTRONICS = 5,
		HARDWARE = 6,
		KITCHEN = 7,
		BAKERY = 8,
		OVEN = 9,
		ICE_CREAM = 10
	}

	public int ID;

	[Separator("Product Info", false)]
	public string ProductName;

	public LocalizedString LocalizedName;

	public string ProductBrand;

	public Sprite ProductIcon;

	public int AtlasIndex;

	public SerializableVector2Int AtlasPosition;

	public DisplayType ProductDisplayType;

	public ProductCategory Category;

	public Product ProductPrefab;

	public bool IsHiddenInMarketApp;

	public bool IsHiddenForCustomer;

	public bool IsBakeryProduct;

	public bool CanPlaceVending;

	[Separator("Purchase Info", false)]
	public int ProductAmountOnPurchase;

	public float BasePrice;

	public float MinDynamicPrice;

	public float MaxDynamicPrice;

	[Separator("Pricing Settings", false)]
	public float OptimumProfitRate;

	public float MaxProfitRate;

	public bool ExemptFromChange;

	[Separator("3D Grid Layout", false)]
	public GridLayout3D.GridLayout GridLayoutInBox;

	public GridLayout3D.GridLayout GridLayoutInStorage;

	[Separator("Animation Properties", false)]
	public float PlacementSpeedMultiplier;

	public Vector3 HandOffset;

	public Vector3 HandRotationOffset;

	[Separator("Grid Size On Checkout", false)]
	public SerializableVector2Int ItemGridSize;

	[Separator("Grid Size On Crate", false)]
	public Vector3Int ItemGridSizeInCrate;

	public Vector3 CrateScale;

	public Vector3 CrateOffset;

	public bool CanNOTRotate;

	[Separator("Grid Size On Vending", false)]
	public float VendingScaleMultiplier;

	public int MaxVendingSlotCount;

	public int MaxVendingColumnCount;

	public Vector3 VendingRotationEuler;

	[Separator("Product Name Displaying Settings", false)]
	public Color ProductNameColor;

	public float ProductNameSizeRatio;

	public string TempProductName => null;

	public virtual float BoxPrice => 0f;

	public string ComplexName(float fontSize)
	{
		return null;
	}

	public virtual Product CreateCheckoutGraphics(int count)
	{
		return null;
	}
}
