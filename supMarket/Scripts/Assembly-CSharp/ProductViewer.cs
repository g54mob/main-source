using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using __Project__.Scripts.ControllerInputModule;

public class ProductViewer : MonoBehaviour
{
	public enum FilterType
	{
		NAME = 0,
		STORAGE_TYPE = 1,
		PRODUCT_TYPE = 2
	}

	private class FilteredItem
	{
		public SalesItem Product;

		public bool FilteredByName;

		public bool FilteredByStorageType;

		public bool FilteredByProductType;

		public bool Filtered => false;
	}

	[CompilerGenerated]
	private sealed class _003CDelayedGamepadSelectableSet_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ProductViewer _003C_003E4__this;

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
		public _003CDelayedGamepadSelectableSet_003Ed__34(int _003C_003E1__state)
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
	private Transform m_ProductsContent;

	[SerializeField]
	private SalesItem m_SalesItemPrefab;

	[Header("Filtering")]
	[SerializeField]
	private TMP_InputField m_SearchBar;

	[SerializeField]
	private TMP_Dropdown m_StorageTypeDropdown;

	[SerializeField]
	private TMP_Dropdown m_ProductTypeDropdown;

	[SerializeField]
	private GameObject m_NoProductIndicator;

	[Header("Components")]
	[SerializeField]
	private MarketShoppingCart m_ShoppingCart;

	[SerializeField]
	private WindowTab m_tab;

	[SerializeField]
	private GamepadSelectableParent m_gamepadSelectableParent;

	private List<SalesItem> m_SalesItems;

	private int m_CurrentStorageTypeFilter;

	private int m_CurrentProductTypeFilter;

	private List<FilteredItem> m_FilteredProducts;

	private List<SalesItem> m_unfilteredItems;

	private bool m_WillGamepadInitialize;

	[SerializeField]
	private int m_VendingMachineFilterIndex;

	[SerializeField]
	private VirtualKeyboard m_VirtualKeyboard;

	private GameObject m_LastSelectedItem;

	public List<SalesItem> SalesItems => null;

	public MarketShoppingCart ShoppingCart => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	public void RemoteLoad()
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

	private FilteredItem IsFiltered(SalesItem salesItem)
	{
		return null;
	}

	private void AddFilter(SalesItem salesItem, FilterType filterType)
	{
	}

	private void RemoveFilter(SalesItem salesItem, FilterType filterType)
	{
	}

	[ContextMenu("SpawnUnlockedProducts")]
	private void SpawnUnlockedProducts()
	{
	}

	private void UpdateUnlockedProducts(int licenseID)
	{
	}

	private void OnComputerInteractionStopped()
	{
	}

	private void GamePadSelectableSet(bool includeInactive = false)
	{
	}

	[IteratorStateMachine(typeof(_003CDelayedGamepadSelectableSet_003Ed__34))]
	private IEnumerator DelayedGamepadSelectableSet(bool includeInactive)
	{
		return null;
	}

	private void InstantSelectableSet(bool includeInactive = false)
	{
	}

	public void OpenVirtualKeyboard()
	{
	}

	public void CloseVirtualKeyboard()
	{
	}
}
