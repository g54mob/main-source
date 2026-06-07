using UnityEngine;

namespace Cinemachine
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	public class CinemachineExternalCamera : CinemachineVirtualCameraBase
	{
		[NoSaveDuringPlay]
		[VcamTargetProperty]
		public Transform m_LookAt;

		private Camera m_Camera;

		private CameraState m_State;

		public BlendHint m_BlendHint;

		public override CameraState State => default(CameraState);

		public override Transform LookAt
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override Transform Follow { get; set; }

		public override void InternalUpdateCameraState(Vector3 worldUp, float deltaTime)
		{
		}
	}
}
