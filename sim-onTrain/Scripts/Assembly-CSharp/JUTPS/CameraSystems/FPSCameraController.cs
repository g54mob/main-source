using JUTPS.CharacterBrain;
using JUTPS.JUInputSystem;
using JUTPS.WeaponSystem;
using UnityEngine;

namespace JUTPS.CameraSystems
{
	public class FPSCameraController : JUCameraController
	{
		private JUCharacterBrain characterTarget;

		private float xmouse;

		private float ymouse;

		private float SmoothedYMouse;

		private float SmoothedXMouse;

		private float ScopeModeRecoil;

		private float weight;

		private Vector3 CamPosition;

		private Vector3 SmoothedCameraPosition;

		public CameraState FPSCameraState = new CameraState("FPS Camera State", 0f, 100f, 50f);

		public CameraState AimModeCameraState = new CameraState("FPS Camera State", 0f, 100f, 50f);

		public CameraState DrivingModeCameraState = new CameraState("FPS Camera State", 0f, 1000f, 70f);

		[Header("Weapon Sway Config")]
		public float AimInSpeed = 6f;

		public float AimOutSpeed = 6f;

		public float SwaySpeed = 5f;

		public float HorizontalIntensity = 1f;

		public float VerticalIntensity = 1f;

		public float AimHorizontalIntensity = 1f;

		public float AimVerticalIntensity = 1f;

		protected override void Start()
		{
			base.Start();
			if (TargetToFollow.TryGetComponent<JUCharacterBrain>(out var component))
			{
				characterTarget = component;
				TargetToFollow = characterTarget.HumanoidSpine;
				characterTarget.LocomotionMode = JUCharacterBrain.MovementMode.AwaysInFireMode;
			}
		}

		private void Update()
		{
			if (Cursor.lockState != CursorLockMode.Locked && !JUGameManager.IsMobile)
			{
				xmouse = 0f;
				ymouse = 0f;
				return;
			}
			xmouse = (float)(Aiming ? 30 : 100) * JUInput.GetAxis(JUInput.Axis.RotateVertical) / 100f;
			ymouse = (float)(Aiming ? 30 : 100) * JUInput.GetAxis(JUInput.Axis.RotateHorizontal) / 100f;
			if (characterTarget != null)
			{
				if (characterTarget.IsDriving && characterTarget.VehicleInArea != null)
				{
					xmouse = 0f;
					ymouse = 0f;
					SetCameraRotation(TargetToFollow.transform.rotation.x, characterTarget.VehicleInArea.transform.eulerAngles.y, SmoothRotate: false);
				}
				characterTarget.IsRolling = false;
				if (characterTarget.IsDriving)
				{
					SetCameraStateTransition(base.GetCurrentCameraState, DrivingModeCameraState);
					RotateCamera(xmouse, ymouse, 30f, characterTarget.VehicleInArea.transform.up, characterTarget.VehicleInArea.transform);
				}
				else
				{
					SetCameraStateTransition(base.GetCurrentCameraState, Aiming ? AimModeCameraState : FPSCameraState);
					RotateCamera(xmouse, ymouse, 30f, (characterTarget == null) ? TargetToFollow.up : characterTarget.transform.up);
				}
			}
			else
			{
				RotateCamera(xmouse, ymouse, 30f, (characterTarget == null) ? TargetToFollow.up : characterTarget.transform.up);
			}
		}

		private void LateUpdate()
		{
			SetFieldOfView(base.GetCurrentCameraState.CameraFieldOfView);
			SetCameraPositionToScopePosition();
		}

		private void FixedUpdate()
		{
			SetPivotCameraPosition(base.GetCurrentCameraState.GetCameraPivotPosition(TargetToFollow), SmoothMove: false);
		}

		public override void RecoilReaction(float Force)
		{
			base.RecoilReaction(Force);
			ScopeModeRecoil -= Force / 30f;
		}

		public void SetCameraPositionToScopePosition()
		{
			if (characterTarget == null)
			{
				return;
			}
			Aiming = characterTarget.IsAiming;
			if (characterTarget.WeaponInUseRightHand == null || characterTarget.IsDriving)
			{
				return;
			}
			if (characterTarget.WeaponInUseRightHand.AimMode != Weapon.WeaponAimMode.None && characterTarget.FiringMode)
			{
				Weapon weaponInUseRightHand = characterTarget.WeaponInUseRightHand;
				SmoothedYMouse = Mathf.Lerp(SmoothedYMouse, ymouse * (Aiming ? AimHorizontalIntensity : HorizontalIntensity), SwaySpeed * Time.deltaTime);
				SmoothedXMouse = Mathf.Lerp(SmoothedXMouse, xmouse * (Aiming ? AimVerticalIntensity : VerticalIntensity), SwaySpeed * Time.deltaTime);
				ScopeModeRecoil = Mathf.Lerp(ScopeModeRecoil, 0f, 5f * Time.deltaTime);
				Vector3 a = weaponInUseRightHand.transform.position + weaponInUseRightHand.transform.right * (weaponInUseRightHand.CameraAimingPosition.x - SmoothedYMouse / 20f) + weaponInUseRightHand.transform.up * (weaponInUseRightHand.CameraAimingPosition.y - SmoothedXMouse / 20f) + mCamera.transform.parent.forward * (weaponInUseRightHand.CameraAimingPosition.z - ScopeModeRecoil);
				Vector3 b = TargetToFollow.transform.position + mCamera.transform.parent.right * (base.GetCurrentCameraState.RightCameraOffset - SmoothedYMouse / 10f) + mCamera.transform.parent.up * (base.GetCurrentCameraState.UpCameraOffset - SmoothedXMouse / 4f) + mCamera.transform.parent.forward * base.GetCurrentCameraState.ForwardCameraOffset;
				if (!Aiming)
				{
					weight = Mathf.MoveTowards(weight, 1f, AimInSpeed * Time.deltaTime);
				}
				else
				{
					weight = Mathf.MoveTowards(weight, 0f, AimOutSpeed * Time.deltaTime);
				}
				CamPosition = Vector3.Lerp(a, b, weight);
				SmoothedCameraPosition = Vector3.Slerp(SmoothedCameraPosition, CamPosition, 60f * Time.deltaTime);
				SetCameraPosition(CamPosition, SmoothMove: false);
				AimModeCameraState.CameraFieldOfView = Mathf.Lerp(AimModeCameraState.CameraFieldOfView, weaponInUseRightHand.CameraFOV, 15f * Time.deltaTime);
			}
			else
			{
				AimModeCameraState.CameraFieldOfView = base.GetCurrentCameraState.CameraFieldOfView;
			}
		}
	}
}
