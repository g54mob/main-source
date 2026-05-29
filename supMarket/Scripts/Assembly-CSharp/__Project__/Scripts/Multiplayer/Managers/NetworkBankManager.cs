using Photon.Pun;

namespace __Project__.Scripts.Multiplayer.Managers
{
	public class NetworkBankManager : NoktaSingletonPunCallbacks<NetworkBankManager>
	{
		private void Start()
		{
		}

		public void SendLoanBillData_Broadcast(string userID)
		{
		}

		[PunRPC]
		public void UpdateLoanBillData_RPC(LoanData[] loanData, PlayerPaymentData[] paymentData)
		{
		}

		public void OnTakenLoan(int loanID, float amount)
		{
		}

		public void LoanTaken_Request(int loanID, float amount)
		{
		}

		[PunRPC]
		public void LoanTaken_Broadcast(int loanID, float amount)
		{
		}

		[PunRPC]
		public void LoanTaken_RPC(int loanID)
		{
		}

		public void AddLoanBill_Broadcast(LoanData loanData, PlayerPaymentData bill)
		{
		}

		[PunRPC]
		public void AddLoanBill_RPC(LoanData loanData, PlayerPaymentData bill)
		{
		}

		public void CompleteLoan_Request(int loanID, float earlyPayment)
		{
		}

		[PunRPC]
		public void CompleteLoan_Broadcast(int loanID, float earlyPayment)
		{
		}

		[PunRPC]
		public void CompleteLoan_RPC(int loanID)
		{
		}

		public void PayRepayment_Request(int loanID)
		{
		}

		[PunRPC]
		public void PayRepayment_Broadcast(int loanID)
		{
		}

		[PunRPC]
		public void PayRepayment_RPC(int loanID)
		{
		}
	}
}
