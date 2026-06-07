using UnityEngine;

namespace Photon.Pun
{
	public class PhotonTransformViewScaleControl
	{
		private PhotonTransformViewScaleModel m_Model;

		private Vector3 m_NetworkScale;

		public PhotonTransformViewScaleControl(PhotonTransformViewScaleModel model)
		{
		}

		public Vector3 GetNetworkScale()
		{
			return default(Vector3);
		}

		public Vector3 GetScale(Vector3 currentScale)
		{
			return default(Vector3);
		}

		public void OnPhotonSerializeView(Vector3 currentScale, PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
