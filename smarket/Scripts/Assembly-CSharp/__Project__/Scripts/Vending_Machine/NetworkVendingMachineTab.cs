using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using __Project__.Scripts.Computer.Vending_Machine;

namespace __Project__.Scripts.Vending_Machine
{
	public class NetworkVendingMachineTab : MonoBehaviourPun
	{
		[SerializeField]
		private VendingMachineTab m_VendingMachineTab;

		public void PlaceControlFuncNetwork(int uniqueID)
		{
		}

		[PunRPC]
		public void PlaceControlRPC(int uniqueID)
		{
		}

		public void BoxUpControlFuncNetwork(int uniqueID)
		{
		}

		[PunRPC]
		public void BoxUpControlRPC(int uniqueID)
		{
		}

		public void SelectedSlotNetwork(int uniqueID)
		{
		}

		[PunRPC]
		public void SelectedSlotRPC(int uniqueID)
		{
		}

		public void DeleteSlotNetwork(int uniqueID)
		{
		}

		[PunRPC]
		public void DeleteSlotRPC(int uniqueID)
		{
		}

		public void VendingSyncData_Broadcast(VendingData data, FurnitureBox box)
		{
		}

		[PunRPC]
		public void VendingSyncData_RPC(int furnitureID, int uniqueID, float collectedMoney, int nameInt, int networkFurnitureBoxViewID)
		{
		}

		public void SpawnSlot_Request()
		{
		}

		[PunRPC]
		public void SpawnSlot_RPC(Player client)
		{
		}

		[PunRPC]
		public void RejectedSpawnSlot()
		{
		}

		public void CreateNewSlot_Network(string json)
		{
		}

		[PunRPC]
		public void CreateNewSlot_RPC(string json)
		{
		}
	}
}
