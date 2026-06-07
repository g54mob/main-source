using ExitGames.Client.Photon;
using Photon.Pun;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkMoneyManager : MonoBehaviourPunCallbacks
	{
		public override void OnJoinedRoom()
		{
		}

		public override void OnRoomPropertiesUpdate(Hashtable propsThatChanged)
		{
		}

		public override void OnEnable()
		{
		}

		private void InitMoneyFromRoom()
		{
		}

		public void OnMoneyTransition_Broadcast(float amount, MoneyManager.TransitionType type, bool updateMoneyText)
		{
		}

		[PunRPC]
		public void OnMoneyTransition_RPC(float amount, int type, bool updateMoneyText)
		{
		}

		public void OnMoneyTransition_MasterRequest(float amount, MoneyManager.TransitionType type, bool updateMoneyText)
		{
		}

		[PunRPC]
		public void OnMoneyTransition_MasterHandler(float amount, MoneyManager.TransitionType type, bool updateMoneyText)
		{
		}
	}
}
