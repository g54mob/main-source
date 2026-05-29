using Photon.Pun;
using __Project__.Scripts.Computer.Shopping;

public class NetworkScannerSaleItem : MonoBehaviourPunCallbacks
{
	private ScannerSaleItem m_ScannerSaleItem;

	private PhotonView m_PhotonView;

	public PhotonView PhotonView => null;

	public ScannerSaleItem ScannerSaleItem => null;

	private void Start()
	{
	}

	private void SyncScannerSaleItemState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncScannerSaleItemState_RPC(bool _IsPurchased, bool _IsUnlocked)
	{
	}

	public void PurchaseScanner_Request()
	{
	}

	[PunRPC]
	public void PurchaseScanner_Response()
	{
	}

	[PunRPC]
	public void PurchaseScanner_Broadcast()
	{
	}

	[PunRPC]
	public void PurchaseScanner_RPC()
	{
	}

	public void NetworkSetup_Broadcast()
	{
	}

	[PunRPC]
	public void NetworkSetup_RPC(bool isPurchased, bool isUnlocked)
	{
	}
}
