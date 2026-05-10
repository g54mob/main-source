using Photon.Pun;

public class NetworkIceCreamBucket : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
{
	private IceCreamBucket m_IceCreamBucket;

	public IceCreamBucket IceCreamBucket => null;

	public IceCreamFlavourData BucketData => null;

	public void PickupBucket_Broadcast(PlayerInstance playerInstance)
	{
	}

	[PunRPC]
	public void PickupBucket_RPC(string userID)
	{
	}

	public void OnPhotonInstantiate(PhotonMessageInfo info)
	{
	}

	public void SyncValue_Others(int remaining, bool fromPlayer)
	{
	}

	[PunRPC]
	private void SyncValue_RPC(int remaining)
	{
	}
}
