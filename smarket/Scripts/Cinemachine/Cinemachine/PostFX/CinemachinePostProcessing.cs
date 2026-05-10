using UnityEngine;

namespace Cinemachine.PostFX
{
	[SaveDuringPlay]
	[AddComponentMenu(null)]
	public class CinemachinePostProcessing : CinemachineExtension
	{
		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
