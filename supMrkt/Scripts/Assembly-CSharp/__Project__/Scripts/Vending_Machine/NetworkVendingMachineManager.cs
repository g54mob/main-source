using Photon.Pun;

namespace __Project__.Scripts.Vending_Machine
{
	public class NetworkVendingMachineManager : MonoBehaviourPun
	{
		private VendingMachineManager _vendingMachineManager;

		public VendingMachineManager VendingMachineManager => null;

		public void SyncVendingMachineManager(string invokerUserID)
		{
		}

		private void Start()
		{
		}

		private void OnSyncVendingMachineTab(string invokerUserID)
		{
		}

		[PunRPC]
		public void Sync(int[] uniqueIdArray, int[] networkVendingMachineViewIDArray, string vendingDataListJson)
		{
		}

		private VendingMachine GetVendingMachineByViewID(int viewID)
		{
			return null;
		}

		public void AddVending(int photonViewViewID)
		{
		}

		[PunRPC]
		public void AddVending_RPC(int photonViewViewID)
		{
		}

		public void RemoveVending(int photonViewViewID)
		{
		}

		[PunRPC]
		public void RemoveVending_RPC(int photonViewViewID)
		{
		}

		public void SellThisVending_Request(int vendingMachineViewID)
		{
		}

		[PunRPC]
		public void SellThisVending_RPC(int vendingMachineViewID)
		{
		}

		[PunRPC]
		public void SellVendingClient_RPC()
		{
		}
	}
}
