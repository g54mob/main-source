using Cinemachine;
using UnityEngine;

[ExecuteAlways]
[SaveDuringPlay]
public class CinemachineCameraOffset : CinemachineExtension
{
	public Vector3 m_Offset;

	public CinemachineCore.Stage m_ApplyAfter;

	public bool m_PreserveComposition;

	protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
	{
	}
}
