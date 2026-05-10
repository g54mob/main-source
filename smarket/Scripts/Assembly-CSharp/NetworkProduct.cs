using Photon.Pun;

public class NetworkProduct : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
	private Product m_Product;

	private PhotonView m_PhotonView;

	private int m_ProductId;

	public Product Product => null;

	public PhotonView PhotonView => null;

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}
}
