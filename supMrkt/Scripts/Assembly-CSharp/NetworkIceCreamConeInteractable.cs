using Photon.Pun;

public class NetworkIceCreamConeInteractable : MonoBehaviourPun
{
	private IceCreamConeInteractable m_Interactable;

	private void Awake()
	{
	}

	public void SyncValue_Others(int value)
	{
	}

	[PunRPC]
	private void SyncValue_RPC(int value)
	{
	}
}
