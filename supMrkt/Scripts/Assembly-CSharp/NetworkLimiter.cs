using System.Collections.Generic;
using MyBox;
using UnityEngine;

public class NetworkLimiter : NoktaSingletonPunCallbacks<NetworkLimiter>
{
	[SerializeField]
	private int m_MaxSpreadedProductCount;

	[SerializeField]
	private int m_MaxProductBoxCount;

	[SerializeField]
	private int m_MaxFurnitureBoxCount;

	[SerializeField]
	private int m_MaxFloorBoxCount;

	public List<Product> SpreadedProduct;

	private MarketShoppingCart m_MarketShoppingCart;

	public MarketShoppingCart MarketShoppingCart => null;

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void GetAllPhotonViews()
	{
	}

	public bool IsEnoughSpaceToAddBox_FloorBox(int incomingBoxCount)
	{
		return false;
	}

	public bool IsEnoughSpaceToAddBox_FurnitureBox(int incomingBoxCount)
	{
		return false;
	}

	public bool IsEnoughSpaceToAddBox_ProductBoxBox(int incomingBoxCount)
	{
		return false;
	}

	public bool IsEnoughSpaceToAddBox_ProductBoxBox(out int limitCount)
	{
		limitCount = default(int);
		return false;
	}

	public void AddProductInSpreadedProductAndDestroy(Product product)
	{
	}

	public void AddProductInSpreadedProduct(Product product)
	{
	}

	private void DestroyObjectByTime(List<Product> views)
	{
	}
}
