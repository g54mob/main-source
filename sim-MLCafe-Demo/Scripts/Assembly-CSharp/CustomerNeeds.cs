using System;
using MLCN_Localization;
using UnityEngine;

[Serializable]
public class CustomerNeeds
{
	public int sellingProductId;

	public Product.ProductSize productSize;

	public CustomerNeeds(Product.ProductSize preferredSize = Product.ProductSize.Medium)
	{
		productSize = preferredSize;
		if (!ProductManager.IsValidated() || ProductManager.GetSellingProductList().Count == 0)
		{
			sellingProductId = -1;
			return;
		}
		int index = UnityEngine.Random.Range(0, ProductManager.GetSellingProductList().Count);
		ProductListingElement productListingElement = ProductManager.GetSellingProductList()[index];
		sellingProductId = productListingElement.slotId;
	}

	public string GetProductDialog()
	{
		string highlightBegin = PopupMessageManager.GetHighlightBegin();
		string highlightEnd = PopupMessageManager.GetHighlightEnd();
		string productName = ProductManager.GetSellingProduct(sellingProductId).productName;
		string localizedString = LocalizationManager.GetLocalizedString(DialogManager.GetCustomerDialogProductSizes().dialogKeys[(int)productSize], LocalizationDataTable.Tables.Dialogs);
		return highlightBegin + localizedString + "  " + productName + highlightEnd + "!";
	}

	public byte EvaluateReceivingProduct(Product receivingProduct, AnomalyTag receivingAdditionalTags)
	{
		byte b = 0;
		ProductListingElement sellingProduct = ProductManager.GetSellingProduct(sellingProductId);
		if (sellingProduct.productId == receivingProduct.id)
		{
			b += 128;
		}
		if (productSize == receivingProduct.size)
		{
			b += 32;
		}
		else if (productSize > receivingProduct.size)
		{
			b -= (byte)((b >= 64) ? 64 : 0);
		}
		else if (productSize < receivingProduct.size)
		{
			b -= (byte)((b >= 16) ? 16 : 0);
		}
		b = ((sellingProduct.GetTag().anomalyFlags != receivingProduct.appliedTags.anomalyFlags) ? ((byte)(b - (byte)((b >= 64) ? 64 : 0))) : ((byte)(b + 32)));
		if (b >= byte.MaxValue)
		{
			b = byte.MaxValue;
		}
		else if (b <= 0)
		{
			b = 0;
		}
		return b;
	}
}
