using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CustomerManager : NoktaSingleton<CustomerManager>
{
	[CompilerGenerated]
	private sealed class _003CCustomerGeneration_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomerManager _003C_003E4__this;

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
		public _003CCustomerGeneration_003Ed__58(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CStart_003Ed__54 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CustomerManager _003C_003E4__this;

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
		public _003CStart_003Ed__54(int _003C_003E1__state)
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

	[SerializeField]
	private CustomerSpawnSettingManager m_SpawnSetting;

	public Transform m_StoreDoor;

	[Header("Latest Time For Customer Spawn")]
	[SerializeField]
	private int m_LatestTimeToSpawnCustomer;

	[SerializeField]
	private bool m_AM;

	[SerializeField]
	private AnimationCurve m_ProductCount_ToBePickedFrom_DiscountedProductsCurve;

	[SerializeField]
	private AnimationCurve m_ProductAmount_DiscountedProductCurve;

	[SerializeField]
	private IceCreamGeneratorSettings m_IceCreamGeneratorSettings;

	[SerializeField]
	private IceCreamTopping[] m_Toppings;

	[SerializeField]
	private IceCreamFlavour[] m_Flavours;

	private ItemQuantity m_ShoppingList;

	private int m_TotalProductCount_ToBuy;

	private int m_ProductCount_ToBePickedFrom_DisplayedProducts;

	private int m_ProductCount_ToBePickedFrom_UnlockedProducts;

	private int m_ProductCount_ToBePickedFrom_ExpectedProducts;

	private int m_ProductCount_ToBePickedFrom_DiscountedProducts;

	private CustomerStrategySO m_CurrentStrategy;

	private HashSet<int> m_ProductsToBuy;

	private HashSet<int> m_DiscountedProductsToBuy;

	private bool m_SpawnCustomer;

	private List<Customer> m_ActiveCustomers;

	private List<Customer> m_ShoppingCustomers;

	private List<Customer> m_AwaitingCustomers;

	private List<Customer> m_CheckoutCustomers;

	private List<Customer> m_Shoplifters;

	private ShoplifterTutorialCustomer m_ShoplifterTutorialCustomer;

	private float m_ShoplifterSpawnPossibility;

	private int m_ShoplifterCount;

	private int m_CustomerCount;

	private int m_CustomerCountSinceLastShoplifter;

	private ShoplifterSpawnSettingSO currentShoplifterSpawnSettings;

	private NetworkCustomerManager m_NetworkCustomerManager;

	public Action onTutorialShoplifterSpawned;

	public Action onTutorialShoplifterDespawned;

	private bool m_IsTutorialShoplifterSpawned;

	public List<Customer> ActiveCustomers
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Customer> AwaitingCustomers
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Customer> ShoppingCustomers
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Customer> CheckoutCustomers
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<Customer> Shoplifters
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool CanSpawnCustomer
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private bool TooLateToSpawnCustomers => false;

	private void ToggleShoplifters(bool value)
	{
	}

	[IteratorStateMachine(typeof(_003CStart_003Ed__54))]
	private IEnumerator Start()
	{
		return null;
	}

	private void LoadSaveProgress()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	[IteratorStateMachine(typeof(_003CCustomerGeneration_003Ed__58))]
	private IEnumerator CustomerGeneration()
	{
		return null;
	}

	public List<Customer> GetAwaitingCustomers(int amount)
	{
		return null;
	}

	public void CheckCustomers(List<Customer> Customers)
	{
	}

	public void SpawnShoplifter()
	{
	}

	public void SpawnTutorialShoplifter()
	{
	}

	public void DespawnTutorialShoplifter()
	{
	}

	public Customer SpawnCustomer()
	{
		return null;
	}

	public void SpawnCustomer(Vector3 position)
	{
	}

	public ItemQuantity CreateShoppingList()
	{
		return null;
	}

	private HashSet<int> GetRandomProducts(List<int> productCountData, int amount)
	{
		return null;
	}

	private void GetCurrentShoplifterSpawnSettings()
	{
	}

	private bool CanSpawnShoplifter()
	{
		return false;
	}

	private void FinishedTheDay()
	{
	}

	private void SpawnCustomersOnStoresOpened(bool open)
	{
	}

	private void StopSpawningCustomerAtNight()
	{
	}

	private void OnDayCycleManagerDisabled()
	{
	}

	public IceCreamRequest TryCreateIceCreamRequest()
	{
		return null;
	}
}
