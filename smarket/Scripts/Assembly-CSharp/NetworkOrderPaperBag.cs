using Photon.Pun;

public class NetworkOrderPaperBag : MonoBehaviourPun
{
	private string m_Holder;

	public bool HasHolder => false;

	public void SpreadOn_Others(int[] productId, int[] viewId, int productCount)
	{
	}

	public void SetHolder_Broadcast(string value)
	{
	}

	[PunRPC]
	private void SetHolder_RPC(string userId)
	{
	}

	public void SetHolder(string userId)
	{
	}

	[PunRPC]
	private void SpreadOn_RPC(int[] productIds, int[] viewIds, int productCount)
	{
	}
}
