using Photon.Pun;
using UnityEngine;

namespace __Project__.Scripts.Multiplayer.NetworkInteractions
{
	public class NetworkScaleInteraction : NetworkInteraction
	{
		private ScaleInteraction m_ScaleInteraction;

		public ScaleInteraction ScaleInteraction => null;

		public void PlaceScaleFurniture_Broadcast()
		{
		}

		[PunRPC]
		public void PlaceScaleFurniture_RPC(Vector3 playSoundPosition)
		{
		}

		public void BoxUpScale_Broadcast()
		{
		}

		public void BoxUpScaleRequest()
		{
		}

		[PunRPC]
		public void BoxUpScaleRequest_RPC()
		{
		}

		public void OnBarcodeDropped_Broadcast(Scale scale, Vector3 hitPoint, Vector3 hitNormal)
		{
		}

		[PunRPC]
		public void OnBarcodeDropped_RPC(int scaleViewId, Vector3 hitPoint, Vector3 hitNormal)
		{
		}

		public void OnScaleBack_Broadcast()
		{
		}

		[PunRPC]
		public void OnScaleBack_RPC()
		{
		}
	}
}
