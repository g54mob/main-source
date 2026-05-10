using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

public class NetworkIceCreamBucketInteraction : NetworkInteraction
{
	private IceCreamBucketInteraction m_BucketInteraction;

	private IceCreamBucket m_Bucket;

	public IceCreamBucketInteraction BucketInteraction => null;

	public IceCreamBucket Bucket => null;

	public void ThrowIntoThrashBin_Broadcast()
	{
	}

	[PunRPC]
	public void ThrowIceCreamBucketTrashBin_RPC(Vector3 playSoundPosition)
	{
	}

	public void RequestDestroyIceCreamBucket_Master()
	{
	}

	[PunRPC]
	private void RequestDestroyIceCreamBucket_RPC(int boxId, int bucketId)
	{
	}
}
