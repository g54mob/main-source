using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkShoplifterIndicator : MonoBehaviourPun, IPunInstantiateMagicCallback
	{
		private ShoplifterIndicator _shoplifterIndicator;

		public ShoplifterIndicator ShoplifterIndicator => null;

		public void OnPhotonInstantiate(PhotonMessageInfo info)
		{
		}
	}
}
