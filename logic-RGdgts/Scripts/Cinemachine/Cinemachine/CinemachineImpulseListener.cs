using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[ExecuteAlways]
	public class CinemachineImpulseListener : CinemachineExtension
	{
		public CinemachineCore.Stage m_ApplyAfter;

		[CinemachineImpulseChannelProperty]
		public int m_ChannelMask;

		public float m_Gain;

		public bool m_Use2DDistance;

		private void Reset()
		{
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
