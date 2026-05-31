using Photon.Pun;
using __Project__.Scripts.Data;
using __Project__.Scripts.Managers;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkCategorySignManager : NoktaSingletonPunCallbacks<NetworkCategorySignManager>
	{
		private CategorySignManager m_CategorySignManager;

		private void Start()
		{
		}

		private void OnSyncRequest(string invokerUserID)
		{
		}

		public void NetworkCategorySignEdited_Broadcast(CategorySignData categorySignData, int displayViewId)
		{
		}

		[PunRPC]
		public void NetworkCategorySignEdited_RPC(string CategorySignData, int displayViewId)
		{
		}

		public void SwitchCategorySignBackgroundColor_Broadcast(int nameBackGroundColorIndex, CategorySign categorySign)
		{
		}

		[PunRPC]
		public void SwitchCategorySignBackgroundColor_RPC(int nameBackGroundColorIndex, int categorySignViewId)
		{
		}
	}
}
