using Photon.Pun;
using UnityEngine;

public class NetworkCheckout : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
	private PhotonView m_PhotonView;

	private Checkout m_Checkout;

	private PlayerInstance m_PlayerInstance;

	public int ViewId => 0;

	public string UserId => null;

	public PhotonView PhotonView => null;

	public Checkout Checkout => null;

	public PlayerInstance PlayerInstance
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	public override void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public void StartPlacingMode_Broadcast()
	{
	}

	[PunRPC]
	public void StartCheckoutPlacingMode_RPC(string userId)
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	private void RequestInstantiateData_Broadcast(string UserId)
	{
	}

	[PunRPC]
	public void RequestInstantiateData_RPC(string userId)
	{
	}

	[PunRPC]
	public void SetupInstantiateData_RPC(object[] checkoutData)
	{
	}

	public void EnterCheckout_Request()
	{
	}

	[PunRPC]
	public void EnterCheckout_Response(string userId)
	{
	}

	[PunRPC]
	public void EnterCheckout_Rejected()
	{
	}

	[PunRPC]
	public void EnterCheckout_Broadcast(string userId)
	{
	}

	[PunRPC]
	public void EnterCheckout_RPC(string userId)
	{
	}

	public void OpenCloseCheckout_Request()
	{
	}

	[PunRPC]
	public void OpenCloseCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void OpenCloseCheckout_RPC(bool _IsOpen)
	{
	}

	public void StartCheckout_Broadcast(ItemQuantity _shoppingCart, int customerViewId)
	{
	}

	[PunRPC]
	public void StartCheckout_RPC(int[] _productIDs, int[] _productCounts, float[] _productPrices, int customerViewId)
	{
	}

	public void FinishedScanning_Broadcast(bool _paymentViaCreditCard, int _customerViewID)
	{
	}

	[PunRPC]
	public void FinishedScanning_RPC(bool _paymentViaCreditCard, int _customerViewID)
	{
	}

	public void TryFinishingCardPayment_Request(float posTotal)
	{
	}

	[PunRPC]
	public void TryFinishingCardPayment_Answer(float posTotal, string userId, Vector3 playSoundPosition)
	{
	}

	public void TryFinishingCardPayment_Broadcast(float posTotal, Vector3 playSoundPosition)
	{
	}

	[PunRPC]
	public void TryFinishingCardPayment_RPC(Vector3 playSoundPosition)
	{
	}

	public void TookCustomersCard_Request(PlayerInstance playerInstance)
	{
	}

	[PunRPC]
	public void TookCustomersCard_RPC(string playerInstanceUserId)
	{
	}

	public void TryFinishingCashPayment_Request(bool m_CanApproveChange)
	{
	}

	[PunRPC]
	public void TryFinishingCashPayment_Answer(bool m_CanApproveChange, Vector3 playSoundPosition)
	{
	}

	public void TryFinishingCashPayment_Broadcast(Vector3 playSoundPosition)
	{
	}

	[PunRPC]
	public void TryFinishingCashPayment_RPC(Vector3 playSoundPosition)
	{
	}

	public void TookCustomersCash_Request(float payment, PlayerInstance playerInstance)
	{
	}

	[PunRPC]
	public void TookCustomersCash_RPC(float payment, string playerInstanceUserId)
	{
	}

	public void AddOrRemoveChange_Broadcast(MoneyPack money, bool add, float collectedChange)
	{
	}

	[PunRPC]
	public void AddOrRemoveChange_RPC(float value, bool add, float collectedChange)
	{
	}

	private void SyncCheckoutState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncCheckoutState_RPC(string newPlayerUserId, int currentState, string checkoutUserId, int[] _productIDs, int[] _productCounts, float[] _productPrices, int customerViewId, int[] _scannedProductsIndex, bool _isLastPaymentViaCard, float _cashValue, float[] _usedMoneyForChange, float _collectedChange, bool needRepair, bool isRepairing, int cashierViewId)
	{
	}

	public void StartSelfCheckoutBroadcast(bool customerNeedHelp)
	{
	}

	[PunRPC]
	public void StartSelfCheckout_RPC(bool customerNeedHelp)
	{
	}

	public void FinishSelfCheckoutBroadcast()
	{
	}

	[PunRPC]
	public void FinishSelfCheckout_RPC()
	{
	}

	public void RepairSelfCheckout_Request()
	{
	}

	[PunRPC]
	public void RepairSelfCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void RepairSelfCheckout_RPC()
	{
	}

	public void FinishRepairSelfCheckout_Request()
	{
	}

	[PunRPC]
	public void FinishRepairSelfCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void FinishRepairSelfCheckout_RPC()
	{
	}

	public void StartCustomerHelperCheckout_Broadcast(CustomerHelper helper)
	{
	}

	[PunRPC]
	public void StartCustomerHelperCheckout_RPC(int helperId)
	{
	}

	public void FinishHelperCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void FinishHelperCheckout_RPC()
	{
	}

	public void RemoveCashier_Broadcast()
	{
	}

	[PunRPC]
	public void RemoveCashier_RPC()
	{
	}

	public void AddCashier_Broadcast(Cashier cashier)
	{
	}

	[PunRPC]
	public void AddCashier_RPC(int cashierPhotonViewId)
	{
	}
}
