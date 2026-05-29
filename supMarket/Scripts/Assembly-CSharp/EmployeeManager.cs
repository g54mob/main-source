using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using __Project__.Scripts.Janitor;

public class EmployeeManager : NoktaSingleton<EmployeeManager>
{
	[CompilerGenerated]
	private sealed class _003CStart_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public EmployeeManager _003C_003E4__this;

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
		public _003CStart_003Ed__42(int _003C_003E1__state)
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

	private const int MAX_CASHIER_COUNT = 6;

	private const int MAX_RESTOCKER_COUNT = 6;

	private const int MAX_SECURITY_GUARD_COUNT = 2;

	private const int MAX_CUSTOMER_HELPER_COUNT = 6;

	private const int MAX_JANITOR_COUNT = 3;

	private const int MAX_BAKER_COUNT = 2;

	private const int MAX_ICE_CREAM_HELPER_COUNT = 2;

	[SerializeField]
	private Transform[] m_RestockerSpawnPositions;

	[SerializeField]
	private Transform[] m_JanitorSpawnPositions;

	private List<int> m_CashiersData;

	private List<int> m_RestockersData;

	private List<int> m_CustomerHelpersData;

	private List<int> m_SecurityGuardsData;

	private List<int> m_JanitorsData;

	private List<int> m_BakersData;

	private List<int> m_IceCreamHelpersData;

	private List<Cashier> m_ActiveCashiers;

	private List<Restocker> m_ActiveRestockers;

	private List<CustomerHelper> m_ActiveCustomerHelpers;

	private List<SecurityGuard> m_ActiveSecurityGuards;

	private List<Janitor> m_ActiveJanitor;

	private List<IceCreamHelper> m_ActiveIceCreamHelpers;

	private HashSet<int> m_OccupiedProductsByRestockers;

	public Action OnEmployeeManagerLoadDone;

	public Action<Restocker> onRestockerFired;

	public List<CustomerHelper> reservedCustomerHelpers;

	public List<CustomerHelper> hiredCustomerHelpers;

	public Action onCashierHired;

	public Action onRestockerHired;

	public Action onIceCreamHelperHired;

	public List<int> CashiersData => null;

	public List<Cashier> ActiveCashiers => null;

	public List<CustomerHelper> ActiveCustomerHelpers => null;

	public List<Janitor> ActiveJanitor => null;

	public IReadOnlyList<IceCreamHelper> ActiveIceCreamHelpers => null;

	public PlayerPaymentData DailyWage => null;

	[IteratorStateMachine(typeof(_003CStart_003Ed__42))]
	private IEnumerator Start()
	{
		return null;
	}

	private void Update()
	{
	}

	public void HireCashier(int cashierID, float hiringCost, out bool success)
	{
		success = default(bool);
	}

	public void FireCashier(int cashierID)
	{
	}

	public bool IsCashierHired(int cashierID)
	{
		return false;
	}

	public Cashier GetAvailableCashier()
	{
		return null;
	}

	public IceCreamHelper GetAvailableIceCreamHelper()
	{
		return null;
	}

	public CustomerHelper GetAvailableCustomerHelper()
	{
		return null;
	}

	public void PoolCashier(Cashier cashier)
	{
	}

	public void HireRestocker(int restockerID, float hiringCost)
	{
	}

	public void FireRestocker(int restockerID)
	{
	}

	public bool IsRestockerHired(int restockerID)
	{
		return false;
	}

	public Restocker GetRestockerByID(int restockerID)
	{
		return null;
	}

	public Transform GetSpawnPosition(int restockerID)
	{
		return null;
	}

	public Transform GetJanitorSpawnPosition(int janitorID)
	{
		return null;
	}

	public bool IsProductOccupied(int productID)
	{
		return false;
	}

	public void HireSecurityGuard(int SecurityGuardID, float hiringCost, out bool isHired)
	{
		isHired = default(bool);
	}

	public void FireSecurityGuard(int SecurityGuardID)
	{
	}

	public bool IsSecurityGuardHired(int securityGuardID)
	{
		return false;
	}

	public void HireCustomerHelper(int customerHelperID, float hiringCost, out bool success)
	{
		success = default(bool);
	}

	public void FireCustomerHelper(int customerHelperID)
	{
	}

	public bool IsCustomerHelperHired(int customerHelperID)
	{
		return false;
	}

	public void HireJanitor(int janitorID, float hiringCost)
	{
	}

	public void FireJanitor(int janitorID)
	{
	}

	public bool IsJanitorHired(int janitorID)
	{
		return false;
	}

	public void LoadData(SaveManager.EmployeesData data)
	{
	}

	private void HandleCorruptEmployeeData()
	{
	}

	private void SpawnCashier(int cashierID)
	{
	}

	private void SpawnIceCreamHelper(int id)
	{
	}

	public void DespawnCashier(int cashierID, bool isFired = false)
	{
	}

	private void SpawnRestocker(int restockerID)
	{
	}

	public void SpawnRestockerNetwork(Restocker restocker)
	{
	}

	private void DespawnRestocker(int restockerID)
	{
	}

	private void SpawnCustomerHelper(int customerHelperID)
	{
	}

	private void SpawnSecurityGuard(int securityGuardID)
	{
	}

	public void DespawnCustomerHelper(int customerHelperID, bool isFired = false)
	{
	}

	public void DespawnSecurityGuard(int SecurityGuardID)
	{
	}

	private void SpawnJanitor(int janitorID)
	{
	}

	public void DespawnJanitor(int janitorID, bool isFired = false)
	{
	}

	public void SaveTargetObjectWhenFire(Janitor janitor)
	{
	}

	public void ResetJanitor(Janitor janitor)
	{
	}

	public void HireBaker(int bakerId, float hiringCost, out bool success)
	{
		success = default(bool);
	}

	public void FireBaker(int bakerId)
	{
	}

	public bool IsBakerHired(int bakerId)
	{
		return false;
	}

	public void HireIceCreamHelper(int id, float hiringCost, out bool success)
	{
		success = default(bool);
	}

	public void DespawnIceCreamHelper(int id, bool isFired = false)
	{
	}

	public void FireIceCreamHelper(int id)
	{
	}

	public bool IsIceCreamHelperHired(int id)
	{
		return false;
	}
}
