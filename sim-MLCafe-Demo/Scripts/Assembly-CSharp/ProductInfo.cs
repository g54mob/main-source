using System;
using UnityEngine;

[Serializable]
public class ProductInfo
{
	public enum ProductType
	{
		Drink = 0,
		Food = 1
	}

	public ProductType productType;

	public string productName;

	public string productDescription;

	public string localizeKey;

	public int basePrice;

	public Item[] requiredIngredients;

	[Header("Must Have Tags")]
	public AnomalyTag defaultTag;

	[Header("Invalid Tags")]
	public AnomalyTag invalidTags;
}
