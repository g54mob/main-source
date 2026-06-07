namespace Cinemachine.PostFX
{
	[SaveDuringPlay]
	public class CinemachinePostProcessing : CinemachineExtension
	{
		protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
		{
		}
	}
}
