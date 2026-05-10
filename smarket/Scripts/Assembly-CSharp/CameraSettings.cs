using Cinemachine;
using UnityEngine;

public class CameraSettings : MonoBehaviour
{
	[SerializeField]
	private CinemachineVirtualCamera m_FPSCam;

	[SerializeField]
	private Camera m_uiCamera;

	[SerializeField]
	private Camera m_onboardingCamera;

	public void SetFOV(float fov)
	{
	}
}
