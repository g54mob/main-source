using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineIndependentImpulseListener : MonoBehaviour
	{
		private Vector3 impulsePosLastFrame;

		private Quaternion impulseRotLastFrame;

		[CinemachineImpulseChannelProperty]
		public int m_ChannelMask;

		public float m_Gain;

		public bool m_Use2DDistance;

		private void Reset()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
