using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Interaction;
using __Project__.Scripts.Multiplayer.NetworkInteractions;
using __Project__.Scripts.WallPaintSystem;

namespace __Project__.Scripts.Multiplayer.Customization
{
	public class NetworkBucketInteraction : NetworkInteraction
	{
		private BucketInteraction m_BucketInteraction;

		public BucketInteraction BucketInteraction => null;

		public void DropBucket_Broadcast(PaintBucket selectedBucket)
		{
		}

		[PunRPC]
		public void DropBucket_RPC(int selectedBucketViewId)
		{
		}

		public void ThrowIntoThrashBin_Broadcast()
		{
		}

		[PunRPC]
		public void ThrowBucketTrashBin_RPC(Vector3 playSoundPosition)
		{
		}

		public void BoxUpBucket_Request(PaintBucket selectedBucket)
		{
		}

		public void BoxUpBucket_Broadcast(PaintBucket selectedBucket)
		{
		}

		[PunRPC]
		public void BoxUpBucket_RPC(int selectedBucketViewId)
		{
		}

		public void StartPainting_Broadcast(PaintBucket selectedBucket, int wallID)
		{
		}

		[PunRPC]
		public void StartPainting_RPC(int selectedBucketViewId, int wallID)
		{
		}
	}
}
