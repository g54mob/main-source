using Photon.Pun;
using __Project__.Scripts.Computer;

namespace __Project__.Scripts.Multiplayer.Managers
{
	public class NetworkVehicleManager : NoktaSingletonPunCallbacks<NetworkVehicleManager>
	{
		private __Project__.Scripts.Computer.Computer m_Computer;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnComputerInteract()
		{
		}

		public void SalesItemsUpdate_Request()
		{
		}

		[PunRPC]
		public void SalesItemsUpdate_Response(string userId)
		{
		}

		private void SyncVehicleState_Broadcast(string userId)
		{
		}

		public void UpdateSalesItems()
		{
		}

		[PunRPC]
		public void SyncVehicleState_RPC(int[] VehicleIndexes, bool[] VehicleIsPurchasedList, bool[] VehicleIsUnlockedList)
		{
		}

		public void PurchaseVehicle_Request(int vehicleLevel)
		{
		}

		[PunRPC]
		public void PurchaseVehicle_Response(int vehicleLevel)
		{
		}

		[PunRPC]
		public void PurchaseVehicle_Broadcast(int vehicleLevel)
		{
		}

		[PunRPC]
		public void PurchaseVehicle_RPC(int vehicleLevel)
		{
		}

		public void SellVehicle_Request(int vehicleLevel, string senderId)
		{
		}

		[PunRPC]
		public void SellVehicle_Response(int vehicleLevel, string senderId)
		{
		}

		[PunRPC]
		public void SellVehicleRejedted_RPC(int errorCode)
		{
		}

		public void SellVehicle_Broadcast(int vehicleLevel, int _VehicleLevel, float _Price)
		{
		}

		[PunRPC]
		public void SellVehicle_RPC(int vehicleLevel, int _VehicleLevel, float _Price)
		{
		}
	}
}
