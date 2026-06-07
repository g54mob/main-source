using Photon.Pun;
using UnityEngine;
using __Project__.Scripts.Multiplayer.NetworkInteractions;

namespace __Project__.Scripts.Multiplayer.NetworkComputer
{
	public class NetworkComputerInteraction : NetworkInteraction
	{
		private ComputerInteraction m_ComputerInteraction;

		public ComputerInteraction ComputerInteraction => null;

		public void PlaceComputer_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceComputer_RPC(Vector3 playSoundPosition)
		{
		}
	}
}
