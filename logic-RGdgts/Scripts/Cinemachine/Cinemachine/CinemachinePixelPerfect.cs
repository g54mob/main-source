using UnityEngine;

namespace Cinemachine
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	public class CinemachinePixelPerfect : CinemachineExtension
	{
		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
