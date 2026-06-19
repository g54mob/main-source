using System;
using Cinemachine;
using UnityEngine;

namespace HeneGames.Airplane
{
	public class SimpleAirplaneCamera : MonoBehaviour
	{
		private CinemachineBrain brain;

		[Header("References")]
		[SerializeField]
		private SimpleAirPlaneController airPlaneController;

		[SerializeField]
		private CinemachineFreeLook freeLook;

		[Header("Camera values")]
		[SerializeField]
		private float cameraDefaultFov = 60f;

		[SerializeField]
		private float cameraTurboFov = 40f;

		private void OnEnable()
		{
			SimpleAirPlaneController simpleAirPlaneController = airPlaneController;
			simpleAirPlaneController.crashAction = (Action)Delegate.Combine(simpleAirPlaneController.crashAction, new Action(Crash));
		}

		private void OnDisable()
		{
			SimpleAirPlaneController simpleAirPlaneController = airPlaneController;
			simpleAirPlaneController.crashAction = (Action)Delegate.Remove(simpleAirPlaneController.crashAction, new Action(Crash));
		}

		private void Start()
		{
			brain = GetComponent<CinemachineBrain>();
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void Update()
		{
			CameraFovUpdate();
		}

		private void CameraFovUpdate()
		{
			if (!airPlaneController.PlaneIsDead() && airPlaneController.airplaneState == SimpleAirPlaneController.AirplaneState.Flying)
			{
				if (Input.GetKey(KeyCode.LeftShift) && !airPlaneController.TurboOverheating())
				{
					ChangeCameraFov(cameraTurboFov);
				}
				else
				{
					ChangeCameraFov(cameraDefaultFov);
				}
			}
			else
			{
				ChangeCameraFov(cameraDefaultFov);
			}
		}

		public void ChangeCameraFov(float _fov)
		{
			float num = Time.deltaTime * 100f;
			freeLook.m_Lens.FieldOfView = Mathf.Lerp(freeLook.m_Lens.FieldOfView, _fov, 0.05f * num);
		}

		private void Crash()
		{
			brain.m_BlendUpdateMethod = CinemachineBrain.BrainUpdateMethod.FixedUpdate;
		}
	}
}
