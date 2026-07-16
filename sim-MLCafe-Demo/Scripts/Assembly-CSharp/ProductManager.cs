using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ProductManager : MonoBehaviour, IDataPersistence
{
	[SerializeField]
	private ProductLibrary library;

	[SerializeField]
	private List<ProductListingElement> sellingProducts = new List<ProductListingElement>();

	[SerializeField]
	private ProductSizeOption[] sizeOptions = new ProductSizeOption[5]
	{
		new ProductSizeOption(Product.ProductSize.Tiny, 0, locked: false),
		new ProductSizeOption(Product.ProductSize.Small, 0, locked: false),
		new ProductSizeOption(Product.ProductSize.Medium, 0, locked: false),
		new ProductSizeOption(Product.ProductSize.Large, 5, locked: true),
		new ProductSizeOption(Product.ProductSize.Monstrous, 10, locked: true)
	};

	[SerializeField]
	private ProductFlavourOption[] flavourOptions = new ProductFlavourOption[10]
	{
		new ProductFlavourOption(AnomalyTag.CreateByName("Hot"), 0, locked: false, 1),
		new ProductFlavourOption(AnomalyTag.CreateByName("Cold"), 0, locked: false, 0),
		new ProductFlavourOption(AnomalyTag.CreateByName("Strong"), 2, locked: true, 2),
		new ProductFlavourOption(AnomalyTag.CreateByName("Mild"), 0, locked: false, 1),
		new ProductFlavourOption(AnomalyTag.CreateByName("Icy"), 5, locked: true, 3),
		new ProductFlavourOption(AnomalyTag.CreateByName("Spicy"), 10, locked: true, 3),
		new ProductFlavourOption(AnomalyTag.CreateByName("Bloody"), 5, locked: true, 4),
		new ProductFlavourOption(AnomalyTag.CreateByName("Slimy"), 10, locked: true, -1),
		new ProductFlavourOption(AnomalyTag.CreateByName("Refreshing"), 15, locked: true, 5),
		new ProductFlavourOption(AnomalyTag.CreateByName("Energetic"), 20, locked: true, 6)
	};

	public static UnityEvent<Product.ProductSize> OnUnlockNewProductSize = new UnityEvent<Product.ProductSize>();

	public static UnityEvent OnUnlockNewProductFlavour = new UnityEvent();

	private static ProductManager instance;

	public static int GetProductCorePrice()
	{
		return 2;
	}

	public static int GetFlavourCorePrice(int flavour)
	{
		return instance.flavourOptions[flavour].priceValue;
	}

	public static bool IsValidated()
	{
		return instance != null;
	}

	public static ProductSizeOption[] GetAllProductSizes()
	{
		return instance.sizeOptions;
	}

	public static ProductSizeOption[] GetUnlockedProductSizes()
	{
		if (instance.sizeOptions.Any((ProductSizeOption x) => x.locked))
		{
			return instance.sizeOptions.ToList().FindAll((ProductSizeOption x) => !x.locked).ToArray();
		}
		return instance.sizeOptions;
	}

	public static bool IsProductFlavoursUnlocked(int flavour)
	{
		for (int i = 0; i < instance.flavourOptions.Length; i++)
		{
			if (instance.flavourOptions[i].tag.anomalyFlags == flavour)
			{
				return instance.flavourOptions[i].locked;
			}
		}
		return false;
	}

	public static List<int> GetUnlockedProductFlavours()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < instance.flavourOptions.Length; i++)
		{
			if (!instance.flavourOptions[i].locked)
			{
				list.Add(instance.flavourOptions[i].tag.anomalyFlags);
			}
		}
		return list;
	}

	public static List<int> GetDefaultProductFlavours()
	{
		List<int> list = new List<int>();
		for (int i = 0; i < instance.flavourOptions.Length; i++)
		{
			if (instance.GetFlavourByName("Mild").tag.anomalyFlags == instance.flavourOptions[i].tag.anomalyFlags || instance.GetFlavourByName("Hot").tag.anomalyFlags == instance.flavourOptions[i].tag.anomalyFlags)
			{
				list.Add(instance.flavourOptions[i].tag.anomalyFlags);
			}
		}
		return list;
	}

	public static int GetDefaultProductFlavourMask()
	{
		return AnomalyTag.CreateByName(new string[2] { "Mild", "Hot" }).GetFlag();
	}

	public static List<int> GetProductFlavoursByFlag(int flavourFlag)
	{
		return AnomalyTag.GetIndexList(flavourFlag);
	}

	public static ProductFlavourOption GetProductFlavourOptionByName(string name)
	{
		return instance.GetFlavourByName(name);
	}

	private ProductFlavourOption GetFlavourByName(string name)
	{
		for (int i = 0; i < flavourOptions.Length; i++)
		{
			if (flavourOptions[i].tag.GetFormattedTags().Contains(name))
			{
				return flavourOptions[i];
			}
		}
		return null;
	}

	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			UnityEngine.Object.Destroy(this);
		}
		UnityEngine.Object.DontDestroyOnLoad(instance);
	}

	private void Start()
	{
		ProgressionManager.ListenOnLevelUp(delegate(int level)
		{
			TryUnlockFlavourOption(level);
			TryUnlockSizeOptions(level);
		});
	}

	public static ProductLibrary GetProductLibrary()
	{
		return instance.library;
	}

	public static List<ProductListingElement> GetSellingProductList()
	{
		return instance.sellingProducts;
	}

	public static ProductListingElement GetSellingProduct(int slotId)
	{
		return instance.sellingProducts.Find((ProductListingElement x) => x.slotId == slotId);
	}

	public static ProductListingElement GetSellingProductByFlavour(int flavours)
	{
		return instance.sellingProducts.Find((ProductListingElement x) => x.flavours == flavours);
	}

	public static bool AreAllSellingProductsValid()
	{
		bool result = true;
		for (int i = 0; i < instance.sellingProducts.Count; i++)
		{
			if (AnomalyTag.IsInvalidCombination(instance.sellingProducts[i].flavours))
			{
				result = false;
			}
		}
		return result;
	}

	public static void LoadUnlockedOptions()
	{
		instance.TryUnlockFlavourOption(ProgressionManager.GetCurrentLevel());
		instance.TryUnlockSizeOptions(ProgressionManager.GetCurrentLevel());
	}

	private void TryUnlockFlavourOption(int level)
	{
		for (int i = 0; i < flavourOptions.Length; i++)
		{
			if (flavourOptions[i].locked && flavourOptions[i].unlockLevel <= level)
			{
				flavourOptions[i].locked = false;
				OnUnlockNewProductFlavour.Invoke();
			}
		}
	}

	private void TryUnlockSizeOptions(int level)
	{
		bool flag = false;
		int arg = 0;
		for (int i = 0; i < sizeOptions.Length; i++)
		{
			if (sizeOptions[i].unlockLevel <= level)
			{
				sizeOptions[i].locked = false;
				flag = true;
				arg = i;
			}
		}
		if (flag)
		{
			OnUnlockNewProductSize.Invoke((Product.ProductSize)arg);
		}
	}

	public static int RegisterNewProductForSale(string productName, int productId, int flavours, int basePrice)
	{
		ProductListingElement productListingElement = new ProductListingElement(productName, productId, flavours, basePrice);
		productListingElement.productName = productName;
		productListingElement.productId = productId;
		productListingElement.flavours = flavours;
		productListingElement.basePrice = basePrice;
		productListingElement.priceRating = CreatePriceRating(flavours, AnomalyTag.GetIndexList(flavours).Count);
		instance.sellingProducts.Add(productListingElement);
		productListingElement.slotId = Guid.NewGuid().GetHashCode();
		return productListingElement.slotId;
	}

	public static void UnregisterProduct(int slotId)
	{
		instance.sellingProducts.Remove(instance.sellingProducts.Find((ProductListingElement x) => x.slotId == slotId));
	}

	public static void UpdateProductName(int slotId, string newName)
	{
		instance.sellingProducts.Find((ProductListingElement x) => x.slotId == slotId).productName = newName;
	}

	public static void UpdateProductFlavour(int slotId, int newFlavours)
	{
		ProductListingElement productListingElement = instance.sellingProducts.Find((ProductListingElement x) => x.slotId == slotId);
		productListingElement.flavours = newFlavours;
		UpdatePriceRating(productListingElement, newFlavours);
	}

	public static void UpdateProductPrice(int slotId, int newPrice)
	{
		instance.sellingProducts.Find((ProductListingElement x) => x.slotId == slotId).basePrice = newPrice;
	}

	private static void UpdatePriceRating(ProductListingElement productElement, int flavours)
	{
		productElement.priceRating = CreatePriceRating(flavours, AnomalyTag.GetIndexList(flavours).Count);
	}

	public static int GetProductBasePrice(int id)
	{
		return instance.sellingProducts.Find((ProductListingElement x) => x.productId == id).basePrice;
	}

	public static int GetProductPrice(int id, Product.ProductSize size)
	{
		return instance.sellingProducts.Find((ProductListingElement x) => x.productId == id).GetPrice(size);
	}

	public static int GetFlavourCount(int id)
	{
		return AnomalyTag.GetIndexList(instance.sellingProducts.Find((ProductListingElement x) => x.productId == id).flavours).Count;
	}

	public static int GetProductFlavours(int id)
	{
		return instance.sellingProducts.Find((ProductListingElement x) => x.productId == id).flavours;
	}

	public static PriceRating GetPriceRating(int id)
	{
		return instance.sellingProducts.Find((ProductListingElement x) => x.productId == id).priceRating;
	}

	private static PriceRating CreatePriceRating(int flavours, int flavourCount)
	{
		Mathf.InverseLerp(0f, 5f, CafeShopManager.GetCafeShopRating().GetStarRating());
		int productCorePrice = GetProductCorePrice();
		int num = 0;
		for (int i = 0; i < flavourCount; i++)
		{
			int flavour = AnomalyTag.GetIndexList(flavours)[i];
			num += GetFlavourCorePrice(flavour);
		}
		int num2 = productCorePrice * num;
		int minPrice = num2 - GetCafeRatingMinFactor(num2);
		int num3 = num2 + GetCafeRatingMaxFactor(num2);
		if (num3 < 1)
		{
			num3 = 1;
		}
		return new PriceRating(minPrice, num3, num2);
	}

	public static int GetCafeRatingMinFactor(int value)
	{
		float t = Mathf.InverseLerp(0f, 5f, CafeShopManager.GetCafeShopRating().GetStarRating());
		float num = Mathf.Lerp(0.5f, 2f, t) * 0.5f;
		return (int)((float)value * num);
	}

	public static int GetCafeRatingMaxFactor(int value)
	{
		float t = Mathf.InverseLerp(0f, 5f, CafeShopManager.GetCafeShopRating().GetStarRating());
		float num = Mathf.Lerp(-0.5f, 3f, t) * GameModeManager.GetGameModeValue<float>("gm_cafe_price_max") * 0.5f;
		return (int)((float)value * num);
	}

	public void LoadData(GameData data, bool isNewGameData)
	{
		if (!isNewGameData)
		{
			sellingProducts = data.registeredProducts;
		}
	}

	public void SaveData(ref GameData data)
	{
		data.registeredProducts = sellingProducts;
	}
}
