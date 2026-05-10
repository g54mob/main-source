using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
	public class PhotonTransformViewPositionControl
	{
		private PhotonTransformViewPositionModel m_Model;

		private float m_CurrentSpeed;

		private double m_LastSerializeTime;

		private Vector3 m_SynchronizedSpeed;

		private float m_SynchronizedTurnSpeed;

		private Vector3 m_NetworkPosition;

		private Queue<Vector3> m_OldNetworkPositions;

		private bool m_UpdatedPositionAfterOnSerialize;

		public PhotonTransformViewPositionControl(PhotonTransformViewPositionModel model)
		{
		}

		private Vector3 GetOldestStoredNetworkPosition()
		{
			return default(Vector3);
		}

		public void SetSynchronizedValues(Vector3 speed, float turnSpeed)
		{
		}

		public Vector3 UpdatePosition(Vector3 currentPosition)
		{
			return default(Vector3);
		}

		public Vector3 GetNetworkPosition()
		{
			return default(Vector3);
		}

		public Vector3 GetExtrapolatedPositionOffset()
		{
			return default(Vector3);
		}

		public void OnPhotonSerializeView(Vector3 currentPosition, PhotonStream stream, PhotonMessageInfo info)
		{
		}

		private void SerializeData(Vector3 currentPosition, PhotonStream stream, PhotonMessageInfo info)
		{
		}

		private void DeserializeData(PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
