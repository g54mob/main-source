using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

[Serializable]
public class ItemQuantity
{
	public Dictionary<int, int> Products;

	public Dictionary<int, float> ProductPrice;

	public Dictionary<int, bool> ItemProcessData;

	private static byte[] m_Bytes;

	public int FirstItemID => 0;

	public bool HasProduct => false;

	public bool HasLabel => false;

	public int FirstItemCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public ItemQuantity(List<Product> products)
	{
	}

	public ItemQuantity(ItemQuantity ItemQuantity)
	{
	}

	public ItemQuantity(Dictionary<int, int> _products, Dictionary<int, float> _productPrice)
	{
	}

	public ItemQuantity()
	{
	}

	public void RemoveItemsOfType<T>() where T : ProductSO
	{
	}

	public ItemQuantity(int ItemID, float price)
	{
	}

	public void ClearProducts()
	{
	}

	public bool IsItemProcessed(int itemID)
	{
		return false;
	}

	public void SetItemProcessed(int itemID, bool isProcessed)
	{
	}

	public bool HasOfType<T>(bool processed) where T : ProductSO
	{
		return false;
	}

	public bool HasOfType<T>() where T : ProductSO
	{
		return false;
	}

	private int GetSize()
	{
		return 0;
	}

	public static short Serialize(StreamBuffer outStream, object customObject)
	{
		return 0;
	}

	public static object Deserialize(StreamBuffer inStream, short length)
	{
		return null;
	}
}
