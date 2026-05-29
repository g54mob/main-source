using Photon.Pun;

public class NetworkOnlineOrderCustomer : MonoBehaviourPun, IPunInstantiateMagicCallback
{
	public void DeliverOrder_Others(OrderListData data, int paperBagViewId)
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	private void OnDisable()
	{
	}

	[PunRPC]
	public void DeliverOrder_RPC(OrderListData data, int paperBagViewId)
	{
	}
}
