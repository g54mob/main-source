using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using MyBox;
using UnityEngine;

public class DisplayManager : NoktaSingleton<DisplayManager>
{
	private List<DisplayData> m_DisplayDatas;

	private List<Display> m_Displays;

	[SerializeField]
	private List<Transform> m_DefaultDisplayPositions;

	[SerializeField]
	private SerializedDictionary<int, List<DisplaySlot>> m_DisplayedProducts;

	public Action onPurchasedDisplay;

	public int testId;

	public List<DisplayData> Data
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool HasAnythingDisplayed => false;

	public Dictionary<int, List<DisplaySlot>> DisplayedProducts => null;

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void OnDestroy()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void DespawnSomeProducts()
	{
	}

	public void AddDisplaySlot(int productID, DisplaySlot newSlot)
	{
	}

	public void RemoveDisplaySlot(int productID, DisplaySlot slot)
	{
	}

	public DisplaySlot GetBakeryShelfSlotByID(int productID)
	{
		return null;
	}

	public DisplaySlot GetBakeryShelfSlotByIDInAllDisplays(int productID)
	{
		return null;
	}

	public int GetDisplaySlots(int productID, bool hasProduct, List<DisplaySlot> cachedSlots)
	{
		return 0;
	}

	public int GetLabeledEmptyDisplaySlots(int productID, List<DisplaySlot> cachedSlots)
	{
		return 0;
	}

	public DisplaySlot GetRandomDisplaySlot()
	{
		return null;
	}

	public DisplaySlot GetRandomFilledDisplay()
	{
		return null;
	}

	public void AddDisplay(Display display)
	{
	}

	public void RemoveDisplay(Display display)
	{
	}

	public int GetDisplayedProductCount(int productID)
	{
		return 0;
	}

	private void LoadDisplayData()
	{
	}

	private void OnSaleSignSet(int productID, int saleIndex)
	{
	}

	private void OnPriceSet(int productID)
	{
	}

	public bool HasAnyDiscountedProduct(Display display)
	{
		return false;
	}

	private void CheckDiscountsOnStartup()
	{
	}

	private void LoadFurnitureID(DisplayData displayData)
	{
	}
}
