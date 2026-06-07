using Cinemachine;

public class CineMachineSpringArm : CineMachineCamera
{
	private CinemachineFreeLook freeLookCamera;

	private bool hasPlayerPitch;

	private bool hasPlayerYaw;

	private float aimDamping;

	private CinemachineComposer[] composers;

	protected override void Awake()
	{
		base.Awake();
		freeLookCamera = GetComponentInChildren<CinemachineFreeLook>();
		composers = new CinemachineComposer[3];
		for (int i = 0; i < composers.Length; i++)
		{
			composers[i] = freeLookCamera.GetRig(i).GetCinemachineComponent<CinemachineComposer>();
		}
		aimDamping = composers[0].m_HorizontalDamping;
	}

	private void CheckIsBeingMovedByPlayer()
	{
		if (!hasPlayerPitch && !hasPlayerYaw)
		{
			for (int i = 0; i < composers.Length; i++)
			{
				composers[i].m_HorizontalDamping = aimDamping;
			}
		}
		else
		{
			for (int j = 0; j < composers.Length; j++)
			{
				composers[j].m_HorizontalDamping = 0f;
			}
		}
	}

	public void AddCameraPitch(float pitch)
	{
		freeLookCamera.m_YAxis.m_InputAxisValue = pitch;
		hasPlayerPitch = pitch != 0f;
		CheckIsBeingMovedByPlayer();
	}

	public void AddCameraYaw(float yaw)
	{
		freeLookCamera.m_XAxis.m_InputAxisValue = yaw;
		hasPlayerYaw = yaw != 0f;
		CheckIsBeingMovedByPlayer();
	}
}
