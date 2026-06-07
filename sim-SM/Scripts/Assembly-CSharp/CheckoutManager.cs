using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutManager : NoktaSingleton<CheckoutManager>
{
	private List<Checkout> m_Checkouts;

	private List<Checkout> m_SelfCheckouts;

	private List<SelfCheckout> m_UsableSelfCheckouts;

	private List<Checkout> m_CheckoutsWithCashier;

	private List<SelfCheckout> m_SelfCheckoutsNeedHelp;

	private List<CheckoutData> m_CheckoutDatas;

	private List<Checkout> m_TempCheckouts;

	private List<Cashier> m_Cashiers;

	private float m_LastCustomerHelpDate;

	private float m_currCustomerDate;

	[SerializeField]
	private Transform m_DefaultCheckoutPosition;

	[SerializeField]
	private float m_MinCustomerHelpTime;

	[SerializeField]
	private float m_MaxCustomerHelpTime;

	[SerializeField]
	private int m_MinCustomerHelpCount;

	public int completedCustomerCount;

	public Action onCheckoutCompleted;

	public Action onSelfCheckoutCountChanged;

	public List<CheckoutData> Data
	{
		set
		{
		}
	}

	public List<Cashier> Cashiers => null;

	public List<Checkout> CheckoutsWithCashier
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public List<SelfCheckout> SelfCheckoutsNeedHelp => null;

	public int SelfCheckoutCount => 0;

	public Checkout GetAvailableCheckout => null;

	public List<SelfCheckout> UsableSelfCheckouts
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Update()
	{
	}

	public bool HasAvailableCashierSlot(int totalCashierCount)
	{
		return false;
	}

	public IEnumerable<Checkout> GetSelfCheckouts()
	{
		return null;
	}

	public Checkout GetAvailableCheckoutForEmployee()
	{
		return null;
	}

	public Checkout GetAvailableSelfCheckoutForEmployee()
	{
		return null;
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public List<Customer> GetAwaitingCustomer(int amount)
	{
		return null;
	}

	public void AddCheckout(Checkout checkout)
	{
	}

	public void RemoveCheckout(Checkout checkout)
	{
	}

	public void AddOrMoveCashier(Cashier loadcashier = null)
	{
	}

	public void AddSCOToHelpList(SelfCheckout requester)
	{
	}

	public void HelpAllSCO()
	{
	}

	private void MatchHelperAndSCO()
	{
	}

	public void SetCustomerHelperReserved()
	{
	}

	public void AssignSCOToCustomerHelper()
	{
	}

	public void AssignCustomerHelperToSCO()
	{
	}

	public List<SelfCheckout> GetAvailableSCOToStand()
	{
		return null;
	}

	public CustomerHelper GetAvailableCustomerHelperToHelp(SelfCheckout SCO)
	{
		return null;
	}

	private void OnDayFinished()
	{
	}

	public bool CustomerNeedHelp()
	{
		return false;
	}

	public void RemoveCashier(Cashier cashier)
	{
	}

	private void SetupCheckouts()
	{
	}

	private void LoadCheckoutData()
	{
	}
}
