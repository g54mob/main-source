using System;
using MLCN_Localization;

[Serializable]
public class ProductSizeOption
{
	public Product.ProductSize size;

	public int unlockLevel;

	public bool locked;

	public ProductSizeOption(Product.ProductSize size, int unlockLevel, bool locked)
	{
		this.size = size;
		this.unlockLevel = unlockLevel;
		this.locked = locked;
	}

	public string GetLocalizedName()
	{
		return size switch
		{
			Product.ProductSize.Tiny => LocalizationManager.GetLocalizedString("product_cupsize_tiny", LocalizationDataTable.Tables.ProductBoard), 
			Product.ProductSize.Small => LocalizationManager.GetLocalizedString("product_cupsize_small", LocalizationDataTable.Tables.ProductBoard), 
			Product.ProductSize.Medium => LocalizationManager.GetLocalizedString("product_cupsize_medium", LocalizationDataTable.Tables.ProductBoard), 
			Product.ProductSize.Large => LocalizationManager.GetLocalizedString("product_cupsize_large", LocalizationDataTable.Tables.ProductBoard), 
			Product.ProductSize.Monstrous => LocalizationManager.GetLocalizedString("product_cupsize_monstrous", LocalizationDataTable.Tables.ProductBoard), 
			_ => "...", 
		};
	}

	public float GetFactor()
	{
		return GetSizeFactors()[(int)size];
	}

	public static float[] GetSizeFactors()
	{
		return new float[5] { 0.75f, 0.9f, 1f, 1.125f, 1.25f };
	}
}
