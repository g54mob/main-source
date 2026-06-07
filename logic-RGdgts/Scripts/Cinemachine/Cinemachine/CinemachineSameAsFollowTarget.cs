using UnityEngine;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineSameAsFollowTarget : CinemachineComponentBase
	{
		public float m_Damping;

		private Quaternion m_PreviousReferenceOrientation;

		public override bool IsValid => false;

		public override CinemachineCore.Stage Stage => default(CinemachineCore.Stage);

		public override float GetMaxDampTime()
		{
			return 0f;
		}

		public override void MutateCameraState(ref CameraState curState, float deltaTime)
		{
		}
	}
}
