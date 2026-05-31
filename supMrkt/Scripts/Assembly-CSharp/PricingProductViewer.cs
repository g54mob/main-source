using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using __Project__.Scripts.Computer;
using __Project__.Scripts.ControllerInputModule;

public class PricingProductViewer : NoktaSingleton<PricingProductViewer>
{
	public enum FilterType
	{
		NAME = 0,
		STORAGE_TYPE = 1,
		PRODUCT_TYPE = 2
	}

	private class FilteredPricingItem
	{
		public PricingItem Product;

		public bool FilteredByName;

		public bool FilteredByStorageType;

		public bool FilteredByProductType;

		public bool Filtered => false;
	}

	[CompilerGenerated]
	private sealed class _003CDelayedGamepadSelectableSet_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PricingProductViewer _003C_003E4__this;

		public bool includeInactive;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDelayedGamepadSelectableSet_003Ed__44(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("UI")]
	[SerializeField]
	private Transform m_PricingProductsContent;

	[SerializeField]
	private PricingItem m_PricingItemPrefab;

	[Header("Filtering")]
	[SerializeField]
	private TMP_InputField m_SearchBar;

	[SerializeField]
	private TMP_Dropdown m_StorageTypeDropdown;

	[SerializeField]
	private TMP_Dropdown m_ProductTypeDropdown;

	[SerializeField]
	private List<PricingSortingButton> m_PricingSortingButtons;

	public RectTransform m_Viewport;

	public List<PricingItem> sortedPricingItems;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	private List<PricingItem> m_PricingItems;

	private int m_CurrentStorageTypeFilter;

	private int m_CurrentProductTypeFilter;

	private List<FilteredPricingItem> m_FilteredProducts;

	private List<PricingItem> m_unfilteredItems;

	private PricingSortingType m_SortingType;

	private PricingSortingState m_SortingState;

	[SerializeField]
	private WindowTab m_tab;

	private List<Pricing> PricingDatas => null;

	public Computer Computer { get; set; }

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void OnSlaveLoadedPriceSave()
	{
	}

	private void CreatePricingItems()
	{
	}

	private void Search(string text)
	{
	}

	private void FilterByStorageType(int index)
	{
	}

	private void FilterByProductType(int index)
	{
	}

	private FilteredPricingItem IsFiltered(PricingItem pricingItem)
	{
		return null;
	}

	private void AddFilter(PricingItem pricingItem, FilterType filterType)
	{
	}

	private void RemoveFilter(PricingItem pricingItem, FilterType filterType)
	{
	}

	private void ClearPricingItems()
	{
	}

	public void SpawnUnlockedProducts()
	{
	}

	public void UpdateUnlockedProducts(int licenseID)
	{
	}

	public void RefreshUnlockedProducts(int productID)
	{
	}

	public void LoadLastChangedCost()
	{
	}

	public void OnCostsChanged(List<int> products)
	{
	}

	public void SortPricingItems(PricingSortingType type, PricingSortingState state, bool isSearch = false)
	{
	}

	public void RefreshSorting()
	{
	}

	private List<PricingItem> LastChangeDateSort(List<PricingItem> itemsToOrder, bool isAscending)
	{
		return null;
	}

	private void OnComputerInteractionStopped()
	{
	}

	private void GamePadSelectableSet(bool includeInactive = false)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedGamepadSelectableSet_003Ed__44))]
	private IEnumerator DelayedGamepadSelectableSet(bool includeInactive)
	{
		return null;
	}

	private void InstantSelectableSet(bool includeInactive = false)
	{
	}

	public void RefreshGamepadSelection(bool isSearch = false, bool willSort = true)
	{
	}
}
