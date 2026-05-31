using Photon.Pun;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkInteraction : MonoBehaviourPunCallbacks
	{
		protected PlayerInstance m_PlayerInstance;

		protected string UserID => null;

		private void Start()
		{
		}

		protected virtual void Initialize()
		{
		}
	}
}
