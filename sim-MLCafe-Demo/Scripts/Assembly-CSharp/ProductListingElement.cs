using System;
using UnityEngine;

[Serializable]
public class ProductListingElement
{
	public string productName;

	public int productId;

	public int flavours;

	public int basePrice;

	public float[] sizeMultiplier;

	public PriceRating priceRating;

	public int slotId;

	public ProductListingElement(Product product)
	{
		productId = product.id;
		basePrice = product.GetInfo().basePrice;
		sizeMultiplier = ProductSizeOption.GetSizeFactors();
	}

	public ProductListingElement(int id, ProductInfo info)
	{
		productId = id;
		basePrice = info.basePrice;
		sizeMultiplier = ProductSizeOption.GetSizeFactors();
	}

	public ProductListingElement(string productName, int productId, int flavours, int basePrice)
	{
		this.productName = productName;
		this.productId = productId;
		this.flavours = flavours;
		this.basePrice = basePrice;
		sizeMultiplier = ProductSizeOption.GetSizeFactors();
	}

	public Product AsProduct()
	{
		return new Product(productId);
	}

	public int GetPrice(Product.ProductSize size)
	{
		if (sizeMultiplier.Length == 0)
		{
			sizeMultiplier = ProductSizeOption.GetSizeFactors();
		}
		float num = Mathf.FloorToInt((float)basePrice * sizeMultiplier[(int)size]);
		if (num < 1f)
		{
			num = 1f;
		}
		return (int)num;
	}

	public AnomalyTag GetTag()
	{
		return new AnomalyTag
		{
			anomalyFlags = flavours
		};
	}
}
