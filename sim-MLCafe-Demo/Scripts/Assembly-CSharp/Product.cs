using System;
using MLCN_Localization;

[Serializable]
public class Product
{
	public enum ProductSize
	{
		Tiny = 0,
		Small = 1,
		Medium = 2,
		Large = 3,
		Monstrous = 4
	}

	public int id;

	public ProductSize size;

	public AnomalyTag appliedTags;

	public bool isFilled;

	public Product(int libraryIndex, ProductSize size, AnomalyTag tags, bool isFilled)
	{
		id = libraryIndex;
		this.size = size;
		appliedTags = tags;
		this.isFilled = isFilled;
	}

	public Product(int libraryIndex, ProductSize size)
	{
		id = libraryIndex;
		this.size = size;
		isFilled = false;
	}

	public Product(int libraryIndex)
	{
		id = libraryIndex;
		size = ProductSize.Medium;
		isFilled = false;
	}

	public bool IsValid()
	{
		if (appliedTags.anomalyFlags != 0)
		{
			return isFilled;
		}
		return false;
	}

	public ProductInfo GetInfo()
	{
		return ProductManager.GetProductLibrary().GetProductInfo(id);
	}

	public int GetBaseWorth()
	{
		return ProductManager.GetProductBasePrice(id);
	}

	public static string GetLocalizedSize(ProductSize size)
	{
		return GetLocalizedSize((int)size);
	}

	public static string GetLocalizedSize(int size)
	{
		return LocalizationManager.GetLocalizedString((new string[5] { "product_cupsize_tiny", "product_cupsize_small", "product_cupsize_medium", "product_cupsize_large", "product_cupsize_monstrous" })[size], LocalizationDataTable.Tables.ProductBoard);
	}
}
