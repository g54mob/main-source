using Photon.Pun;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkCheckoutInteraction : NetworkInteraction
{
	private CheckoutInteraction m_CheckoutInteraction;

	protected override void Initialize()
	{
	}

	private void SyncCheckoutState_Broadcast(string newPlayerUserId)
	{
	}

	[PunRPC]
	public void SyncCheckoutInteractionState_RPC(string newPlayerUserId, string senderUserId, int checkoutViewId, int currentState)
	{
	}

	public void BoxUpCheckout_Broadcast()
	{
	}

	public void BoxUpCheckoutRequest()
	{
	}

	[PunRPC]
	public void BoxUpCheckoutRequest_RPC()
	{
	}

	public void PlaceCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void PlaceCheckout_RPC()
	{
	}

	public void OnBackCheckoutAll_Broadcast()
	{
	}

	public void OnBackCheckout_Broadcast()
	{
	}

	[PunRPC]
	public void OnBackCheckout_RPC()
	{
	}

	public void ScanProduct_Broadcast(int productIndex)
	{
	}

	[PunRPC]
	public void ScanProduct_RPC(int productIndex)
	{
	}
}
