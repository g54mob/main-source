using System;
using System.Collections;
using UnityEngine;

namespace HQFPSTemplate
{
	public class CameraFOVHandler : PlayerComponent
	{
		[Serializable]
		private class FOVCameraState
		{
			[Range(0f, 100f)]
			public float FOVSetSpeed = 30f;

			[Range(30f, 120f)]
			public float TargetFOV = 90f;
		}

		[SerializeField]
		[Range(0.1f, 2f)]
		private float m_GlobalFOVMod = 1f;

		[Space]
		[BHeader("FOV per Player State", true, order = 2)]
		[SerializeField]
		[Group]
		private FOVCameraState m_IdleCameraFOV;

		[SerializeField]
		[Group]
		private FOVCameraState m_CrouchCameraFOV;

		[SerializeField]
		[Group]
		private FOVCameraState m_RunCameraFOV;

		[SerializeField]
		[Group]
		private FOVCameraState m_ProneCameraFOV;

		[Space]
		[SerializeField]
		[Group]
		private FOVCameraState m_AimCameraFOV;

		private Camera m_PlayerCam;

		private FOVCameraState m_CurrentFOVState;

		private Coroutine m_FOVSetter;

		public override void OnEntityStart()
		{
			m_PlayerCam = base.Player.Camera.UnityCamera;
			ChangeFOVState(m_IdleCameraFOV);
			base.Player.Aim.AddStartListener(delegate
			{
				ChangeFOVState(m_AimCameraFOV);
			});
			base.Player.Aim.AddStopListener(delegate
			{
				ChangeFOVState(m_IdleCameraFOV);
			});
			base.Player.Run.AddStartListener(delegate
			{
				ChangeFOVState(m_RunCameraFOV);
			});
			base.Player.Run.AddStopListener(delegate
			{
				ChangeFOVState(m_IdleCameraFOV);
			});
			base.Player.Crouch.AddStartListener(delegate
			{
				ChangeFOVState(m_CrouchCameraFOV);
			});
			base.Player.Crouch.AddStopListener(delegate
			{
				ChangeFOVState(m_IdleCameraFOV);
			});
			base.Player.Prone.AddStartListener(delegate
			{
				ChangeFOVState(m_ProneCameraFOV);
			});
			base.Player.Prone.AddStopListener(delegate
			{
				ChangeFOVState(m_IdleCameraFOV);
			});
		}

		private void ChangeFOVState(FOVCameraState fovCamState)
		{
			m_CurrentFOVState = fovCamState;
			if (m_FOVSetter != null)
			{
				StopCoroutine(m_FOVSetter);
			}
			m_FOVSetter = StartCoroutine(C_SetFOV());
		}

		private IEnumerator C_SetFOV()
		{
			float targetFOV = Camera.HorizontalToVerticalFieldOfView(m_CurrentFOVState.TargetFOV * m_GlobalFOVMod, m_PlayerCam.aspect);
			float currentFOV = m_PlayerCam.fieldOfView;
			while (Mathf.Abs(currentFOV - targetFOV) > Mathf.Epsilon)
			{
				currentFOV = Mathf.MoveTowards(currentFOV, targetFOV, Time.deltaTime * m_CurrentFOVState.FOVSetSpeed);
				m_PlayerCam.fieldOfView = currentFOV;
				yield return null;
			}
		}
	}
}
