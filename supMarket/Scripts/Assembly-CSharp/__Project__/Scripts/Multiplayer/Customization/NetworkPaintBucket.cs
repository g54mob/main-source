using Photon.Pun;
using __Project__.Scripts.WallPaintSystem;

namespace __Project__.Scripts.Multiplayer.Customization
{
	public class NetworkPaintBucket : MonoBehaviourPunCallbacks, IPunInstantiateMagicCallback
	{
		private PaintBucket m_PaintBucket;

		public PaintBucket PaintBucket => null;

		public BucketData BucketData => null;

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
	}
}
