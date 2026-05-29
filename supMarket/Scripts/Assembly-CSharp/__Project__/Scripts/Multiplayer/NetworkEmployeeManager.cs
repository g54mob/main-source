using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Janitor;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkEmployeeManager : NoktaSingletonPunCallbacks<NetworkEmployeeManager>
	{
		[SerializeField]
		private Transform m_CustomerHelperSpawnPosition;

		private void Start()
		{
		}

		private void OnSyncRequest_Broadcast(string userID)
		{
		}

		[PunRPC]
		public void SyncEmployeeData_RPC(string employeeDataJson)
		{
		}

		public Baker SpawnBaker(Baker bakerPrefab, int bakerId)
		{
			return null;
		}

		public CustomerHelper SpawnCustomerHelper(CustomerHelper customerHelperPrefab, int helperId)
		{
			return null;
		}

		public SecurityGuard SpawnSecurityGuard(SecurityGuard securityGuardPrefab, Vector3 spawnPosition, int id)
		{
			return null;
		}

		public Restocker SpawnRestocker(Restocker restockerPrefab, int restockerId, Vector3 spawnPosition)
		{
			return null;
		}

		public Cashier SpawnCashier(Cashier cashierPrefab, int cashierId)
		{
			return null;
		}

		public __Project__.Scripts.Janitor.Janitor SpawnJanitor(__Project__.Scripts.Janitor.Janitor janitorPrefab, int janitorId, Vector3 spawnPosition, Quaternion spawnRotation)
		{
			return null;
		}

		public void HireCashier_Request(int cashierSetupID, float cashierSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireCashier_Broadcast(int cashierSetupID, float cashierSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireCashier_RPC(int cashierSetupID, bool success)
		{
		}

		public void FireCashier_Request(int cashierSetupID)
		{
		}

		[PunRPC]
		public void FireCashier_Broadcast(int cashierSetupID)
		{
		}

		[PunRPC]
		public void FireCashier_RPC(int cashierSetupID)
		{
		}

		public void HireCustomerHelper_Request(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireCustomerHelper_Broadcast(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireCustomerHelper_RPC(int employeeSetupID, bool success)
		{
		}

		public void FireCustomerHelper_Request(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireCustomerHelper_Broadcast(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireCustomerHelper_RPC(int employeeSetupID)
		{
		}

		public void HireSecurityGuard_Request(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireSecurityGuard_Broadcast(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireSecurityGuard_RPC(int employeeSetupID, bool success)
		{
		}

		public void FireSecurityGuard_Request(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireSecurityGuard_Broadcast(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireSecurityGuard_RPC(int employeeSetupID)
		{
		}

		public void HireRestocker_Request(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireRestocker_Broadcast(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireRestocker_RPC(int employeeSetupID)
		{
		}

		public void FireRestocker_Request(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireRestocker_Broadcast(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireRestocker_RPC(int employeeSetupID)
		{
		}

		public void HireJanitor_Request(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireJanitor_Broadcast(int employeeSetupID, float employeeSetupHiringCost)
		{
		}

		[PunRPC]
		public void HireJanitor_RPC(int employeeSetupID)
		{
		}

		public void FireJanitor_Request(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireJanitor_Broadcast(int employeeSetupID)
		{
		}

		[PunRPC]
		public void FireJanitor_RPC(int employeeSetupID)
		{
		}

		[PunRPC]
		public void HireBaker_Broadcast(int bakerId, float hiringCost)
		{
		}

		public void HireBaker_Request(int bakerId, float hiringCost)
		{
		}

		[PunRPC]
		public void HireBaker_RPC(int bakerId, bool success)
		{
		}

		[PunRPC]
		public void FireBaker_Broadcast(int bakerId)
		{
		}

		public void FireBaker_Request(int bakerId)
		{
		}

		[PunRPC]
		public void FireBaker_RPC(int bakerId)
		{
		}

		[PunRPC]
		public void HireIceCreamHelper_Broadcast(int id, float hiringCost)
		{
		}

		public void HireIceCreamHelper_Request(int id, float hiringCost)
		{
		}

		[PunRPC]
		private void HireIceCreamHelper_RPC(int id)
		{
		}

		[PunRPC]
		public void FireIceCreamHelper_Broadcast(int id)
		{
		}

		public void FireIceCreamHelper_Request(int id)
		{
		}

		[PunRPC]
		public void FireIceCreamHelper_RPC(int employeeSetupID)
		{
		}

		public IceCreamHelper SpawnIceCreamHelper(IceCreamHelper prefab, int id)
		{
			return null;
		}
	}
}
