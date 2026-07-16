using System.Collections.Generic;
using System.Linq;
using MLCN_Localization;
using UnityEngine;

public class ProductComponent : MonoBehaviour
{
	[SerializeField]
	private Product.ProductSize fixedProductSize;

	[SerializeField]
	private Product holdingProduct;

	[SerializeField]
	private GameObject fill;

	[SerializeField]
	private SkinnedMeshRenderer skinnedMeshRenderer;

	[SerializeField]
	private ParticleSystem psFilledFeedback;

	private bool isHolding;

	[SerializeField]
	private bool startReady;

	[SerializeField]
	private bool resetProductWhenEmpty;

	private void Start()
	{
		if (fill != null)
		{
			fill.SetActive(startReady);
		}
		isHolding = startReady;
		if (!startReady)
		{
			holdingProduct = null;
		}
		if (skinnedMeshRenderer != null)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(0, startReady ? 100 : 0);
		}
		if (resetProductWhenEmpty)
		{
			GetComponent<ItemComponent>().OnEmpty.AddListener(delegate
			{
				ClearProduct();
			});
		}
	}

	public Product GetProduct()
	{
		return holdingProduct;
	}

	public string GetProductName(bool byFlavour = false)
	{
		ProductListingElement productListingElement = null;
		if (byFlavour)
		{
			if (ProductManager.GetSellingProductList().Count > 0)
			{
				productListingElement = ProductManager.GetSellingProductByFlavour(holdingProduct.appliedTags.anomalyFlags);
				if (productListingElement != null)
				{
					return productListingElement.productName;
				}
				return LocalizationManager.GetLocalizedString("product_unknown", LocalizationDataTable.Tables.ProductBoard);
			}
			ProductInfo productInfo = ProductManager.GetProductLibrary().GetProductInfo(holdingProduct.id);
			if (productInfo != null)
			{
				return productInfo.productName;
			}
			return LocalizationManager.GetLocalizedString("product_unknown", LocalizationDataTable.Tables.ProductBoard);
		}
		if (ProductManager.GetSellingProductList().Count > 0)
		{
			productListingElement = ProductManager.GetSellingProduct(holdingProduct.id);
			if (productListingElement != null)
			{
				return productListingElement.productName;
			}
			return LocalizationManager.GetLocalizedString("product_unknown", LocalizationDataTable.Tables.ProductBoard);
		}
		return ProductManager.GetProductLibrary().GetProductInfo(holdingProduct.id).productName;
	}

	public string GetProductTagsFormatted()
	{
		return holdingProduct.appliedTags.GetFormattedLocalizedTags();
	}

	public bool IsHoldingProduct()
	{
		return isHolding;
	}

	public void ApplyProduct(ProductInfo.ProductType type, Item[] ingredients, Product.ProductSize size = Product.ProductSize.Medium, AnomalyTag additionalTags = null)
	{
		if (psFilledFeedback != null)
		{
			TweenerManager.TweenTimeAction("DelayFillUpEffect", 0.3f, delegate
			{
				psFilledFeedback.Play();
			});
		}
		List<ProductInfo> productInfoOfType = ProductManager.GetProductLibrary().GetProductInfoOfType(type);
		ProductInfo matchingProduct = null;
		AnomalyTag anomalyTag = new AnomalyTag();
		isHolding = true;
		anomalyTag.anomalyFlags = additionalTags.anomalyFlags;
		productInfoOfType.ForEach(delegate(ProductInfo product)
		{
			int num = product.requiredIngredients.Length;
			int num2 = 0;
			int i;
			for (i = 0; i < ingredients.Length; i++)
			{
				if (product.requiredIngredients.ToList().Exists((Item x) => x.id == ingredients[i].id))
				{
					num2++;
				}
			}
			if (num2 == num)
			{
				matchingProduct = product;
			}
		});
		if (matchingProduct != null)
		{
			holdingProduct = ProductManager.GetProductLibrary().GetProductFromInfo(matchingProduct, fixedProductSize);
			holdingProduct.appliedTags = anomalyTag;
			holdingProduct.isFilled = true;
			if (skinnedMeshRenderer != null && fill != null)
			{
				TweenerManager.TweenBlendShape("FillCoffee", skinnedMeshRenderer, 0, 0f, 100f, 1f, TweenerManager.GetDefaultEaseCurve(), delegate
				{
					fill.SetActive(value: true);
				});
			}
		}
		else if (fill != null)
		{
			fill.SetActive(value: false);
		}
	}

	public void TransferProduct(Product product, Product.ProductSize size)
	{
		if (psFilledFeedback != null)
		{
			TweenerManager.TweenTimeAction("DelayFillUpEffect", 0.3f, delegate
			{
				psFilledFeedback.Play();
			});
		}
		holdingProduct = new Product(product.id, size, product.appliedTags, product.isFilled);
		isHolding = product.isFilled;
		if (skinnedMeshRenderer != null && fill != null)
		{
			TweenerManager.TweenBlendShape("FillCoffee", skinnedMeshRenderer, 0, 0f, 100f, 1f, TweenerManager.GetDefaultEaseCurve(), delegate
			{
				fill.SetActive(value: true);
			});
		}
	}

	public void SetProduct(Product product)
	{
		holdingProduct = new Product(product.id, product.size, product.appliedTags, product.isFilled);
		startReady = product.isFilled;
		isHolding = product.isFilled;
		if (skinnedMeshRenderer != null && fill != null)
		{
			TweenerManager.TweenBlendShape("FillCoffee", skinnedMeshRenderer, 0, 0f, 100f, 1f, TweenerManager.GetDefaultEaseCurve(), delegate
			{
				fill.SetActive(value: true);
			});
		}
	}

	public void ClearProduct()
	{
		if (holdingProduct != null)
		{
			holdingProduct.isFilled = false;
		}
		holdingProduct = null;
		isHolding = false;
		if (skinnedMeshRenderer != null)
		{
			skinnedMeshRenderer.SetBlendShapeWeight(0, 0f);
		}
		if (fill != null)
		{
			fill.SetActive(value: false);
		}
	}
}
