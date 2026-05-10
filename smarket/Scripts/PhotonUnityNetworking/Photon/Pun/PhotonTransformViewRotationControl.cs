using UnityEngine;

namespace Photon.Pun
{
	public class PhotonTransformViewRotationControl
	{
		private PhotonTransformViewRotationModel m_Model;

		private Quaternion m_NetworkRotation;

		public PhotonTransformViewRotationControl(PhotonTransformViewRotationModel model)
		{
		}

		public Quaternion GetNetworkRotation()
		{
			return default(Quaternion);
		}

		public Quaternion GetRotation(Quaternion currentRotation)
		{
			return default(Quaternion);
		}

		public void OnPhotonSerializeView(Quaternion currentRotation, PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
