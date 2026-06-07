using Cinemachine;
using UnityEngine;

[ExecuteAlways]
[SaveDuringPlay]
public class CinemachineRecomposer : CinemachineExtension
{
	public CinemachineCore.Stage m_ApplyAfter;

	public float m_Tilt;

	public float m_Pan;

	public float m_Dutch;

	public float m_ZoomScale;

	public float m_FollowAttachment;

	public float m_LookAtAttachment;

	private void Reset()
	{
	}

	private void OnValidate()
	{
	}

	public override void PrePipelineMutateCameraStateCallback(CinemachineVirtualCameraBase vcam, ref CameraState curState, float deltaTime)
	{
	}

	protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
	{
	}
}
