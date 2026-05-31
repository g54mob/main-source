using Photon.Pun;

namespace __Project__.Scripts.Multiplayer.Managers
{
	public class NetworkLicenseManager : NoktaSingletonPunCallbacks<NetworkLicenseManager>
	{
		public void PurchaseLicense_Broadcast(int licenseID)
		{
		}

		[PunRPC]
		public void PurchaseLicense_RPC(int licenseID)
		{
		}

		private void Start()
		{
		}

		private void OnSyncRequest(string userId)
		{
		}

		public void SyncUnlockedLicenses_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void SyncUnlockedLicenses_RPC(int[] unlockedLicenses)
		{
		}
	}
}
