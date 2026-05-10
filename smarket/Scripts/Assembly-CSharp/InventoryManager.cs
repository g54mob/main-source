using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using __Project__.Scripts.WallPaintSystem;

public class InventoryManager : NoktaSingleton<InventoryManager>
{
	private List<BoxData> m_Boxes;

	private List<FurnitureBoxData> m_ShelfBoxes;

	private List<FurnitureBoxData> m_BucketBoxes;

	[SerializeField]
	private SerializedDictionary<int, int> m_DisplayedProducts;

	[SerializeField]
	private SerializedDictionary<int, int> m_VendingPlacedProducts;

	private bool m_WillProductsOrder;

	public List<int> OrderedProductIds;

	public SerializedDictionary<int, Transform> occupiedList;

	public Action OnProductPurchased;

	public Action OnInventoryChanged;

	public Action<bool> OnPurchaseCompleted;

	public int testId;

	public List<int> VendingPlacedProducts => null;

	public List<int> DisplayedProducts => null;

	public List<FurnitureBoxData> ShelfBoxes
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public void SetProductsOrderDirty()
	{
	}

	public int ProductCount(int ProductId)
	{
		return 0;
	}

	public object[] ParseDataToString()
	{
		return null;
	}

	public void ParseStringToData(object[] strings)
	{
	}

	public string GetShelfBoxJson()
	{
		return null;
	}

	public int GetInventoryAmount(int productID)
	{
		return 0;
	}

	public (int, int, int) GetInventoryAmountEach(int productID)
	{
		return default((int, int, int));
	}

	public void UpdateOrderedProducts()
	{
	}

	private void AddIceCreamOrderedProducts()
	{
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void LoadBoxDatas()
	{
	}

	private void LoadDisplayedProductData()
	{
	}

	private void LoadVendingProductData()
	{
	}

	public void AddBox(BoxData boxData)
	{
	}

	public void AddBox(FurnitureBoxData boxData)
	{
	}

	public void AddBox(BucketData data, FurnitureBoxData boxData)
	{
	}

	public void RemoveBox(BoxData boxData)
	{
	}

	public void RemoveBox(FurnitureBoxData boxData)
	{
	}

	public void RemoveBox(FurnitureBoxData boxData, BucketData data)
	{
	}

	public void AddProductToDisplay(ItemQuantity productData)
	{
	}

	public void AddProductToVending(ItemQuantity productData)
	{
	}

	public void RemoveProductFromVending(ItemQuantity productData)
	{
	}

	public void RemoveProductFromDisplay(ItemQuantity productData)
	{
	}

	public bool IsProductDisplayed(int productID)
	{
		return false;
	}

	public void OccupyProduct(int id, Transform sender)
	{
	}

	private bool GetOccupiedProduct(Transform sender, out int occupiedId)
	{
		occupiedId = default(int);
		return false;
	}

	public void UnOccupyProduct(int id)
	{
	}

	public bool IsOccupiedByAnother(int id, Transform sender)
	{
		return false;
	}

	public bool IsOccupiedByAnyone(int id)
	{
		return false;
	}

	public void SetShelfBoxData(string receivedJson)
	{
	}
}
