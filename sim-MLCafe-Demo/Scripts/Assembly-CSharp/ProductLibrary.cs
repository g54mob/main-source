using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product Library", menuName = "Libraries/Product Library", order = 1)]
public class ProductLibrary : ScriptableObject
{
	public List<ProductInfo> productInfos = new List<ProductInfo>();

	private List<string> names = new List<string>();

	public ProductInfo GetProductInfo(int id)
	{
		return productInfos[id];
	}

	public Product GetAsProduct(int id)
	{
		return new Product(id, Product.ProductSize.Medium);
	}

	public Product GetProductFromInfo(ProductInfo info, Product.ProductSize size = Product.ProductSize.Medium)
	{
		return new Product(productInfos.FindIndex((ProductInfo x) => x.productName == info.productName), size);
	}

	public Product GetProductWithAmount(string name, Product.ProductSize amount)
	{
		return new Product(productInfos.FindIndex((ProductInfo x) => x.productName == name), amount);
	}

	public List<ProductInfo> GetProductInfoOfType(ProductInfo.ProductType type)
	{
		return productInfos.FindAll((ProductInfo x) => x.productType == type);
	}

	public List<string> GetProductNames()
	{
		names.Clear();
		if (names.Count != productInfos.Count)
		{
			foreach (ProductInfo productInfo in productInfos)
			{
				names.Add(productInfo.productName);
			}
		}
		return names;
	}
}
