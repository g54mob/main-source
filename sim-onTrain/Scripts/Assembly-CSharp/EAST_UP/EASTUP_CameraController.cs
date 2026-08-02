using HQFPSTemplate;
using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace EAST_UP
{
	public class EASTUP_CameraController : NetworkBehaviour
	{
		public Camera mainCamera;

		public PlayerCamera playerCamera;

		public Transform fpsCameraPos;

		public Vector2 fpsLookLimits;

		public Transform tpsCameraPos;

		public Vector2 tpsLookLimits;

		[Header("Camera Settings")]
		public float maxViewAngle = 75f;

		public float sensitivityX = 50f;

		public float sensitivityY = 50f;

		[Header("Camera Modes")]
		public KeyCode fpsModeKey = KeyCode.Alpha1;

		public KeyCode tpsModeKey = KeyCode.Alpha2;

		public KeyCode aimModeKey = KeyCode.Mouse1;

		private CameraMode currentCameraMode = CameraMode.TPS;

		public UnityEvent<CameraMode> OnCameraModeChanged = new UnityEvent<CameraMode>();

		private bool isFpsMode;

		private void Start()
		{
			if (base.isLocalPlayer)
			{
				isFpsMode = false;
			}
			else
			{
				isFpsMode = true;
			}
		}

		private void Update()
		{
			MouseLocker();
			if (Cursor.lockState == CursorLockMode.Locked)
			{
				SetCameraRotation(Input.GetAxis("Mouse Y") * (0f - sensitivityY), Input.GetAxis("Mouse X") * sensitivityX);
			}
		}

		private void ChangeCameraMode()
		{
			CameraMode cameraMode = (isFpsMode ? CameraMode.TPS : CameraMode.FPS);
			isFpsMode = !isFpsMode;
			switch (cameraMode)
			{
			case CameraMode.FPS:
				mainCamera.transform.position = fpsCameraPos.position;
				mainCamera.transform.eulerAngles = fpsCameraPos.eulerAngles;
				playerCamera.m_DefaultLookLimits = fpsLookLimits;
				break;
			case CameraMode.TPS:
				mainCamera.transform.position = tpsCameraPos.position;
				mainCamera.transform.eulerAngles = tpsCameraPos.eulerAngles;
				playerCamera.m_DefaultLookLimits = tpsLookLimits;
				break;
			}
			currentCameraMode = cameraMode;
			OnCameraModeChanged.Invoke(currentCameraMode);
		}

		public void SetCameraRotation(float vertical, float horizontal)
		{
		}

		private void MouseLocker()
		{
		}

		public void SetSensitivityX(float sensitivity)
		{
			sensitivityX = sensitivity;
		}

		public void SetSensitivityY(float sensitivity)
		{
			sensitivityY = sensitivity;
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
