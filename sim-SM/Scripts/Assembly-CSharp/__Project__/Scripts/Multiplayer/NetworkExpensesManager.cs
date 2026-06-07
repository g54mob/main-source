using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkExpensesManager : NoktaSingletonPunCallbacks<NetworkExpensesManager>
	{
		private void Start()
		{
		}

		public void SendBillData_Broadcast(string userID)
		{
		}

		[PunRPC]
		public void UpdateBillData_RPC(string jsonBills, string jsonRents)
		{
		}

		public void PayBill_Network(PlayerPaymentData billData, bool byForce)
		{
		}

		private void PayBill_Request(string billDataJson, bool byForce)
		{
		}

		[PunRPC]
		public void PayBill_Broadcast(string billDataJson, bool byForce)
		{
		}

		[PunRPC]
		public void PayBill_RPC(string billDataJson, bool byForce)
		{
		}

		public void AddBill_Broadcast(PlayerPaymentData paymentData, bool isBill)
		{
		}

		[PunRPC]
		public void AddBill_RPC(string paymentDataJson, bool isBill)
		{
		}
	}
}
