using Photon.Pun;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkMopInteraction : NetworkInteraction
	{
		private MopInteraction m_MopInteraction;

		public MopInteraction MopInteraction => null;

		protected override void Initialize()
		{
		}

		private void SyncMopState_Broadcast(string newPlayerUserID)
		{
		}

		[PunRPC]
		public void SyncMopBatState_RPC()
		{
		}

		public void DisableMop_Broadcast()
		{
		}

		public void UpdateCleaningState_Broadcast(bool state)
		{
		}

		[PunRPC]
		public void UpdateMopAttachmentState_RPC(bool state)
		{
		}

		[PunRPC]
		public void DisableMop_RPC()
		{
		}

		public void OnCleanedEvent_Broadcast(int viewID)
		{
		}

		[PunRPC]
		public void OnCleanedEvent_RPC(int viewID)
		{
		}
	}
}
