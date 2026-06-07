using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachineFollowZoom : CinemachineExtension
	{
		private class VcamExtraState
		{
			public float m_previousFrameZoom;
		}

		public float m_Width;

		public float m_Damping;

		public float m_MinFOV;

		public float m_MaxFOV;

		private void OnValidate()
		{
		}

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
